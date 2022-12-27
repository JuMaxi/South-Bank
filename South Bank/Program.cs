using System;
using System.Buffers;
using System.IO;

namespace South_Bank
{

    internal class Program
    {
        private static int PositionArray = 1;
        private static double[] CurrentAccount = new double[0];
        static void WriteScreenInitial()
        {
            WriteScreenBank();

            Console.WriteLine("Enter the option you want");
            Console.WriteLine("--------------------------------------");
            Console.WriteLine(" ");

            Console.WriteLine("1) Cash Deposit");
            Console.WriteLine("2) Cash out");
            Console.WriteLine("3) Balance");
            Console.WriteLine("4) Statement");
            Console.WriteLine("5) Exit");
            Console.Write("--> ");
        }
        static void WriteScreenBank()
        {
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine("| South Bank - The Best in the World |");
            Console.WriteLine("+------------------------------------+");
            Console.WriteLine(" ");
        }

        static double[] SalveNumber(double InsertUser)
        {
            double[] Operations = new double[PositionArray];

            Operations[PositionArray - 1] = InsertUser;

            for (int Position = 0; Position < (PositionArray - 1); Position++)
            {
                Operations[Position] = CurrentAccount[Position];

            }

            CurrentAccount = Operations;

            PositionArray = PositionArray + 1;

            return CurrentAccount;
        }
        static double ShowBalance()

        {
            double Sum = 0;

            for (int Position = 0; Position < (PositionArray - 1); Position++)
            {
                Sum = Sum + CurrentAccount[Position];
            }
            return Sum;
        }

        static void ShowStatement()
        {
            for (int Position = 0; Position < (PositionArray - 1); Position++)
            {
                if (CurrentAccount[Position] > 0)
                {
                    Console.WriteLine(CurrentAccount[Position] + " £ - Deposit");
                }
                else
                {
                    Console.WriteLine(CurrentAccount[Position] + " £ - Cash Out");
                }
            }
        }

        static void CreatFile(string NumberCA)
        {
            string Way = @"C:\Dev\" + NumberCA + ".txt";
            string[] Write = new string[PositionArray];
            
                for (int Position = 0; Position < PositionArray - 1; Position++)
                {
                    Write[Position] = Convert.ToString(CurrentAccount[Position]);
                }
                File.WriteAllLines(Way, Write);
            
        }
        static void ReadFile(string NumberCA)
        {
            string Way = @"C:\Dev\South Bank\" + NumberCA + ".txt";
            
            if (File.Exists(Way))
            {
                string[] ReadTxt = File.ReadAllLines(Way);
                double[] Read = new double[ReadTxt.Length];

                for (int Position = 0; Position < ReadTxt.Length-1; Position++)
                {
                  Read[Position] = Convert.ToDouble(ReadTxt[Position]);
                }
                CurrentAccount = Read;
                PositionArray = CurrentAccount.Length;
            }
        }
        static void Main(string[] args)
        {
            string Option = "0";

            Console.Write("Digite o numero da sua conta corrente: ");
            string NumberCA = Console.ReadLine();

            ReadFile(NumberCA);

            while (Option != "5")
            {
                CreatFile(NumberCA);

                WriteScreenInitial();

                Option = Console.ReadLine();
                Console.Clear();

                if (Option == "1")
                {
                    WriteScreenBank();

                    Console.WriteLine("Cash Deposit");
                    Console.WriteLine("-----------------------------");
                    Console.Write("How Much do you want to deposit? £: ");
                    string InsertUser = Console.ReadLine();
                    double Money = Convert.ToDouble(InsertUser);

                    SalveNumber(Money);

                    Console.WriteLine(InsertUser + " £ saved. Now you have " + ShowBalance() + " £.");
                    Console.WriteLine(" ");
                    Console.WriteLine("Enter any key to return.");

                    Console.ReadKey();
                    Console.Clear();

                }
                if (Option == "2")
                {
                    WriteScreenBank();

                    Console.WriteLine("Cash Out");
                    Console.WriteLine("-----------------------------");
                    Console.Write("How Much do you want to cash out? £: ");
                    string InsertUser = Console.ReadLine();
                    double Money = Convert.ToDouble(InsertUser);

                    if (Money > ShowBalance())
                    {
                        Console.WriteLine("You don`t have enough money for this cash out. Do you think are you a boss? You have just " + ShowBalance() + " £.");
                        Console.WriteLine(" ");
                        Console.WriteLine("Enter any key to return.");
                    }
                    else
                    {
                        SalveNumber(-Money);

                        Console.WriteLine("It's here your " + InsertUser + " £. Don't spend so much at the Maneco Tinhoso's Club.");
                        Console.WriteLine(" ");
                        Console.WriteLine("Enter any key to return.");
                    }

                    Console.ReadKey();
                    Console.Clear();

                }
                if (Option == "3")
                {
                    WriteScreenBank();

                    ShowBalance();

                    Console.WriteLine("How Much do I have? ");
                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("You have " + ShowBalance() + " £");
                    Console.WriteLine(" ");
                    Console.WriteLine("Enter any key to return.");

                    Console.ReadKey();
                    Console.Clear();

                }
                if (Option == "4")
                {
                    WriteScreenBank();

                    Console.WriteLine("Where was my cash? ");
                    Console.WriteLine("-----------------------------");

                    ShowStatement();

                    Console.WriteLine("-----------------------------");
                    Console.WriteLine("For this reason you have " + ShowBalance() + " £");
                    Console.WriteLine(" ");
                    Console.WriteLine("Enter any key to return.");

                    Console.ReadKey();
                    Console.Clear();
                }
            }
        }
    }
}
