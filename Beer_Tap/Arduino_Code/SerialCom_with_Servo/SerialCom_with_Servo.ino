#include <Servo.h>
Servo myServo;

#define PIN_SERVO (1)
const int BUTTON_PIN = 7;
int buttonState = 0;
int closedPosition = 2.0;
int maxOpen = 25;
boolean amIOpen = false;
String amount;

 
void SetStrokePerc(float strokePercentage)
{
  if ( strokePercentage >= 1.0 && strokePercentage <= 99.0 )
  {
    int usec = 1000 + strokePercentage * ( 2000 - 1000 ) / 100.0 ;
    myServo.writeMicroseconds(usec);
  }
}

void SetStrokeMM(int strokeReq,int strokeMax)
{
  SetStrokePerc( ((float)strokeReq) / strokeMax );
}
 
void setup()
{
  Serial.begin(9600);

  pinMode(BUTTON_PIN, INPUT_PULLUP);
  myServo.attach(PIN_SERVO);
  SetStrokePerc(closedPosition); 

}

void loop()
{

  if(Serial.available()){
    amount = Serial.readString(); //gets user's amount from serial buffer

    Serial.println("Time to pour");
    for ( int i = closedPosition; i < maxOpen; i += d ) //Opens tap
    {
      SetStrokePerc(i);
      delay(delayMS);
      amIOpen = true;

    }//end for

    delay(amount.toInt() * 1000); //Waits the amount of time depending on size from input

    for ( int i = maxOpen ; i > closedPosition; i -= d ) //closes tap
      {
        SetStrokePerc(i);
        delay(delayMS);
        amIOpen = false;
      }//end for
  
  } //end if

  /*
  buttonState = digitalRead(BUTTON_PIN);
  int d = 1;
  int delayMS = 75;
  */
  
 /*
  if (buttonState == LOW)
  {
    Serial.println("button is pressed");
    for ( int i = closedPosition; i < maxOpen; i += d )
    {
      SetStrokePerc(i);
      delay(delayMS);
      amIOpen = true;

    }//end for
    

  }//end if

   //set back to closed position
   if(buttonState == HIGH && amIOpen)
   {
      for ( int i = maxOpen ; i > closedPosition; i -= d )
      {
        SetStrokePerc(i);
        delay(delayMS);
        amIOpen = false;
      }//end for
   }//end if
   */


  
}//end loop()
