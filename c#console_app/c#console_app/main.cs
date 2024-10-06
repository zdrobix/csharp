using System;

Console.WriteLine("enter a number: ");
var input1 = Console.ReadLine();
Console.WriteLine("enter a number: ");
var input2 = Console.ReadLine();
int nr1, nr2;

try
{
	nr1 = int.Parse(input1);
	nr2 = int.Parse(input2);
}
catch { return; };

Console.WriteLine("[A] addition\n[M] multiplication\n[S] subtration\nEnter the option: ");

var option = Console.ReadLine();
if (option == "A" || option == "a")
	Console.WriteLine("\n" + nr1 + " + " + nr2 + " = " + (nr1 + nr2));
else if (option == "M" || option == "m")
	Console.WriteLine("\n" + nr1 + " * " + nr2 + " = " + (nr1 * nr2));
else if (option == "S" || option == "s")
	Console.WriteLine("\n" + nr1 + " - " + nr2 + " = " + (nr1 - nr2));
else Console.WriteLine("\ninvalid option");
