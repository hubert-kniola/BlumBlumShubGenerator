using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace BBSGen
{
    class Program
    {
        static void Main(string[] args)
        {
            int option = default;
            do
            {
                try
                {
                    Console.Write("-------\nBBS Generator\n1. Czyszczenie konsoli\n2. BBS Generator\nPodaj odpowiednia opcje: ");
                    option = Int32.Parse(Console.ReadLine());
                    switch (option)
                    {
                        case 0:
                            break;
                        case 1:
                            Console.Clear();
                            break;
                        case 2:
                            BlumBlumSnub.generatorBBS();
                            break;
                        default:
                            Console.WriteLine("Nie ma zadania o takim numerze!");
                            continue;
                    }
                }
                catch (FormatException e)
                {
                    Console.WriteLine("[Alert] Znak nie jest typu INT");
                    option = 3;
                }
                catch(IOException e)
                {
                    Console.WriteLine("[Alert]");
                }
            } while (option != 0);
            Console.ReadKey();
        }
    }
}
