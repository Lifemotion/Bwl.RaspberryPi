#include "board.h"

void var_delay_ms(int ms)
{
	for (int i=0; i<ms; i++)_delay_ms(1.0);
}

void var_delay_us(int us)
{
	for (int i=0; i<(us/50); i++)_delay_us(50);
}

