using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class UserInterface
    {
        public UserInterface(VendingMachine newMachine)
        {
            int i = 0;
            while (i == 0)
            {
                try
                {
                    int x = 0;
                    while (x == 0)
                    {
                        Console.WriteLine("[1] display items | [2] purchase | [3] sales report | [9] end program");
                        x = int.Parse(Console.ReadLine());
                        Console.WriteLine();

                        switch (x)
                        {
                            case 1:
                                x = 1;
                                break;
                            case 2:
                                x = 2;
                                break;
                            case 3:
                                x = 3;
                                break;
                            case 9:
                                x = 9;
                                break;
                            default:
                                Console.WriteLine("Invalid entry.  Try again");
                                x = 0;
                                break;
                        }
                        while (x == 1)
                        {
                            using (StreamReader sr = new StreamReader(@"C:\Users\snelson\team5-c-week4-pair-exercises\M1W4D4-c-capstone\etc\vendingmachine.csv"))
                            {
                                while (!sr.EndOfStream)
                                {
                                    string line = sr.ReadLine();
                                    string[] lineArr = line.Split('|');
                                    string slotNum = lineArr[0];
                                    Console.WriteLine(line + "   Amount remaining: " + newMachine.GetQuantity(slotNum) + "\n");
                                }
                            }
                            Console.WriteLine();
                            x = 0;
                        }
                        while (x == 2)
                        {
                            Console.WriteLine("[a] add money | [b] select item | [c] back to main menu");
                            string y = Console.ReadLine();
                            Console.WriteLine();
                            switch (y)
                            {
                                case "a":
                                    Console.WriteLine("How much would you like to add?");
                                    decimal moneyToAdd = decimal.Parse(Console.ReadLine());
                                    Console.WriteLine();
                                    newMachine.AddMoney(moneyToAdd);

                                    string directory = Environment.CurrentDirectory;
                                    string filename = "Log.txt";
                                    string fullPath = Path.Combine(directory, filename);
                                    using (StreamWriter sw = new StreamWriter(fullPath, true))
                                    {
                                        sw.WriteLine(DateTime.UtcNow + " Added money: $" + moneyToAdd.ToString("0.00") + "  $" + newMachine.Balance.ToString("0.00"));
                                    }


                                    break;
                                case "b":
                                    Console.WriteLine("Please enter a slot number");
                                    string userSlotNum = Console.ReadLine();
                                    Console.WriteLine();
                                    if (newMachine.MachineContains(userSlotNum))
                                    {
                                        if (newMachine.GetQuantity(userSlotNum) == 0)
                                        {
                                            Console.WriteLine("That item is sold out");
                                            break;
                                        }
                                        else if (newMachine.Balance < newMachine.MachineProductPrice(userSlotNum))
                                        {
                                            Console.WriteLine("Insufficient funds.  Please add money");
                                            break;
                                        }
                                        else
                                        {
                                            Console.WriteLine(newMachine.MachineProductName(userSlotNum) + ":    $" + newMachine.MachineProductPrice(userSlotNum));
                                            Console.WriteLine();
                                            Console.WriteLine("Would you like to complete your transaction? [y] or enter any other key to exit to purchase menu");
                                            string userAnswer = Console.ReadLine();
                                            Console.WriteLine();

                                            while (userAnswer == "y")
                                            {
                                                newMachine.Balance -= newMachine.MachineProductPrice(userSlotNum);
                                                newMachine.SellItem(userSlotNum);
                                                decimal change = newMachine.Balance;
                                                int quarters = 0;
                                                int dimes = 0;
                                                int nickels = 0;
                                                Console.WriteLine("Your change is: ${0}", change);
                                                while (change > 0.25m)
                                                {
                                                    quarters++;
                                                    change -= 0.25m;
                                                }
                                                while (change > 0.10m)
                                                {
                                                    dimes++;
                                                    change -= 0.10m;
                                                }
                                                while (change > 0.05m)
                                                {
                                                    nickels++;
                                                    change -= 0.05m;
                                                }
                                                Console.WriteLine($"({quarters}) quarter(s), ({dimes}) dime(s), and ({nickels}) nickel(s)");
                                                Console.WriteLine();

                                                userAnswer = "n";
                                                x = 0;

                                                Console.WriteLine(newMachine.ToString(userSlotNum));
                                                Console.WriteLine();


                                                string directory1 = Environment.CurrentDirectory;
                                                string filename2 = "Log.txt";
                                                string fullPath2 = Path.Combine(directory1, filename2);
                                                using (StreamWriter sw = new StreamWriter(fullPath2, true))
                                                {

                                                    sw.WriteLine(DateTime.UtcNow + " " + newMachine.MachineProductName(userSlotNum) + " " + userSlotNum + " $" + newMachine.MachineProductPrice(userSlotNum).ToString("0.00") + "  $" + newMachine.Balance.ToString("0.00"));
                                                }
                                                newMachine.Balance = 0;
                                            }
                                        }
                                        break;
                                    }
                                    else
                                    {
                                        Console.WriteLine("That slot number does not exist. Try again");
                                        Console.WriteLine();
                                        break;
                                    }
                                case "c":
                                    x = 0;
                                    Console.WriteLine();
                                    break;

                            }
                        }
                        while (x == 3)
                        {

                            string filename = $"salesreport_{DateTime.Now.ToString("dd-MM-yyyy_hh-mm-ss")}.txt";
                            string directory = Environment.CurrentDirectory;
                            string fullPath = Path.Combine(directory, filename);
                            using (StreamReader sr = new StreamReader(@"C:\Users\snelson\team5-c-week4-pair-exercises\M1W4D4-c-capstone\etc\vendingmachine.csv"))
                            using (StreamWriter sw = new StreamWriter(fullPath, true))
                            {
                                decimal totalSales = 0;

                                while (!sr.EndOfStream)
                                {
                                    string line = sr.ReadLine();
                                    string[] lineArr = line.Split('|');
                                    string slotNum = lineArr[0];
                                    int mySaleCount = newMachine.SaleCount(slotNum);

                                    sw.WriteLine(lineArr[1] + "|" + mySaleCount);
                                    totalSales = totalSales + (mySaleCount * newMachine.MachineProductPrice(slotNum));

                                }
                                sw.WriteLine();
                                sw.WriteLine("**Total Sales** ${0:0.00}", totalSales);
                                x = 0;
                            }
                            Console.WriteLine("Sales report generated");
                            Console.WriteLine();
                        }
                        while (x == 9)
                        {
                            Console.WriteLine("Are you sure you want to end the program? [y] or [n]");
                            string userAnswer = Console.ReadLine();

                            if (userAnswer == "y")
                            {
                                x = 6;
                            }
                            else
                            {
                                x = 0;
                            }
                        }

                    }
                    i = 1;
                }
                catch (Exception e)
                {
                    i = 0;
                    Console.WriteLine("Try Again");
                    Console.WriteLine();
                }

            }
        }

    }
}



