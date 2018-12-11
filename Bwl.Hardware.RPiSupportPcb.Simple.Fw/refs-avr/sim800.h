#ifndef SIM800_H_
#define SIM800_H_

/*
* Cleverflow lib for SIM800
*
* Author: Cleverflow
*
* Version: 25.10.2017
*/

#define GSM_RECEIVED_BUFFER_LENGTH 180
#define GSM_SMS_BUFFER_LENGTH 64

#define GSM_ERROR_NONE 0
#define GSM_ERROR_NOT_RESPOND 1
#define GSM_ERROR_NOT_POWERED 2
#define GSM_ERROR_NOT_CONFIGURED 3
#define GSM_ERROR_WRONG_MODULE 4
#define GSM_ERROR_NOT_OPERATIONAL 5

//������
char gsm_received_sms_text[GSM_SMS_BUFFER_LENGTH];
char gsm_received_sms_phone[14];
char gsm_working;
char gsm_error_code;
char gsm_my_phone_number[15];
int	 gsm_rssi;
//��������
//���������������� ������
void gsm_init(char gprs_enable);
//��������� ������� ����� ������, �������� ��� ����� ����
void gsm_poll();
//��������� SMS
void gsm_send_sms(char* phone, char* message);
//��������� ��������� ������ � ������� ����
void gsm_checkstate();
//��������� HTTP GET ������, ���������� 0 ��� ������, >0, ���� ��� ������
char gsm_http_get_request(char *url);
//��������� ����� �������� � ������, ����� �������� � gsm_my_phone_number
void gsm_my_phonenumber_request();
//������ RSSI - ���� ������� GSM
void gsm_rssi_request();
//������������� ��������� �������� ���������
void gsm_check_sms();

//������ ���� �����������
//���������� �������� ���������
void gsm_received_sms();
//������� ��������� STATUS LED SIM800
char gsm_statusled_get();
//������ ������� �� POWERKEY SIM800
void gsm_powerkey();
//�������� ms
void var_delay_ms(int ms);
//����� WDT 
void mcu_wdt_reset();
void gsm_uart_send(unsigned char byte);
unsigned char gsm_uart_get();
unsigned char gsm_uart_received();

#endif /* SIM800_H_ */
