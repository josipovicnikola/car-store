using System;
using System.Collections.Generic;
using System.Text;

namespace CarClassLibrary
{
    public class Car
    {
        public string Make { get; set; }
        public string Model { get; set; }
        public decimal Price { get; set; }

        public Car ()
        {
            Make = "";
            Model = "";
            Price = 0.00M;
        }

        public Car (string Make, string Model, decimal Price)
        {
            this.Make = Make;
            this.Model = Model;
            this.Price = Price;
        }

        public override string ToString()
        {
            string message = Make + " " + Model + " $ " + Price;
            return message;
        }
    }
}
