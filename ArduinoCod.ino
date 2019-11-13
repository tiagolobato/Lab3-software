#include <Stepper.h>
#include <Ultrasonic.h>
 
const int stepsPerRevolution = 32; 
int contador = 100;
//Inicializa a biblioteca utilizando as portas de 8 a 11 para 
//ligacao ao motor 
Stepper myStepperAltura(stepsPerRevolution, 10,12,11,13); 
Stepper myStepperAngulo(stepsPerRevolution, 6,8,7,9); 
int controleManual = 0;
double anguloReferenciaDouble = 0;
double alturaReferenciaDouble = 0;
int stepAnguloTotal = 0;
int stepAlturaTotal = 0;
Ultrasonic ultrassom(4,3); 
long distancia;

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
  //myStepperAltura.step(-stepAlturaTotal);
  myStepperAngulo.step(-stepAnguloTotal);
  anguloReferenciaDouble = 0;
  stepAnguloTotal= 0;
  byte anguloInfo[2];
  anguloInfo[0] = 0;
  anguloInfo[1] = 0;
  
  Serial.write(anguloInfo,2);
}
//670
int contador2 = 0;
void loop() {
  
  distancia = ultrassom.Ranging(CM);// ultrassom.Ranging(CM) retorna a distancia em
                                     // centímetros(CM) ou polegadas(INC)
  //Serial.print(distancia); //imprime o valor da variável distancia

   
  double x = 5.7 ;
  byte sensor[2];
  byte anguloManual[2];
  anguloManual[0] = 6;
  if(controleManual==1){
    if(anguloReferenciaDouble>180 || anguloReferenciaDouble <-180){
      controleManual = 0;
    }
    else{
      myStepperAngulo.step(16);
      stepAnguloTotal = stepAnguloTotal + 16; 
      anguloReferenciaDouble = anguloReferenciaDouble + 2.8125;
      anguloManual[1] = (int)anguloReferenciaDouble;
      Serial.write(anguloManual,2);
      delay(20);
    }
    
    
  }
  if(controleManual==2){
    myStepperAngulo.step(-10); 
    delay(10);
  }
  if(controleManual==3){
    myStepperAltura.step(10); 
    delay(10);
  }
  if(controleManual==4){
    myStepperAltura.step(-10); 
    delay(10);
  }
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
      myStepperAngulo.step(stepAnguloInt); 
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
      myStepperAngulo.step(-stepAnguloInt); 
      //Serial.print(stepAngulo);
      stepAnguloTotal = stepAnguloTotal - stepAnguloInt;
      //Serial.print(stepAngulo);
     
      anguloReferenciaDouble = anguloReferenciaDouble + entrada[1];
      anguloInfo[1] = anguloReferenciaDouble;
      Serial.write(anguloInfo,2);
    } 
//Fim - Motor Angulo

//Inicio - Motor Altura
    if( tipoComponente == 1){
      controleManual = 0;
      double dStep = (entrada[1]/180.00000);
      double stepAltura = dStep*1024;
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
      double dStep = (entrada[1]/180.00000);
      double stepAltura = dStep*1024;
      int stepAlturaInt = stepAltura;
      byte alturaInfo[2];
      alturaInfo[0] = 5;
      int contador = 0;
      myStepperAltura.step(-stepAlturaInt); 
      stepAlturaTotal = stepAlturaTotal + stepAlturaInt;
      //Serial.print(stepAngulo);
     
      alturaReferenciaDouble = alturaReferenciaDouble + entrada[1];
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

//Inicio - Controle Manual
    if( tipoComponente == 6){
      //Serial.write(entrada,2); 
      //Serial.print(x);
      controleManual = entrada[1];
    }
//Fim - Controle Manual
    if( tipoComponente == 7){
      resetar();
    }
   
    //entrada[1] = Serial.readBytes(new byte[2],0);
            //retorna o que foi lido
  }
}