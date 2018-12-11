#pragma once
#include <avr/io.h>
#include "bwl_strings.h"
#include "bwl_pins.h"

#define DISPLAY_D4	A,0
#define DISPLAY_D5	A,1
#define DISPLAY_D6	A,2
#define DISPLAY_D7	A,3
#define DISPLAY_RS	A,5
#define DISPLAY_E	A,4

//delays in us
#define LCD_DELAY_PULSE   40
#define LCD_DELAY_SYMBOLS 41
#define LCD_DELAY_INIT    200

#define LCD_LINE_LENGTH 8
unsigned char lcd_line_1[LCD_LINE_LENGTH];
unsigned char lcd_line_2[LCD_LINE_LENGTH];

//Call after power-up. lcd_setup contains 500ms startup delay and lcd_setup
void lcd_setup();

//Call to reset and configure display
void lcd_init();

//Call to write buffer (lcd_line_X) to display
void lcd_writebuffer();

//Call to copy from string buffer to lcd buffer
void lcd_stringbuffer_to_linebuffer(char line);
void lcd_string_to_linebuffer(char* line);
void lcd_string_to_line(char* line, int line_number);
//Need to be realized external
void var_delay_ms(int ms);
void var_delay_us(int ms);