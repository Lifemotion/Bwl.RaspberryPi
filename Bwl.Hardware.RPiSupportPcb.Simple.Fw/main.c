#define DEV_NAME "BwlPowTst2-FW1.0      "

#include "board/board.h"
#include "refs-avr/winstar1602.h"
#include "refs-avr/strings.h"
#include "refs-avr/bwl_adc.h"
#include "refs-avr/bwl_uart.h"
#include "refs-avr/bwl_simplserial.h"
#include "refs-avr/bwl_pins.h"

#define ADC_ADJ ADC_ADJUST_RIGHT
#define ADC_REF ADC_REFS_INTERNAL_1_1
#define ADC_CLK ADC_PRESCALER_128

void sserial_send_start(unsigned char portindex){};//{if (portindex==UART_485)	{DDRB|=(1<<6);PORTB|=(1<<6);}}

void sserial_send_end(unsigned char portindex){};//{if (portindex==UART_485)	{DDRB|=(1<<6);PORTB&=(~(1<<6));}}

void sserial_process_request(unsigned char portindex)
{
	//read buttons
	if (sserial_request.command==1)
	{
		sserial_response.result=128+sserial_request.command;
		sserial_response.datalength=8;
		sserial_send_response();
	}
}

void sserial_init()
{
	uart_init_withdivider(UART_RPI,UBRR_VALUE);
	uart_init_withdivider(UART_RS485,UBRR_VALUE);
	sserial_find_bootloader();
	sserial_set_devname(DEV_NAME);
	sserial_append_devname(16,12,__DATE__);
	sserial_append_devname(27,8,__TIME__);
}

float adc_get_power_in()
{
	adc_init(ADC_PWR_IN,ADC_ADJ,ADC_REF,ADC_CLK);
	float result0=adc_read_average_float(64);
	float result=result0*1.1/1024.0*69.0;
	return result;
}

float adc_get_battery_in()
{
	adc_init(ADC_BATTERY,ADC_ADJ,ADC_REF,ADC_CLK);
	float result0=adc_read_average_float(64);
	float result=result0*1.1/1024.0/0.01;
	return result;
}

int main(void)
{
	start:
	wdt_enable(WDTO_8S);
	sserial_init();
	
	while(1)
	{
		wdt_reset();
	}
}