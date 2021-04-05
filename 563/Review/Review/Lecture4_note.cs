
/*
Lecture 4


3 Loops methodes 
using it depdend on the problem / developer 



Looping allow program to do reapeat tasks based on Boolean expression.

Loop body :  block of stament in looping structure 

			reulst is true : keep looping
			result in false :  exit the loop  

iteration =  1 loop 

<pic > 



4.1  Create loops unsing the while Statmenet 


while :

while loop = looping until the some condition is TRUE ;  as soon as the conidion beceom false exit the loop


infinite loop :  you make silly mistake and become never end the loop; 
 1. loop control variable should initlized;
 2. loop control variable must be tsetd ;
 3. body of the llop must take some action that alters the value of the loop control variable ;

<code> 


becareful where is the variable ?    begining / in the end ? 
<pic2 >

definite loop  :  loop that has nubmer of iteration is already set ;
indefinite loop : user input will end the loop;
sentinel value : value such as Yes or No by user;s input ;  every iteration it will ask user to continue


 

4.2  Create loops suing the for statement 


usually use for the defnite loops , 
using step value ; 
this make the program shorter than while loop

iniitailizing , testing , updating ;
variables only exist in the loop;

multiple line from do-while loop  => one line to the for loop;
most commonly used loop ;

<pic> <pic>

3 things in one line in for loop ,




4.3 Create (do- while )loops using the do staement 

do loop 

it will always enter the loop without testing 

while loop and for loop are pre-test loops =control variable is tested before the loop body excited;
do-while loop is post-test loop = control variable is tested after the loop body excuted;

<code > 
do-while loop will do (extue ) without test at least first time 


4.4 Use nested loops


inner loop and outer loop (similiar wirh if )
* important : inner loop has to be insde the outer loop 
               loops will never overlap

               <pic>

<code>




4.5 Accumulated totals 

Garbarge value = unknown value ; it happens when you dont initalize ;


4.6 Understand how to improve loop performance 

consider the order of evaluation
do ++Value not value++
loop fusion,  putting two loops together in one evaultion

++X and X++ are same but ++X is faster  


while loop = loop excite when the value is ture 
for loop = loop for if you know how many iteratoin
do-while loop = check the bottom of the loop after one repetition 



