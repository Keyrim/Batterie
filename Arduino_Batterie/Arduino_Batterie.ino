bool envoyable = true ;
unsigned long debut ;
byte phase = 0 ;
int value = 0 ;
void setup() {
  Serial.begin(115200);

}

void loop() {

  
  int a0 = analogRead(0);
  if(a0 >10 )
  {
    if(phase == 0)
    {
      debut = millis();
      phase = 1 ;
      value = a0 ;
    }
    else if (phase == 1)
    {
      if(millis() <= debut + 100) 
      {
        if (a0 > value)value = a0;
      }
      else
      {
        if(value>100)Serial.println(value);        
        phase = 0 ;
        value = 0 ;
      }
      
    }
  }
  
  
}
