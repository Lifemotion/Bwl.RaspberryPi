/*
* Cleverflow lib for SIM800
*
* Author: Cleverflow
*
* Version: 25.10.2017
*/

#include "SIM800.h"
#include <stdlib.h>
#include <string.h>

typedef unsigned char byte;
unsigned char gsm_uart_receive_buffer_pos = 0;
unsigned char gsm_last_line_lenght        = 0;
char          gsm_uart_receive_buffer[GSM_RECEIVED_BUFFER_LENGTH]={};
char          gsm_working                 = 0;
char          gsm_error_code              = GSM_ERROR_NONE;
char          gsm_my_phone_number[15] = {'0','0','0','0','0','0','0','0','0','0','0',0,0,0,0};
int			  gsm_rssi                    = 0;
void gsm_uart_send_string(char *string)
{
	unsigned	char  i=0;
	while (string[i]>0 && i<255)
	{
		gsm_uart_send(string[i]);
		i++;
	}
}

void gsm_uart_send_line(char *string)
{
	gsm_uart_send_string(string);
	gsm_uart_send_string("\r\n");
}

char gsm_uart_receive_line()
{
	if (gsm_uart_received())
	{
		unsigned char byte=gsm_uart_get();
		if ((byte==13)||(byte==10))
		{
			if (gsm_uart_receive_buffer_pos>0)
			{
				gsm_uart_receive_buffer[gsm_uart_receive_buffer_pos++]=0;
				gsm_last_line_lenght = gsm_uart_receive_buffer_pos;
				gsm_uart_receive_buffer_pos=0;
				return 1;
			}
		}else
		{
			if (gsm_uart_receive_buffer_pos<GSM_RECEIVED_BUFFER_LENGTH)
			{
				gsm_uart_receive_buffer[gsm_uart_receive_buffer_pos++]=byte;
			}
		}
	}
	gsm_last_line_lenght = 0;
	return 0;
}

char gsm_uart_wait_line(int time_ms)
{
	long timer_limit=(long)time_ms*100;
	long timer=0;
	do
	{
		if (gsm_uart_receive_line()>0)
		{
			return 1;
		}
		timer+=1;
	}while(timer<timer_limit);
	return 0;
}

void gsm_powerkey_on()
{
	if (gsm_statusled_get()==0)	{gsm_powerkey();}
	if (gsm_statusled_get()==0)	{gsm_powerkey();}
	if (gsm_statusled_get()==0)	{gsm_powerkey();}
}

void gsm_powerkey_off()
{
	if (gsm_statusled_get()>0)	{gsm_powerkey();}
	if (gsm_statusled_get()>0)	{gsm_powerkey();}
	if (gsm_statusled_get()>0)	{gsm_powerkey();}
}

char gsm_send_wait(char *line, char* wait, int wait_ms, char repeats)
{
	for (char i=0; i<repeats; i++)
	{
		mcu_wdt_reset();
		gsm_uart_send_line(line);
		if (gsm_uart_wait_line(wait_ms))
		{
			if (strstr(gsm_uart_receive_buffer,wait)>0){return 1;}
		}
		if (gsm_uart_wait_line(wait_ms))
		{
			if (strstr(gsm_uart_receive_buffer,wait)>0){return 1;}
		}		
	}
	return 0;
}

char gsm_send_wait_ok(char *line, int wait_ms, char repeats)
{
	return gsm_send_wait(line,"OK",wait_ms,repeats);
}

void gsm_init(char gprs_enable)
{
	gsm_working=0;
	gsm_error_code=GSM_ERROR_NONE;
	gsm_powerkey_off();
	var_delay_ms(500);
	gsm_powerkey_on();
	//Ждем регистрации в сети, иначе будут проблемы с инициализацией
	for(int i=0;i<20;i++)
	{
		if(gsm_send_wait("AT+CREG?","+CREG: 0,1",1000,1)) break;
		var_delay_ms(500);
	}
	if (gsm_send_wait_ok("AT"				,500,9)==0){gsm_error_code=GSM_ERROR_NOT_RESPOND;		return;}
	if (gsm_send_wait_ok("ATE0"				,500,9)==0){gsm_error_code=GSM_ERROR_NOT_CONFIGURED;	return;}
	if (gsm_send_wait_ok("AT+CMGF=1"		,500,3)==0){gsm_error_code=GSM_ERROR_NOT_CONFIGURED;	return;}
	if (gsm_send_wait_ok("AT+IFC=1, 1"		,500,3)==0){gsm_error_code=GSM_ERROR_NOT_CONFIGURED;	return;}
	if (gsm_send_wait_ok("AT+CPBS=\"SM\""	,500,3)==0){gsm_error_code=GSM_ERROR_NOT_CONFIGURED;	return;}
	if (gsm_send_wait_ok("AT+CNMI=1,1,0,0,0",500,3)==0){gsm_error_code=GSM_ERROR_NOT_CONFIGURED;	return;}
	gsm_send_wait_ok("AT+CSCS=\"GSM\"",2000, 2 );
	if (gprs_enable)
	{
		gsm_send_wait_ok("AT+SAPBR=3,1,\"Contype\",\"GPRS\"",2000, 1 );
		gsm_send_wait_ok("AT+SAPBR=3,1,\"APN\",\"internet\"",2000, 1 );
		gsm_send_wait_ok("AT+SAPBR=1,1",2000, 1);	
	}
	gsm_send_wait_ok("AT+CMGD=1,4",2000, 4 );
	gsm_error_code=GSM_ERROR_NONE;
}

void gsm_checkstate()
{
	for (byte i=0; i<20; i++)
	{
		if (gsm_send_wait("AT+CREG?","+CREG: 0,1",1000,1)!=0)
		{
			gsm_error_code=GSM_ERROR_NONE;
			gsm_working=1;
			return;		
		}
		var_delay_ms(200);
	}
	gsm_error_code=GSM_ERROR_NOT_OPERATIONAL;
	gsm_working=0;	
}

void gsm_rssi_request()
{
	if(gsm_statusled_get()==0)return;
	if(gsm_send_wait("AT+CSQ", "+CSQ:", 2000, 2)){
		if(gsm_uart_receive_buffer[0]=='+'){
			for(int i=1;i<gsm_last_line_lenght;i++){
				if(gsm_uart_receive_buffer[i]==32 && gsm_uart_receive_buffer[i+3]==44){
					gsm_rssi = ((gsm_uart_receive_buffer[i+1]-48)*10+(gsm_uart_receive_buffer[i+2]-48))*2-113;
				}
			}
		}
	}
}

char gsm_available_gprs_network_count()
{
	gsm_uart_send_line("AT+CGATT?");
	if(gsm_uart_wait_line(500)){
		if(gsm_last_line_lenght>8)
		{
			if(gsm_uart_receive_buffer[0]=='+'){
				return gsm_uart_receive_buffer[8]-48;  //ASCII code of '0' is 48
			} 
		} 
	}
	return -1;
}

char gsm_check_gprs_state()
{
	gsm_send_wait_ok("AT+SAPBR=1,1",2000, 1);
	return 1;
}

void gsm_send_sms(char* phone, char* message)
{
	gsm_checkstate();
	var_delay_ms(50);
	gsm_uart_send_string("AT+CMGS=\"");
	gsm_uart_send_string(phone);
	gsm_uart_send_string("\"");
	gsm_uart_send_string("\r\n");
	var_delay_ms(500);
	gsm_uart_send_string(message);
	var_delay_ms(100);
	gsm_uart_send(26);
	gsm_checkstate();
}

void gsm_reset()
{
	gsm_uart_send_line("ATZ0");
}

char gsm_http_get_request(char *url)
{	
    char http_request_result = 0;
	if(gsm_working){
		if(gsm_check_gprs_state()){ 
			gsm_send_wait_ok("AT+HTTPINIT",300, 1);
			gsm_send_wait_ok("AT+HTTPPARA=\"CID\",1",300, 1);
			gsm_uart_send_string("AT+HTTPPARA=\"URL\",\"");
			gsm_uart_send_string(url);
			gsm_send_wait_ok("\"",100, 1);
			http_request_result = gsm_send_wait("AT+HTTPACTION=0", "200", 2000, 1);
			gsm_send_wait_ok("AT+HTTPTERM", 300, 1);
		}
	}
	return http_request_result;
}

void gsm_my_phonenumber_request()
{
	if(gsm_statusled_get()==0)return;
	if(gsm_my_phone_number[0] != '+' && gsm_my_phone_number[1] != '7' && gsm_my_phone_number[2] != '9'){
		gsm_uart_send_line("AT+COPS?");
		gsm_uart_wait_line(1000);
		if(strstr(gsm_uart_receive_buffer,"MegaFon")){
			/* MegaFon */
			gsm_send_wait_ok("AT+CUSD=1,\"*205#\"",3500, 1);
			gsm_uart_wait_line(15000);
			/*parse phone number from ucs2 response*/
			unsigned char pointer = 1;
			for(int i=0;i<gsm_last_line_lenght-1;i++){
				if(gsm_uart_receive_buffer[i]==48 && gsm_uart_receive_buffer[i+1]==48 && gsm_uart_receive_buffer[i+2]==51){
					gsm_my_phone_number[pointer++] = gsm_uart_receive_buffer[i+3];
				}
			}
			gsm_my_phone_number[0] = '+';
			gsm_my_phone_number[1] = '7';
		}
	}
}

void gsm_poll()
{
	if (gsm_uart_receive_line())
	{
		if (strstr(gsm_uart_receive_buffer,"RING")>0)
		{
			gsm_uart_send_line("ATA");
		}
	}
}

char gsm_read_to_end_of_sms()
{
	gsm_uart_receive_buffer_pos = 0;
	long timer_limit = 0;
	while(timer_limit++<800000){
		if(gsm_uart_received()){
			gsm_uart_receive_buffer[gsm_uart_receive_buffer_pos++] = gsm_uart_get();
			if(gsm_uart_receive_buffer_pos>10){
				if( gsm_uart_receive_buffer[gsm_uart_receive_buffer_pos-1]==0xA\
					&& gsm_uart_receive_buffer[gsm_uart_receive_buffer_pos-2]==0xD\
					&& gsm_uart_receive_buffer[gsm_uart_receive_buffer_pos-3]==0xA\
					&& gsm_uart_receive_buffer[gsm_uart_receive_buffer_pos-4]==0xD){	
						gsm_last_line_lenght = gsm_uart_receive_buffer_pos;				
						return 1;
					}
			}
		}
	}	
	return 0;
}

//TODO Проверить: смотрим сохраненные входящие сообщения (если не успели обработать сразу). Прочитали сообщение, удалили его с симки
//Отвечает на смс стабильнее чем при работе через poll. Смс не теряются, пока мы их не прочитаем. 
void gsm_check_sms()
{
	if(gsm_working==0)return;
	if(gsm_statusled_get()==0)return;
	char character_counter = 0;
	int message_length = 0;
	gsm_uart_send_line("AT+CMGL=\"ALL\"");
	if(gsm_read_to_end_of_sms()==0)return;
	if(strstr(gsm_uart_receive_buffer, "+CMGL:")){	
		for(int i=0;i<GSM_SMS_BUFFER_LENGTH;i++){
				gsm_received_sms_text[i]=0;
		}		
		for(int i=0;i<gsm_last_line_lenght;i++){
			if(gsm_uart_receive_buffer[i]=='"')character_counter++;				
			if(character_counter==3 && gsm_uart_receive_buffer[i]=='"'){
				int pointer=0;			
				while(gsm_uart_receive_buffer[i+pointer+1]!='"' && pointer<14){
					gsm_received_sms_phone[pointer]=gsm_uart_receive_buffer[i+pointer+1];
					pointer++;
				}					
			}	
			if(character_counter==8){
				for(int p = 3;p<gsm_last_line_lenght;p++){
					gsm_received_sms_text[message_length++]=gsm_uart_receive_buffer[i+p];
					if(gsm_uart_receive_buffer[p+1]== 0xA && gsm_uart_receive_buffer[p+2]=='O' && gsm_uart_receive_buffer[p+3]=='K') break;
				}
				i = GSM_RECEIVED_BUFFER_LENGTH;					
			}		
		}
		//обрабатка
		gsm_send_wait_ok("AT+CMGD=1,4",2000, 4 ); //удаляем ВСЕ сообщения (сервисные сообщения от оператора могут испортить дело)
		gsm_received_sms();			
	}
}
