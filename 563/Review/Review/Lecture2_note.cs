/*
Lecture2  Using Data 

2.1 Decalre Variables

if data item is constatnt , you can not change the variable 

data type : int , double, decimal, char, string ,and bool 
ex)   int myAge = 29; 
variable name is myAge
datat type is int 
initial value is 29
initalized the valued with 29 


initalize :   int myAge = 25;
assigns   :   myAge = 50;v

decalare variable without initalizatoin : 

int myAge; 

but you can only use it once you assigne the value in it  




2.2 Display Variables values

double variableName = 6.18;
System.Console.WrtieLine(variaeName);


Display values :
WriteLine("My age is {0} years old ", myAge);


 Vaiable Alignment ;        
 WriteLine("{0, -8}{1, 8}", "Richard","Lee")
 WriteLine("{0, -8}{1, 8}", "Skyler","Bang") 
 WriteLine("{0, -8}{1, 8}", "Ed","JanmeRU")



2.3 Use intergral data type

Store the whole numbers 
you can only put _  not , 



2.4 Use floating-point data types

contains decimal positions
-flaot ,  up to 7 digit
-double , up to 15, or 16 ; most of time you use this 
-decimal , 28 or 29


put F => float
put D => double
put M => decimal
put E => exponent 
put C => currency?

fotmatting floating-point values :


  double num = 123;
            string numString;
            numString = num.ToString("F2");
            WriteLine(numString); /// 123.000;

            string numString2;
            numString2 = num.ToString("F3");
            WriteLine(numString2);


2.5 Use arithmetic opertors

arithmetic operators :  addition , subtraction , multiplicatoin , divisoin , and reamainder ; 

Shortcut arithmetic : 

a += a * b 

a = old a * b ; 

-= , *= , 

increment :
 someValue++ (prefix), someValue++ postfix:  somaValue = someValue + 1 ;
Decrement :
 somveValue-- , --someValue


 prefix :  ++a   : value of a chagnes 
 postfix :  a++   : dosent change


2.6 Use the bool data type

True or False ;

Comparison :

comapres ==   (* = is just assigne)
!= 



2.7 Desctibe numeric type conversion


x is int 
y is double 

z = x+y  is implicitly converts and become double;


double x = 5.73

int x => become 5 




2.8 use the char data type 

Char data type :  you cant use in arithmetic statmemnt 

char letter = 'A'; or  char letter = '\u0041'



2.9 use the string data type 

string : holds a series of characters ;

can compare  == and != ;
equal(), Comapre()and ComapareTo()
 


Substring():

string word = "word"
word.Substring(0,1) is "w";
word.Substring(0,2) is "wo";
word.Substring(0, word.Length) is "word";





2.10 Define named constatns 
  
constatns , such as pi 


2.11 Accept console input 

Convert Class :
userInput = ReadLine()
userInputPrice = Convert.ToDouble(UserInput)


Parse() Methode :

userInputPrice = double.Parse(UserInput)
userInputPrice = double.Parse(ReadLine)
score = int.Parse(ReadLine)



