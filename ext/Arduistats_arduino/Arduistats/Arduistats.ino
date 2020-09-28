// UTFT_ViewFont 
// Copyright (C)2015 Rinky-Dink Electronics, Henning Karlsen. All right reserved
// web: http://www.RinkyDinkElectronics.com/
//
// This program is a demo of the included fonts.
//
// This demo was made for modules with a screen resolution 
// of 320x240 pixels.
//
// This program requires the UTFT library.
//

#include <UTFT.h>

// Declare which fonts we will be using
extern uint8_t SmallFont[];
extern uint8_t BigFont[];
extern uint8_t SevenSegNumFont[];
extern uint8_t SixteenSegment64x96Num[];
String inString = "";
String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";

// Set the pins to the correct ones for your development shield
// ------------------------------------------------------------
// Standard Arduino Mega/Due shield            : <display model>,38,39,40,41
// CTE TFT LCD/SD Shield for Arduino Due       : <display model>,25,26,27,28
// Teensy 3.x TFT Test Board                   : <display model>,23,22, 3, 4
// ElecHouse TFT LCD/SD Shield for Arduino Due : <display model>,22,23,31,33
//
// Remember to change the model parameter to suit your display module!
UTFT myGLCD(ILI9341_16,38,39,40,41);
/*
String inputString = "";         // a string to hold incoming data
boolean stringComplete = false;  // whether the string is complete
String commandString = "";*/
String  incomingByte;
void setup()
{
  //pinMode(LED_BUILTIN, OUTPUT);
   
    Serial.begin(9600);
    Serial.write("ALL ABOUT CIRCUITS!");//Send "ALL ABOUT CIRCUITS!" to the PC
  myGLCD.InitLCD();
myGLCD.setContrast(5);
myGLCD.setBrightness(5);
  myGLCD.clrScr();
}
/*
void serialEvent() {
 
}
*/
void loop()
{

 Serial.println("tamere");
 delay(2050);                    // wait for a second

  Serial.println("tamere");



  
   Serial.write("ALL ABOUT CIRCUITS!");//Send "ALL ABOUT CIRCUITS!" to the PC
  myGLCD.setColor(0, 255, 0);
  myGLCD.setBackColor(0, 0, 0);

  myGLCD.setFont(BigFont);
  myGLCD.print(" !\"#$%&'()*+,-./", CENTER, 0);
  myGLCD.print("0123456789:;<=>?", CENTER, 16);
  myGLCD.print("@ABCDEFGHIJKLMNO", CENTER, 32);
  myGLCD.print("PQRSTUVWXYZ[\\]^_", CENTER, 48);
  myGLCD.print("`abcdefghijklmno", CENTER, 64);
  myGLCD.print("pqrstuvwxyz{|}~ ", CENTER, 80);

 /* myGLCD.setFont(SmallFont);
  myGLCD.print(" !\"#$%&'()*+,-./0123456789:;<=>?", CENTER, 120);
  myGLCD.print("@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_", CENTER, 132);
  myGLCD.print("`abcdefghijklmnopqrstuvwxyz{|}~ ", CENTER, 54);*/

  myGLCD.setFont(SixteenSegment64x96Num);


 // Read serial input:
  while (Serial.available() > 0) {
    int inChar = Serial.read();
    if (isDigit(inChar)) {
      // convert the incoming byte to a char and add it to the string:
      inString += (char)inChar;
    }
    // if you get a newline, print the string, then the string's value:
    if (inChar == '\n') {
      myGLCD.setColor(140, 0, 0);
      myGLCD.printNumI(888,CENTER,120);
        myGLCD.setBackColor(0, 0, 0);
       delay(150);
       myGLCD.setBackColor(0, 0, 0);
      Serial.print("Value:");
      Serial.println(inString.toInt());
      Serial.print("String: ");
      Serial.println(inString);
    //  myGLCD.print(inString, CENTER, 120);
    myGLCD.setColor(0, 255, 100);
   
     myGLCD.printNumI(inString.toInt(),CENTER,120);
    
      // clear the string for new input:
  /*     delay(150);
      inString = "";
       delay(150);*/
       myGLCD.setBackColor(0, 0, 0);
          delay(2050);
       inString = "";
      
      // myGLCD.print("", CENTER, 120);
      delay(2050);
       inString = "";
      //  myGLCD.clrScr();
    }
  }

}
