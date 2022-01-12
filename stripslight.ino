String readString;
#include <FastLED.h>
#define LED_PIN     7
#define NUM_LEDS    80
CRGB leds[NUM_LEDS];

void setup() {
  Serial.begin(9600);
  Serial.println("serial test 0021"); // so I can keep track of what is loaded
  FastLED.addLeds<WS2812, LED_PIN, GRB>(leds, NUM_LEDS);
   for(int i = 0; i <81 ;i++){
    leds[i] = CRGB(0,0,0);
     FastLED.show();
}
}

void loop() {

  while (Serial.available()) {
    delay(2);  //delay to allow byte to arrive in input buffer
    char c = Serial.read();
    readString += c;
  }

  if (readString.length() >0) {


   String lednum = readString.substring(0,readString.indexOf("#"));
   int lednumber = lednum.toInt();
   String redval =  readString.substring(readString.indexOf("#")+1 ,readString.indexOf(","));
   int redvalue =  redval.toInt();
   String greenval =  readString.substring(readString.indexOf(",")+1,readString.indexOf("@"));
   int greenvalue =  greenval.toInt();
   String blueval =  readString.substring(readString.indexOf("@") +1,readString.length());
   int bluevalue =  blueval.toInt();




    
    //Serial.println("red :" + redval);
   // Serial.println("green :" + greenvalue);
   // Serial.println("blue :" + bluevalue);
     
    
     leds[lednumber] = CRGB(redvalue, greenvalue, bluevalue);
     FastLED.show();
delay(10);
    readString="";
  }

  else{


 
  
    
  }

 
}
