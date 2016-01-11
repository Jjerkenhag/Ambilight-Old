#include <Adafruit_NeoPixel.h>
#ifdef __AVR__
  #include <avr/power.h>
#endif

#define PIN 2
#define NUM_LEDS 30
#define STRIP 60
  
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
  
  strip.begin();
  strip.setPixelColor(29, 1, 1, 1);//To see that it works
  strip.show();
  
  Serial.begin(115200);
}

void loop() {
  // put your main code here, to run repeatedly:
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
        strip.setPixelColor(59 - i * 2, color[colorplace], color[colorplace + 1], color[colorplace + 2]);
      }
      strip.show();
      placeAt = 0;
      }
    }
    else
    {
      placeAt = 0;
    }
  }
}
