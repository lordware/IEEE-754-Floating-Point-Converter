using System;

namespace ConsoleApp3
{
    class Program
    {
        static void clearConsole()
        {
            Console.Clear();
            string x = " ";
            Console.WriteLine("{0,40} Konverter für Fließkommazahlen", x);
            Console.WriteLine("\n");
        }
                  
        static void drawHud(IEEE x)
        {
            Console.WriteLine("                                            ----------------------------------------------");
            Console.WriteLine("                                               Sign Exponent           Mantissa           ");
            Console.WriteLine("Value:                                          {0}                                   ", x.Bin.Substring(0, 1).Replace("0", "+").Replace("1", "-"));
            Console.WriteLine("Encoded as:                                     {0}     {1}              {2}            ", Convert.ToInt32(x.Bin.Substring(0, 1), 2), Convert.ToInt32(x.Bin.Substring(1, 8), 2), Convert.ToInt32(x.Bin.Substring(9, 23), 2));
            Console.WriteLine("Binary:                                         {0}   {1}   {2}    ", x.Bin.Substring(0, 1), x.Bin.Substring(1, 8), x.Bin.Substring(9, 23));
            Console.WriteLine("                                            ----------------------------------------------\n\n");
        }
        static void Menu()
        {
            IEEE iEEE = new IEEE();
            clearConsole();

            Console.WriteLine("You entered (Decimal): ");
            iEEE.EnteredVal = Console.ReadLine();
            iEEE.EnteredVal = iEEE.EnteredVal.Replace(".", ",");
            clearConsole();
            iEEE.validateInput();
            iEEE.Calculate();
            drawHud(iEEE);

            Console.WriteLine("Decimal representation:                       {0}", iEEE.EnteredVal);
            Console.WriteLine("Value actually stored in float:               {0:G17}", iEEE.ActuallyVal);
            Console.WriteLine("Error due to conversion:                      {0}", iEEE.ErrorCon);
            Console.WriteLine("Binary representation:                        {0}", iEEE.Bin);
            Console.WriteLine("Hexadecimal Representation:                   {0}", iEEE.HexVal);

            Console.ReadKey();
            clearConsole();
            return;
        }
        static void Main(string[] args)
        {
            while (true)
            {
                Menu();
            }
        }
    }
}
