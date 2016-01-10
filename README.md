# Ambilight
Ambient light software for Arduino and neopixel LED

The program takes the median of the color in the top-area of the screen and sends it to the corresponding LED through the Arduino.
The program is written in C# for simple testing and the code for the Arduino is made in their official IDE.
Only 30 LED's are used on a 60-LED strip, hence the odd code.

Current stats:
- No delay.
- All LED's update simultaneously.
- About 100 UPS
- Customizable
