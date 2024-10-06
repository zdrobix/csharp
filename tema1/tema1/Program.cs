//Cat timp nu este introdus caracterul '0', programul asteapta un caracter, si returneaza codul ASCII al acestuia
while (true)
{
	Console.WriteLine("Enter a character(0 to stop): ");
	char ch = Console.ReadKey().KeyChar;
	if (ch == '\n')
		continue; //Pentru a nu avea caracterul newline in buffer
	if (ch == '0')
	{	Console.WriteLine("\nAre you sure? Y/N");
		if (Console.ReadKey().KeyChar == 'Y')
			break;
		else Console.WriteLine("\nASCII: " + (int)(ch) + "\n");
	}

	//break; //Conditia de stop
	Console.WriteLine("\nASCII: " + (int)(ch) + "\n");
}





























/*
 *		De ce avem nevoie de matematica in programare??
 *		
 *		1) Matematica ofera o gandire structurata. Eu consider ca imi era imposibil sa invat info fara o baza solida 
 *		in matematica. 
 *		
 *		2) Fara matematica nu se inventau calculatoarele. Calculatorul are rolul de a face calcule, de acolo si numele. 
 *		
 *		3) In orice domeniu al informaticii se presupune folosirea numerelor. Personal consider ca ma ajuta mult faptul ca
 *		pot face unele calcule in minte si fluidizeaza mult procesul de codare. 
 *		
 *		
 */