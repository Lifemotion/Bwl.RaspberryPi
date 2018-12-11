#ifndef BOARD_H
#define BOARD_H

#define F_CPU 16000000UL
#define BAUD 9600

#define UART_RPI 0
#define UART_RS485 0

#define PIN_LED_DRIVER			D,5
#define PIN_RS485_DIR			D,4
#define PIN_CHARGE_EN			C,7
#define PIN_5V_EN				C,6
#define PIN_RPI18				D,6
#define PIN_SCL					C,0
#define PIN_SDA					C,1
#define ADC_PWR_IN				0
#define ADC_BATTERY				1

#include <avr/io.h>
#include <util/delay.h>
#include <avr/wdt.h>
#include <stdlib.h>
#include <string.h>
#include <util/setbaud.h>

#define getbit(port, bit)		((port) &   (1 << (bit)))
#define setbit(port,bit,val)	{if ((val)) {(port)|= (1 << (bit));} else {(port) &= ~(1 << (bit));}}

typedef unsigned char byte;

void var_delay_ms(int ms);
void board_init();

#endif /* BOARD_H_ */