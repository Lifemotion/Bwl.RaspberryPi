/*
 * Bwl lib for strings
 *
 * Author: Igor Koshelev and others
 * Licensed: open-source Apache license
 *
 * Version: 01.07.2016
 */

#include "bwl_strings.h"
#include <stdlib.h>

char string_buffer[STRING_BUFFER_SIZE]={};
char string_process_buffer[16]={};
int string_buffer_pos=0;

void string_clear()
{
	for (int i=0; i<STRING_BUFFER_SIZE; i++) string_buffer[i]=0;
	string_buffer_pos=0;
}

void string_add_string(char* string)
{
	unsigned char i=0;
	while (string[i]>0 && i<STRING_BUFFER_SIZE)
	{
		if (string_buffer_pos>STRING_BUFFER_SIZE){return;}
		string_buffer[string_buffer_pos++]=string[i++];
	}
}

void string_add_char(char ch)
{
	if (string_buffer_pos>STRING_BUFFER_SIZE){return;}
	string_buffer[string_buffer_pos++]=ch;
}

void string_add_space()
{
	if (string_buffer_pos>STRING_BUFFER_SIZE){return;}
	string_buffer[string_buffer_pos++]=' ';
}

void string_add_int(int val)
{
	itoa(val,string_process_buffer,10);
	string_add_string(string_process_buffer);
}

void string_add_long(long val)
{
	ltoa(val,string_process_buffer,10);
	string_add_string(string_process_buffer);
}

void string_add_float(float val,char precision)
{
	dtostrf(val,1,precision,string_process_buffer);
	string_add_string(string_process_buffer);
}

void string_add_crlf()
{
	string_add_string("\r\n");
}

char string_split(char* instr, char delim, char* parts[], char max_parts)
{
	const int max_instr_length = 256;
	unsigned char part = 0;
	int i = 0;

	while (1)
	{
		parts[part] = instr + i;
		part++;
		while ((instr[i] != delim) && (instr[i] > 0) && (i < max_instr_length))	{i++;}
		if (instr[i] == delim)
		{
			instr[i] = 0;
			i++;
			if (part >= max_parts)	return part;
		}
		else
		{
			instr[i] = 0;
			return part;
		}
	}
}