#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define PIN 2
#define NUM_LEDS 18
#define STRIP 60

int incomingChar;
String recieved;
bool readyToRecieve = true;

long startTime;
long lastUpdate;
long currentLoop;
int loops = 0;
  
char color[NUM_LEDS * 3 + 1];
int placeAt = 0;
int colorplace;

// Parameter 1 = number of pixels in strip
// Parameter 2 = Arduino pin number (most are valid)
// Parameter 3 = pixel type flags, add together as needed:
//   NEO_KHZ800  800 KHz bitstream (most NeoPixel products w/WS2812 LEDs)
//   NEO_KHZ400  400 KHz (classic 'v1' (not v2) FLORA pixels, WS2811 drivers)
//   NEO_GRB     Pixels are wired for GRB bitstream (most NeoPixel products)
//   NEO_RGB     Pixels are wired for RGB bitstream (v1 FLORA pixels, not v2)
Adafruit_NeoPixel strip = Adafruit_NeoPixel(STRIP, PIN, NEO_GRB + NEO_KHZ800);

// IMPORTANT: To reduce NeoPixel burnout risk, add 1000 uF capacitor across
// pixel power leads, add 300 - 500 Ohm resistor on first pixel's data input
// and minimize distance between Arduino and first pixel.  Avoid connecting
// on a live circuit...if you must, connect GND first.

void setup() {
  // put your setup code here, to run once:
  #if defined (__AVR_ATtiny85__)
    if (F_CPU == 16000000) clock_prescale_set(clock_div_1);
  #endif
  
  startTime = micros();
  lastUpdate = startTime;
  currentLoop = startTime;
  
  strip.begin();
  strip.setPixelColor(29, 1, 1, 1);//To see that it works
  strip.show();
  
  Serial.begin(115200);
}

void loop() {
  // put your main code here, to run repeatedly:
  /*currentLoop = micros() - startTime;
  if(currentLoop - 1000000 > lastUpdate){
    Serial.print("Loops: ");
    Serial.println(loops);
    lastUpdate = currentLoop;
    loops = 0;
  }
  loops++;*/
  if(Serial.available())
  {
  color[placeAt] = Serial.read();
  if(color[0] == 'a')
  {
    placeAt++;
    if(placeAt > NUM_LEDS * 3)
    {
      for(int i = 0; i < NUM_LEDS; i++)
      {
        colorplace = i * 3 + 1;
        strip.setPixelColor(i * 2 + 24, color[colorplace], color[colorplace + 1], color[colorplace + 2]);
      }
      strip.show();
      /*if(color[0] == 'a')
      {
        for(int i = 0; i < 91; i++)
        {
          int index = i * 3 + 1;
          strip.setPixelColor(i + 30, strip.Color(color[index], color[index+1], color[index+2]));
        }
        strip.show();
      }*/
      //Serial.write('d');
      placeAt = 0;
      }
    }
    else
    {
      placeAt = 0;
    }
  }
  /*Check if function should be run, else add to string
  if(incomingChar == '/'){
    readyToRecieve = false;
    //updateOne(recieved);
    sendLight(recieved);
    //Serial.println(recieved);
    recieved = "";
  }
  else{
    recieved += incomingChar;
  }*/
}
/*
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
    red = (code[0] - '0')*100 + (code[1] - '0')*10 + (code[2] - '0');
    green = (code[3] - '0')*100 + (code[4] - '0')*10 + (code[5] - '0');
    blue = (code[6] - '0')*100 + (code[7] - '0')*10 + (code[8] - '0');
    
    code = code.substring(9, code.length());
    
    strip.setPixelColor(i, red, green, blue);
    /*Serial.println(i);
    Serial.println(red);
    Serial.println(green);
    Serial.println(blue);
  }
  
  strip.show();
  readyToRecieve = true;
  Serial.write('d');
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
}*/
