#include <Stepper.h>
#include <Ultrasonic.h>
 
const int stepsPerRevolution = 32; 
int contador = 100;
//Inicializa a biblioteca utilizando as portas de 8 a 11 para 
//ligacao ao motor 
Stepper myStepperAngulo(stepsPerRevolution, 10,12,11,13); 
Stepper myStepperAltura(stepsPerRevolution,6,8,7,9); 
//Stepper myStepperAngulo(stepsPerRevolution, 10,12,11,13); 
//Stepper myStepperAltura(stepsPerRevolution, 6,8,7,9); 
int controleManual = 0;
double anguloReferenciaDouble = 0;
double alturaReferenciaDouble = 0;
int stepAnguloTotal = 0;
int stepAlturaTotal = 0;
Ultrasonic ultrassom(5,4); 
long distancia;
int stepDistancia = 600;
int stepAlturaMaxima = 40;
int sensorLigado = 0;
int menorDistanciaBuscar = 0;

void setup() {
  // put your setup code here, to run once:
Serial.begin(9600);
pinMode(2,OUTPUT);
controleManual = 0;
anguloReferenciaDouble = 0;
alturaReferenciaDouble = 0;

myStepperAngulo.setSpeed(100);
myStepperAltura.setSpeed(1000);
stepAnguloTotal = 0;
stepAlturaTotal = 0;
}
void resetar(){
  myStepperAltura.step(-stepAlturaTotal);
  myStepperAngulo.step(stepAnguloTotal);
  anguloReferenciaDouble = 0;
  stepAnguloTotal= 0;
  byte anguloInfo[2];
  anguloInfo[0] = 0;
  anguloInfo[1] = 0;
  alturaReferenciaDouble = 0;
  stepAlturaTotal= 0;
  byte alturaoInfo[2];
  alturaoInfo[0] = 1;
  alturaoInfo[1] = 0;
  
  Serial.write(anguloInfo,2);
  delay(50);
  Serial.write(alturaoInfo,2);
}
void buscar(){
  byte alturaInfo[2];
  
  long distanciaAuto = ultrassom.Ranging(CM);
  int stepAlturaInt = stepDistancia*distancia;
  alturaInfo[0] = 1;
  myStepperAltura.step(stepAlturaInt); 
  delay(1000);
  myStepperAltura.step(-stepAlturaInt); 
  //stepAlturaTotal = stepAlturaTotal + stepAlturaInt;
      //Serial.print(stepAngulo);
     
 // alturaReferenciaDouble = alturaReferenciaDouble + distanciaAuto;
  //alturaInfo[1] = alturaReferenciaDouble;
  //Serial.write(alturaInfo,2);

}
int mapear(){
  resetar();
  long vetorDistanciaIda[128];
  long vetorDistanciaVolta[128];
  long menorDistancia = 100;
  int menorIndice = 0;
  long distanciaMap;
  long media;
  for(int i = 0;i<128;i++){
    distanciaMap = ultrassom.Ranging(CM);
    vetorDistanciaIda[i] = distanciaMap;
    myStepperAngulo.step(-8);
    delay(50);
  }
  for(int i = 127;i>=0;i--){
    distanciaMap = ultrassom.Ranging(CM);
    vetorDistanciaVolta[i] = distanciaMap;
    myStepperAngulo.step(8);
    delay(50);
  }
  for(int i = 0;i<128;i++){
    media = (vetorDistanciaVolta[i] + vetorDistanciaIda[i])/2;
    if(media<menorDistancia){
      menorDistancia = media;
      menorIndice = i;
    }
  }
  menorDistanciaBuscar = menorDistancia;
  return menorIndice*8;
}
//670
int contador2 = 0;
long maxValor = 0;
int maxIndex = 0;
int jafoi = 0;
void loop() {
  if(sensorLigado == 1){
    byte sensorSaida[2];
    sensorSaida[0] = 3;
    
    distancia = ultrassom.Ranging(CM);// ultrassom.Ranging(CM) retorna a distancia em
                                       // centímetros(CM) ou polegadas(INC)
                                       
    sensorSaida[1]= distancia; 
    Serial.write(sensorSaida,2);  
  }
 

  
 
  
  
  //int stepAutomatico = distancia*stepDistancia;
  //myStepperAngulo.step(1000);                                 
  
   
  double x = 5.7 ;
  byte sensor[2];
  byte anguloManual[2];
  byte alturaManual[2];
  anguloManual[0] = 6;
  alturaManual[0] = 6;
  if(controleManual==1){
    if(stepAlturaTotal - stepDistancia/2 <0 ){
      controleManual = 0;
      alturaManual[0] = 6;
      alturaManual[1] = 1;
      Serial.write(alturaManual,2);
      delay(100);
    }
    else{
      myStepperAltura.step(-stepDistancia/2);
      stepAlturaTotal = stepAlturaTotal - stepDistancia/2; 
      alturaReferenciaDouble = alturaReferenciaDouble - 0.5;
      alturaManual[0] = 1;
      alturaManual[1] = (int)alturaReferenciaDouble;
      Serial.write(alturaManual,2);
      delay(100);
    }
    
    
  }
  if(controleManual==2){
    if(stepAnguloTotal - 16 <0 ){
      controleManual = 0;
      anguloManual[0] = 6;
      anguloManual[1] = 0;
      Serial.write(anguloManual,2);
      delay(100);
    }
    else{
      myStepperAngulo.step(16);
      stepAnguloTotal = stepAnguloTotal - 16; 
      anguloReferenciaDouble = anguloReferenciaDouble - 2.8125;
      anguloManual[0] = 0;
      anguloManual[1] = (int)anguloReferenciaDouble;
      Serial.write(anguloManual,2);
      delay(100);
    }
  }
  if(controleManual==3){
    if((stepAlturaTotal + stepDistancia/2) >30000 ){
      controleManual = 0;
      alturaManual[0] = 6;
      alturaManual[1] = 1;
      Serial.write(alturaManual,2);
      delay(100);
    }
    else{
      myStepperAltura.step(stepDistancia/2);
      stepAlturaTotal = stepAlturaTotal + stepDistancia/2; 
      alturaReferenciaDouble = alturaReferenciaDouble + 0.5;
      alturaManual[0] = 1;
      alturaManual[1] = (int)alturaReferenciaDouble;
      Serial.write(alturaManual,2);
      delay(100);
    }
  }
  if(controleManual==4){
    if(stepAnguloTotal + 16 >1024 ){
      controleManual = 0;
      anguloManual[0] = 6;
      anguloManual[1] = 0;
      Serial.write(anguloManual,2);
      delay(100);
    }
    else{
      myStepperAngulo.step(-16);
      stepAnguloTotal = stepAnguloTotal + 16; 
      anguloReferenciaDouble = anguloReferenciaDouble + 2.8125;
      anguloManual[0] = 0;
      anguloManual[1] = (int)anguloReferenciaDouble;
      Serial.write(anguloManual,2);
      delay(100);
    }
  }
  delay(100);
  //Serial.print(stepAngulo);
  
  if(Serial.available())        //se algum dado disponível
  {
    byte entrada[2];
    Serial.readBytes(entrada, 2);
    int tipoComponente = (int)entrada[0];
 
 //Inicio - Motor Angulo
    if( tipoComponente == 0){
      controleManual = 0;
      double dStep = (entrada[1]/180.00000);
      double stepAngulo = dStep*1024;
      int stepAnguloInt = stepAngulo;
      byte anguloInfo[2];
      anguloInfo[0] = 0;
      int contador = 0;
      myStepperAngulo.step(-stepAnguloInt); 
      stepAnguloTotal = stepAnguloTotal + stepAnguloInt;
      //Serial.print(stepAngulo);
     
      anguloReferenciaDouble = anguloReferenciaDouble + entrada[1];
  
      anguloInfo[1] = anguloReferenciaDouble;
      Serial.write(anguloInfo,2);
      
    }
    if( tipoComponente == 4){
      controleManual = 0;
      double dStep = (entrada[1]/180.00000);
      double stepAngulo = dStep*1024;
      int stepAnguloInt = stepAngulo;
      byte anguloInfo[2];
      anguloInfo[0] = 4;
      int contador = 0;
      myStepperAngulo.step(stepAnguloInt); 
      //Serial.print(stepAngulo);
      stepAnguloTotal = stepAnguloTotal - stepAnguloInt;
      //Serial.print(stepAngulo);
     
      anguloReferenciaDouble = anguloReferenciaDouble - entrada[1];

      anguloInfo[1] = anguloReferenciaDouble;
      Serial.write(anguloInfo,2);
    } 
//Fim - Motor Angulo

//Inicio - Motor Altura
    if( tipoComponente == 1){
      controleManual = 0;
      double stepAltura = entrada[1]*stepDistancia;
      int stepAlturaInt = stepAltura;
      byte alturaInfo[2];
      alturaInfo[0] = 1;
      int contador = 0;
      myStepperAltura.step(stepAlturaInt); 
      stepAlturaTotal = stepAlturaTotal + stepAlturaInt;
      //Serial.print(stepAngulo);
     
      alturaReferenciaDouble = alturaReferenciaDouble + entrada[1];
      alturaInfo[1] = alturaReferenciaDouble;
      Serial.write(alturaInfo,2);
    }
    if( tipoComponente == 5){
      controleManual = 0;
      double stepAltura = entrada[1]*stepDistancia;
      int stepAlturaInt = stepAltura;
      byte alturaInfo[2];
      alturaInfo[0] = 5;
      int contador = 0;
      myStepperAltura.step(-stepAlturaInt); 
      stepAlturaTotal = stepAlturaTotal - stepAlturaInt;
      //Serial.print(stepAngulo);
     
      alturaReferenciaDouble = alturaReferenciaDouble - entrada[1];
      alturaInfo[1] = alturaReferenciaDouble;
      Serial.write(alturaInfo,2);
    } 
//Fim - Motor Altura

//Inicio - Ima
    if( tipoComponente == 2){
      controleManual = 0;
      byte saidaIma[2]; 
      saidaIma[0] = 2;
      if(entrada[1]==1){
        saidaIma[1] = 0;
        digitalWrite(2,HIGH);
        Serial.write(saidaIma,2); 
      }
      if(entrada[1]==0){
        saidaIma[1] = 1;
        digitalWrite(2,LOW);
        Serial.write(saidaIma,2); 
      }
      //Serial.print(x);

    }
//Fim - Ima
//Inicio - sensor automatico
    if( tipoComponente == 3){
      if(entrada[1]==1){
        sensorLigado = 1;
      }
      else if(entrada[1]==0){
        sensorLigado = 0;
      }else{
        /*
        distancia = ultrassom.Ranging(CM);
        int stepAutomatico = distancia*stepDistancia;
        myStepperAltura.step(stepAutomatico);
        
        controleManual = 0;
        byte alturaInfo[2];
        alturaInfo[0] = 1;
        int contador = 0;
        stepAlturaTotal = stepAlturaTotal + stepAutomatico;
        //Serial.print(stepAngulo);
       
        alturaReferenciaDouble = alturaReferenciaDouble + distancia;
        alturaInfo[1] = alturaReferenciaDouble;
        Serial.write(alturaInfo,2);
        */
      }
      
      
    }
   
//Fim - sensor automatico


//Inicio - Controle Manual
    if( tipoComponente == 6){
      //Serial.write(entrada,2); 
      //Serial.print(x);
      controleManual = entrada[1];
    }
//Fim - Controle Manual
    if( tipoComponente == 7){
      if(entrada[1] == 0){
        resetar();
      }
      if(entrada[1]==1){
        buscar();
      }
      if(entrada[1]==2){
        myStepperAngulo.step(-mapear());
        digitalWrite(2,HIGH);
        delay(500);
        int stepAlturaInt = stepDistancia*menorDistanciaBuscar;
        myStepperAltura.step(stepAlturaInt); 
        delay(1000);
        myStepperAltura.step(-stepAlturaInt); 
       // buscar();
        digitalWrite(2,LOW);
      }
      
    }
   
    //entrada[1] = Serial.readBytes(new byte[2],0);
            //retorna o que foi lido
  }
}