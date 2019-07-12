  

int analog = 0;
bool verif1[6] = {true,true,true,true,true,true} ;
int retour,piezzo,puissance;
int n = 0 , seuil = 50, compteur[6];

void setup() {
  Serial.begin(9600);

}

void loop() {

/*for(int i = 0; i < 5; i++){
  analog = analogRead(i);
  if(analog > 200 && verif1[i])
  {
    
    Serial.println(analog << 4 | i); ;
    verif1[i] = false ;
    compteur[i] = 0;
  }
  else 
  {
    compteur[i] ++ ;
    if(compteur[i] >= 10)verif1[i] = true;
    
  }
}*/
  
  delay(10);
  Serial.println(analogRead(0));








  
}
