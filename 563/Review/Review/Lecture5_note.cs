/*
Lecture 5 Array 

5.1 : Decalre an array and assin values to array elements


Array : list of data item have the same data type ;
        - if one data is int every element in the array are all integer => 
           we call them as integer array ;

           subscrpt = index ;


Declaring array :

           double[]sales; 
           sales = new[20]  or 

           double []sales = new double[20];


new operator : used to create object ;   [20] : 20 spearte elements ;
 				create different elemetns ;

Array element : each object 
subscript = index: position of the element 
  			array  staring fomr 0 -> "Off by one" : remeber to count from 0 


Assiging element in array :  sales[0]  = 2100;
getting the array element : WriteLine(sales[19]);		




Array as object in C# but not all the languages take array as object;

1. Declare the array ;
2. You have to intiliize it 
    default value  bool =false ; Numeric field = 0; Char field = null or \u000


Differnet ways to declare the array 

 1) int [] myScroes = new int[5]{99 , 100 ,59, 40 ,10}
 2) int [] myScroes = new int[]{99 , 100 ,59, 40 ,10}
 3) int [] myScroes = {99 , 100 ,59, 40 ,10}



5.2 : Access array elements

Length property : System.Array class
					array's length can get via array.Length 


					array + loop : <code>



5.3 : Search an array suing a loop

	1. array + loop : <code>  
	this is useful you want to show part of the array ;  
 
 foreach statement : used in array ; list element in array you want to print :

   *foreach (int _name in arrayName )
      WriteLine("{0}", _name.Tostring(""));

   you cant not change the value  its read only 
   and its shows all the array     

    2. array for each : <code> 


  *  search student who has grade 7
  this is sequential search (from beginning to the end );
  Parallel arrays : secon array to hold the corresponding data ;
  <code >

 using while loop to get maximum efficient 
 while( x < studentName.length && name = studentName[x]) ;
 
 when the input value is same from the   



5.4 : Use the Binary Serach(), sort(), and Reverse() methods;

Array.BinarySearch(): f ind the element in the array  
                       - no dubuplicated 


                       Array.BinarySEarch(array_name , input); 


Array.Sort(): sort an array element   ( lowst- > highets)  (alphatic order)
						Array.Sort(name_array);



Array.Reverse(): reverse the order of elements
					Array.Reverse(name_array);

using static System.Array() = to use BinarySearch(),Sort(),Reverse( )




5.5 use multidimensional arrays 

One -dimensional (single-dimensional array);

multidimenional array :  

double [,] sales = {{xx, xx,xx,xx},
					{xx, xx,xx,xx},
					{xx, xx,xx,xx}}

					<pic>

					