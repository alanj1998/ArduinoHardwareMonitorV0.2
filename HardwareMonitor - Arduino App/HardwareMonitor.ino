#include <Wire.h>
#include "rgb_lcd.h"
#include <Temboo.h>
#include <time.h>

//Initialise a string to hold data and the screen
String tempData = "";
rgb_lcd lcd;
int red = 0;
int green = 255;
int blue = 0;
int pageNo = 1;
int buttonState = 0;
const int buttonPin = 4;

//Setup the lcd and begin transmission
void setup() {
  // put your setup code here, to run once:
  lcd.begin(16, 2);
  lcd.setRGB(red,green,blue);
  pinMode(buttonPin,INPUT);
  Serial.begin(9600);
  Bridge.begin();
}

//Run Code
void loop() {
  buttonState = digitalRead(buttonPin);
    if (buttonState == HIGH){
      CallChange();
      delay(300);
     }
     else {
      if (pageNo == 1) {
        PrintPage1();
      }
    else {
      PrintPage2();
    }
     }
}

void CallChange() {
  if(pageNo == 1){
        pageNo = 2;
      }
      else {
        pageNo = 1;
      }
}

 void PrintPage1() {
 while (Serial.available()>0){
    lcd.setRGB(red,green,blue);
    char data = Serial.read();
    tempData = tempData + data;
    
    //Get GPU data that ends with a * (Library depenedent char)
    if (data == '*') {
      tempData.remove(tempData.length() -1, 1);
      lcd.setCursor(0,0);
      lcd.print("CPU Temp.: " + tempData + " " + char(223) + "C");
      tempData = "";
      }
    else if (data == 'D' || data == 'I' || data == 'S'){
        lcd.clear();
        lcd.setCursor(0,0);
        lcd.print("DISCONNECTED!");
        lcd.setRGB(255,0,0);
      }
    else if (data == '@') {
      tempData.remove(tempData.length() -1, 1);
      lcd.setCursor(0, 1);
      lcd.print("CPU Load.: " + tempData + "%");
      tempData = "";    
      }
    else if (data == '#' || data == '&'){
      tempData = "";
    }
  }
 }

 void PrintPage2() {
  while (Serial.available()>0){
    lcd.setRGB(red,green,blue);
    char data = Serial.read();
    tempData = tempData + data;
    
    //Get GPU data that ends with a * (Library depenedent char)
    if (data == '#') {
    tempData.remove(tempData.length() -1, 1);
    lcd.setCursor(0,0);
    lcd.print("RAM Load.: " + tempData + "%");
    tempData = "";
    }

    else if (data == 'D' || data == 'I' || data == 'S'){
        lcd.clear();
        lcd.setCursor(0,0);
        lcd.print("DISCONNECTED!");
        lcd.setRGB(255,0,0);
      }

    else if (data == '&') {
    tempData.remove(tempData.length() -1, 1);
    lcd.setCursor(0, 1);
    lcd.print("HDD Left.: " + tempData + "%");
    tempData = "";    
    }
    else if (data == '*' || data == '@'){
      tempData = "";
    }
 }
 }
