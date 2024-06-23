using System;

namespace practicaExtra
{
    public class Program
    {
        public static void Main(string[] args)
        {
            int opcion;
            string password = "1234ASDF";
            string checkPassword;
            string filename;
            slotMachine sm = new slotMachine();

            do
            {
                Console.WriteLine("Select one of the options below");
                Console.WriteLine("1 Play");
                Console.WriteLine("2 Show prices");
                Console.WriteLine("3 Load prices");
                Console.WriteLine("4 Exit");

                opcion = int.Parse(Console.ReadLine());
                Console.Clear();

                switch (opcion)
                {
                    case 1:
                        sm.Play();
                        break;
                    case 2:
                        sm.showPrices();
                        break;
                    case 3:
                        Console.WriteLine("Please introduce your admin password");
                        checkPassword = Console.ReadLine();

                        if(checkPassword == password)
                        {
                            Console.WriteLine("Welcome admin!! Please introduce the file name: ");
                            filename = Console.ReadLine();
                            sm.loadPrizes(filename);
                        }
                        else
                        {
                            Console.WriteLine("The password is not correct");
                        }
                        break;
                    default:
                        Console.WriteLine("Please select one of the options");
                        break;
                }

            } while (opcion != 4);
        }
    }
}