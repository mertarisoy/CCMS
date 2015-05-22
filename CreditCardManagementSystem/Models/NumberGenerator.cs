using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace CreditCardManagementSystem.Models
{
    public class NumberGenerator
    {

        private static NumberGenerator instance = new NumberGenerator();

        private NumberGenerator()
        {
        }

        public static NumberGenerator getInstance()
        {

            return instance;
        }

        public String generate()
        {
            Random rnd = new Random();
            string cardnumber = "";
            for (int i = 0; i < 16; i++)
            {
                cardnumber += Convert.ToString(rnd.Next(0, 10));
            }
            return cardnumber;
        }

    }
}