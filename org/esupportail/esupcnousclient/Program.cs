using System;

namespace EsupCnousClient
{
    internal sealed class Program
    {
        private static CreationCarteService creationCarteService = new CreationCarteService();

        private static String action = null;

        static void Main(string[] args)
        {

            if(args.Length > 0) {
                action = Environment.GetCommandLineArgs()[1];
            }

            if (action == "--test" || action == "-t")
            {
                Console.WriteLine(creationCarteService.testDll(true).ToString().ToLower());
            } else 
            if (action == "--lecture" || action == "-l")
            {
                Console.WriteLine(creationCarteService.lectureCarte());
            } else
            if (action == "--ecriture" || action == "-e")
            {
                if (Environment.GetCommandLineArgs().Length > 2)
                {
                    String param = Environment.GetCommandLineArgs()[2];
                    Console.WriteLine(creationCarteService.ecritureCarte(param));
                }
                else
                {
                    Console.WriteLine("numCard empty (-t <numCard>)");
                }
            }
            else
            {
                if (creationCarteService.testDll(false))
                {
                    Console.WriteLine("Creation carte CROUS : Statut OK");
                    Console.WriteLine("");
                    Console.WriteLine("-l , --lecture              : lecture de la carte (false = ERROR)");
                    Console.WriteLine("-e , --ecriture \"<num carte>\" : ecriture de la carte");
                    Console.WriteLine("-t , --test : test du module CROUS (true = OK, false = KO)");
                }
                else
                {
                    Console.WriteLine("Creation carte CROUS : Statut KO");
                    Console.WriteLine("");

                    if (creationCarteService.getReaders() != null)
                    {
                        Console.WriteLine("Problème de chargement DLL");
                    }
                    else
                    {
                        Console.WriteLine("Problème de clé SAM");
                    }
                }
            }
        }
    }
}
