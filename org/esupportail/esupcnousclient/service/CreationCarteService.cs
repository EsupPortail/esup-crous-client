using System;
using System.Text;
using System.IO;
using Cnous_ecriture_fournisseur;
using SpringCardPCSC;
using System.Configuration;

namespace EsupCnousClient
{

    class CreationCarteService
    {
        private static int SUCCES = 0;

        public static string[] readers;
        private static string cardReaderName = null;

        private static string keyFile = ConfigurationManager.AppSettings["keyFile"];
        private static string samReaderName = ConfigurationManager.AppSettings["samReaderName"];
        private static string csvFile = ConfigurationManager.AppSettings["csvFile"];

        public CreationCarteService() {

            keyFile = ConfigurationManager.AppSettings["keyFile"];

            readers = SCARD.Readers;
            if (readers != null)
            {
                foreach (String reader in readers)
                {
                    if (reader.Contains(samReaderName))
                    {
                        samReaderName = reader;
                        break;
                    }
                }
            }

        }

        public String[] getReaders()
        {
            return readers;
        }


        static void selectReader(Boolean isTest)
        {
            if (readers != null) {
                foreach (String reader in readers)
                {
                    SCardReader sCardReader = new SCardReader(reader);
                    if (!reader.Contains(samReaderName))
                    {
                        if (isTest || sCardReader.CardAvailable)
                        {
                            cardReaderName = reader;
                            return;
                        }
                    }
                }
            }
        }

        private static Boolean connectDll(Boolean test)
        {
            StringBuilder szErrorMessage = new StringBuilder("", 99);
            int resultActive = -1;
            if (cardReaderName != null)
            {
                try
                {
                    /*
                    FileStream testFile = new FileStream(keyFile, FileMode.Open);
                    testFile.Close();
                    */
                    resultActive = DLL_ECRITURE_FOURNISSEUR.active_with_calypso(samReaderName, "", cardReaderName, keyFile, szErrorMessage);
                    StringBuilder szErrorMessage2 = new StringBuilder("", 99);
                    StringBuilder szInitializeString = new StringBuilder("", 99);
                    int resultInit = DLL_ECRITURE_FOURNISSEUR.initialise(szInitializeString, szErrorMessage);
                    if (resultInit == SUCCES && resultActive == SUCCES)
                    {
                        return true;
                    }
                    else
                    {
                        if (!test)
                        {
                            Console.WriteLine("Initialisation dll echouée : Check ZDC");
                        }
                    }
                } catch(DllNotFoundException e)
                {
                    if(!test) Console.WriteLine(e.Message);
                }catch(FileNotFoundException e)
                {
                    if (!test) Console.WriteLine(e.Message);
                }

            }

            return false;
        }

        public Boolean testDll(Boolean test)
        {
            selectReader(true);
            try {
                return connectDll(test);
            }catch (Exception e)
            {
                return false;
            }
        }

        public String ecritureCarte(String mkTxtCardNum)
        {
            selectReader(false);
            connectDll(false);
            StringBuilder szNumCardString = new StringBuilder(mkTxtCardNum, 249);
            StringBuilder szErrorMessage = new StringBuilder("", 99);
            int res = DLL_ECRITURE_FOURNISSEUR.ecriture(szNumCardString, szErrorMessage, csvFile);
            if (res == SUCCES)
            {
                return szNumCardString.ToString();
            }
            else
            {
                return "false";
            }

        }

        public String lectureCarte()
        {
            selectReader(false);
            connectDll(false);
            StringBuilder szCardString = new StringBuilder("", 249);
            StringBuilder szErrorMessage = new StringBuilder("", 99);
            int res = DLL_ECRITURE_FOURNISSEUR.lecture(szCardString, szErrorMessage);
            if (res == SUCCES)
            {
                return szCardString.ToString();
            }
            else
            {
                return "false";
            }

        }
    }
}
