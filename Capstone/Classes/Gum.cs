using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Capstone.Classes
{
    public class Gum : VendingMachineItems
    {
        public Gum(string name, decimal price)
        {
            Name = name;
            Price = price;
        }
        public override string ToString()
        {
            return "Chew Chew Yum!";
        }
    }
}
