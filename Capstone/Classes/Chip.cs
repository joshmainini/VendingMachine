using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Chip : VendingMachineItems
    {

        public Chip(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return "Crunch Crunch Yum!";
        }


    }
}
