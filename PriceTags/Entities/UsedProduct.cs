﻿using System;
using System.Globalization;

namespace PriceTags.Entities
{
    class UsedProduct : Product
    {
        public DateTime ManufactureDate { get; set; }

        public UsedProduct()
        {
        }

        public UsedProduct(string name, double price, DateTime manufactureDate) : base(name, price)
        {
            ManufactureDate = manufactureDate;
        }

        public override string PriceTag()
        {
            return $"{Name} (usado) R${Price.ToString("F2", CultureInfo.InvariantCulture)} (Data de fabricação: {ManufactureDate:dd/MM/yyyy})";
        }
    }
}
