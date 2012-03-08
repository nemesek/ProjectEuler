// Problem14.cpp : Defines the entry point for the console application.
//

#include "stdafx.h"


#include <stdio.h>

int lookup[1000000] = { 0 };

unsigned int NextNumber(unsigned int value) {
  if ((value % 2) == 0) value >>= 1;
  else value = (value * 3) + 1;
  return value;
}

int main() {
  int i = 0;
  int chainlength = 0;
  int longest = 0;
  int longestchain = 0;
  unsigned int value = 0;
  for (i = 1; i < 1000000; ++i) {
    chainlength = 0;
    value = i;
    while (value != 1) {
      ++chainlength;
      value = NextNumber(value);
      if (value >= 1000000) continue;
      if (lookup[value] != 0) {
        chainlength += lookup[value];
        break;
      }
    }

    lookup[i] = chainlength;

    if (longestchain < chainlength) {
      longest = i;
      longestchain = chainlength;
    }
  }
  printf("\n%d: %d\n", longest, longestchain);
  return 0;
}


