using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Capstone.Classes
{
    public class VendingMachine
    {
        Dictionary<string, VendingMachineItems> vendingDictionary = new Dictionary<string, VendingMachineItems>();
        int saleCount = 0;
        public VendingMachine()
        {
            using (StreamReader sr = new StreamReader(@"C:\Users\snelson\team5-c-week4-pair-exercises\M1W4D4-c-capstone\etc\vendingmachine.csv"))
            {
                while (!sr.EndOfStream)
                {
                    string line = sr.ReadLine();
                    string[] lineArr = line.Split('|');
                    string itemName = lineArr[1];
                    decimal itemPrice = decimal.Parse(lineArr[2]);

                    if (line[0] == 'A')
                    {
                        Chip newChip = new Chip(itemName, itemPrice);
                        vendingDictionary.Add(lineArr[0], newChip);
                    }
                    if (line[0] == 'B')
                    {
                        Candy newCandy = new Candy(itemName, itemPrice);
                        vendingDictionary.Add(lineArr[0], newCandy);
                    }
                    if (line[0] == 'C')
                    {
                        Drink newDrink = new Drink(itemName, itemPrice);
                        vendingDictionary.Add(lineArr[0], newDrink);
                    }
                    if (line[0] == 'D')
                    {
                        Gum newGum = new Gum(itemName, itemPrice);
                        vendingDictionary.Add(lineArr[0], newGum);
                    }
                }
            }
        }
        public decimal Balance
        {
            get; set;
        }

        public int SaleCount(string slotNum)
        {
            saleCount = 5 - (vendingDictionary[slotNum].Quantity);
            return saleCount;
        }

        public int GetQuantity(string slotNum)
        {
            return vendingDictionary[slotNum].Quantity;
        }

        public void AddMoney(decimal amountToAdd)
        {

            Balance += amountToAdd;
            Console.WriteLine("Your current balance is: ${0:0.00}", Balance);
            Console.WriteLine();
        }

        public void SellItem(string slotNum)
        {
            vendingDictionary[slotNum].Quantity -= 1;

        }

        public bool MachineContains(string slotNum)
        {
            if (vendingDictionary.ContainsKey(slotNum))
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public string MachineProductName(string slotNum)
        {
            return vendingDictionary[slotNum].Name;
        }

        public decimal MachineProductPrice(string slotNum)
        {
            return vendingDictionary[slotNum].Price;
        }
        public string ToString(string slotNum)
        {
            return vendingDictionary[slotNum].ToString();
        }
    }
}
