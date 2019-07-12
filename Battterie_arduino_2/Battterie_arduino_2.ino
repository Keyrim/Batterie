int16_t analogPrec[6] = {0, 0, 0, 0, 0, 0};
int16_t analog[6]= {0, 0, 0, 0, 0, 0} ;
int16_t compteur [6] = {0, 0, 0, 0, 0, 0};
int16_t activable[6] = {true,true,true,true,true,true};
int16_t activable2[6] = {true,true,true,true,true,true};
int16_t piezo, puissance , envoi ;
String message ;
int mess[6];
void setup() {
  Serial.begin(9600);
  while(!Serial.available());
}

void loop() {

for(int n = 0 ; n < 6 ; n ++){
  analog[n] = analogRead(n);
  if(analog[n] < 100) analog[n] = 0 ;
  if (analog[n] > analogPrec[n]) {
    activable[n] = true;

  }

  else if (analog[n] < analogPrec[n])
  {
    if (activable[n] && activable2[n] )
    {
      
      puissance = analog[n] << 2 ;
      envoi = puissance | n ;
      Serial.println(envoi);
      activable[n] = false;
      activable2[n] = false;
    }

  }
  
   
  if (analogPrec[n] == analog[n] )
  {
    compteur[n] ++ ; 
    if(compteur[n] == 70){
      compteur[n] = 0 ;
      activable2[n] = true;
    }
    
  }
  analogPrec[n] = analog[n] ;
  delay(1);
}

  
  delay(1);


}
