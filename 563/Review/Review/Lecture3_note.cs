
/*
Lecture 3 


3.1 Understand logic- planning tools and decision making 


 3 ways of logic- planning 

 Pseudocode :  with plain english statement to plan the logic 
 Flowchar : each step with arrow  indicates the different types of instructions 
 Sequence structure : step by step 


<pic>
 Decision structure : program progress by the result of the choice ?  

 						its like one way or mulitple routre to the end of the goal 




3.2 Make decisions using if statments 

if statement :  used to make a signle -alternative decision 


if(condition)
{what to do }


Nested if :  decision strucutres contained within antoehr. 
               * if an outer level if is false then inside if will be ignored. 




<pic> and <code>

* important  that  in the condition  if()  you always use == two equal sign :
     num = high  :  assign "high" in th num variable ;
     num == high : compare num and high value 

3.3 Make decision using if-else

dual -alternative decisions :   have two possible resutlign actions 

 two actions upon the result of the if condition :  true ? or false : both will result in dieffrent actions 

 <pic >  <code>


3.4 use compound expressions in if statements 

you can combine mutiple decision in to a single if statment :

AND : &&  determine weather both fo the condition is ture :  both have to be true
OR : || determiend weather one of the condition is ture  : one of the conditoin is true 
<pic> <pic>

 you can combine && and || together in one expression,  morelikly && will prcess first 
 so you have to use    ( a || b) && c 



3.5 Make decisions using switch statements 

Switch structure : tests a single variable against a series of exact mathces 

switch  :  
case    : follow by one of the possible vaoue that equal to switch expresssion
break   :  terminates a switch 
default :

<code>



3.6 use the conditional operator 


testExpression ? trueResult : falseResult ;

WriteLine((testScore >= 60)) ? "pass" : "Fail" );
=> if the tesscore is over 60 => pass 

biggerNum = (a >b ) ? a:b
=> bigger number comesout




3.7 Use the NOT operato

 !=  not same 

3.8 Avodi common errors when making decisions 

Rangecheck ; make sure your statment range is speicified ranged   
