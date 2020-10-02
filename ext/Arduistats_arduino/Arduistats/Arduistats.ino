// https://oleddisplay.squix.ch/#/home
// https://github.com/ImpulseAdventure/GUIslice-Builder/releases
#include <UTFT.h>

// Declare which fonts we will be using
//extern uint8_t Roboto_Mono_Thin_65[];
extern unsigned short tildezerov[6400];
extern unsigned short finaldisco[6400];
extern uint8_t Roboto64x96Num[];
extern uint8_t SmallFont[];
extern uint8_t BigFont[];
extern uint8_t SevenSegNumFont[];
extern uint8_t SixteenSegment64x96Num[];
String lVisit = "";
bool _hpstats = false;
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

String  incomingByte;
void setup()
{
  Serial.begin(9600);
  Serial.write("ALL ABOUT CIRCUITS!");//Send "ALL ABOUT CIRCUITS!" to the PC
  myGLCD.InitLCD();
  myGLCD.clrScr();
    portStatus(false);
  httpStatus(false);
  sinceLastvisit("15S AGO");
  //Middle rectangle
  myGLCD.setColor(50, 50, 50);
  myGLCD.fillRect(0,50,319,400);
  //Bottom rectangle website
//  myGLCD.setColor(255, 0, 0);
//  myGLCD.fillRect(0,210,319,400);
  //bottom website name
  myGLCD.setFont(BigFont);
  myGLCD.setBackColor(50, 50, 50);
  myGLCD.setColor(255, 255, 255);
  DisconnectedBitmap();
  myGLCD.print("www.araclouds.com", CENTER, 220);
}
//
//Stats display
void portStatus(bool portstat){

  if (portstat == true) {
    myGLCD.setFont(SmallFont);
     myGLCD.setBackColor(0, 0, 0);
      
    myGLCD.print("PORT CONNECTED TO        ", LEFT, 0);
  }
  else {
    myGLCD.setFont(SmallFont);
    myGLCD.setBackColor(0, 0, 0);
    myGLCD.setColor(130, 130, 130);
    myGLCD.print("PORT CLOSED           ", LEFT, 0);
  }
  
}

void httpStatus(bool htpstat){

  if (htpstat == true) {
    myGLCD.setFont(SmallFont);
    myGLCD.print("HTTP CONNECTED", LEFT + 15, 15);
  }
    else  {
    myGLCD.setFont(SmallFont);
    myGLCD.setColor(130, 130, 130);
    myGLCD.print("HTTP DISCONNECTED", LEFT + 15, 15);
  }
}

void sinceLastvisit(String lVisit){

  if (_hpstats == false) {
     myGLCD.setFont(SmallFont);
     myGLCD.setColor(130, 130, 130);
    myGLCD.print("LAST VISIT : UNKNOWN", LEFT + 15, 30);
  }

  else {
    myGLCD.setFont(SmallFont);
    myGLCD.print("LAST VISIT : " + lVisit + "S AGO", LEFT + 15, 30);
  }
  
}
// End Stats display
//
void loop()
{

 delay(2000);                    
  Serial.println("println alive");
  Serial.write("write alive !"); //Send "write alive !" to the PC
  myGLCD.setColor(0, 255, 0);
  myGLCD.setBackColor(0, 0, 0);
  myGLCD.setFont(BigFont);
 /* myGLCD.print(" !\"#$%&'()*+,-./", CENTER, 0);
  myGLCD.print("0123456789:;<=>?", CENTER, 16);
  myGLCD.print("@ABCDEFGHIJKLMNO", CENTER, 32);
  myGLCD.print("PQRSTUVWXYZ[\\]^_", CENTER, 48);
  myGLCD.print("`abcdefghijklmno", CENTER, 64);
  myGLCD.print("pqrstuvwxyz{|}~ ", CENTER, 80);*/

 /* myGLCD.setFont(SmallFont);
  myGLCD.print(" !\"#$%&'()*+,-./0123456789:;<=>?", CENTER, 120);
  myGLCD.print("@ABCDEFGHIJKLMNOPQRSTUVWXYZ[\\]^_", CENTER, 132);
  myGLCD.print("`abcdefghijklmnopqrstuvwxyz{|}~ ", CENTER, 54);*/

  


 // Read serial input:
  while (Serial.available() > 0) {
    portStatus(true);
    int inChar = Serial.read();
    if (isDigit(inChar)) {
      httpStatus(true);
      // convert the incoming byte to a char and add it to the string:
      inString += (char)inChar;
    }
    // if you get a newline, print the string, then the string's value:
    if (inChar == '\n') {
      
      myGLCD.setColor(140, 0, 0);
   //   myGLCD.printNumI(888,CENTER,120);
        myGLCD.setBackColor(0, 0, 0);
       delay(150);
       myGLCD.setBackColor(0, 0, 0);
      Serial.print("Value:");
      Serial.println(inString.toInt());
      Serial.print("String: ");
      Serial.println(inString);
    //  myGLCD.print(inString, CENTER, 120);
    myGLCD.setColor(0, 255, 100);
   myGLCD.setFont(SixteenSegment64x96Num);
    myGLCD.setBackColor(50, 50, 50);
    
    if (inString.toInt() == 0)
    {
      CleanAreaScreen(); 
      myGLCD.drawBitmap(120, 100, 80, 80, tildezerov);
     // myGLCD.print("***",LEFT,80);
    }
    else {
      CleanAreaScreen();
      myGLCD.setColor(230, 230, 230); // set color of inString (visitors)
      myGLCD.setFont(Roboto64x96Num);
      myGLCD.printNumI(inString.toInt(),CENTER,80);
    }
      // clear the string for new input:
       myGLCD.setBackColor(0, 0, 0);
          delay(2050);
       inString = "";
      
      // myGLCD.print("", CENTER, 120);
      delay(2050);
       inString = "";
      //  myGLCD.clrScr();
    }
    portStatus(false);
  httpStatus(false);
  }
  

}

void DisconnectedBitmap() {
   myGLCD.drawBitmap(120, 100, 80, 80, finaldisco);
}

void CleanAreaScreen() { // just drawing some rectangles

      myGLCD.setColor(50, 50, 50); // set color of clean bg
      myGLCD.fillRect(30,60,280,190); // bg clean the three dots
}
