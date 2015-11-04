#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define PIN 6

char incomingChar;
String recieved;
bool readyToRecieve = true;

// Parameter 1 = number of pixels in strip
// Parameter 2 = Arduino pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)
Adafruit_NeoPixel strip = Adafruit_NeoPixel(60, PIN, NEO_GRB + NEO_KHZ800);

// IMPORTANT: To reduce NeoPixel burnout risk, add 1000 uF capacitor across
// pixel power leads, add 300 - 500 Ohm resistor on first pixel's data input
// and minimize distance between Arduino and first pixel.  Avoid connecting
// on a live circuit...if you must, connect GND first.

void setup() {
  // put your setup code here, to run once:
  #if defined (__AVR_ATtiny85__)
    if (F_CPU == 16000000) clock_prescale_set(clock_div_1);
  #endif
  
  strip.begin();
  strip.setPixelColor(29, 1, 1, 1);
  strip.show();
  
  Serial.begin(19200);
}

void loop() {
  // put your main code here, to run repeatedly:
  if(Serial.available() > 0 && readyToRecieve){
    
    incomingChar = Serial.read();
    
    //Check if function should be run, else add to string
    if(incomingChar == '/'){
      readyToRecieve = false;
      //updateOne(recieved);
      sendLight(recieved);
      recieved = "";
    }
    else{
      recieved = recieved + incomingChar;
    }
  }
}

//Updates one LED
void updateOne(String code){
  int pos = 0, red = 0, green = 0, blue = 0;
  
  pos = hexToInt(code[0], code[1]);
  red = hexToInt(code[2], code[3]);
  green = hexToInt(code[4], code[5]);
  blue = hexToInt(code[6], code[7]);
  
  strip.setPixelColor(pos, red, green, blue);
  readyToRecieve = true;  
  strip.show();
}

//Updates the whole strip
void sendLight(String code){
  int pos = 0, red = 0, green = 0, blue = 0;
  
  for(int i = 30; i < 60; i++){
    red = hexToInt(code[0], code[1]);
    green = hexToInt(code[2], code[3]);
    blue = hexToInt(code[4], code[5]);
    
    code = code.substring(6, code.length());
    
    strip.setPixelColor(i, red, green, blue);
  }
  
  strip.show();
  readyToRecieve = true;
}

//Extract part of the string
String extract(String inString, int from, int to){
  return inString.substring(from, to);
}

//Translate hexa to decimal
int hexToInt(char a, char b)
{
  return pullOutNumber(a)*16 + pullOutNumber(b);
}

//Tool to translate from hex to dec
int pullOutNumber(char num){
  
  if(num - '0' < 10){
    return num - '0';
  }
  
  switch(num){
     case 'A':
       return 10;
       break;
     case 'B':
       return 11;
       break;
     case 'C':
       return 12;
       break;
     case 'D':
       return 13;
       break;
     case 'E':
       return 14;
       break;
     case 'F':
       return 15;
       break;
  }
}
