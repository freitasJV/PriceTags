using System.Globalization;

namespace PriceTags.Entities
{
    class ImportedProduct: Product
    {
        public double CustomsFee { get; set; }

        public ImportedProduct()
        {
        }

        public ImportedProduct(string name, double price, double customsFee) : base(name, price)
        {
            CustomsFee = customsFee;
        }

        public double TotalPrice()
        {
            return Price + CustomsFee;
        }

        public override string PriceTag()
        {
            return $"{Name} R${TotalPrice().ToString("F2", CultureInfo.InvariantCulture)} (Custos de importação: R${CustomsFee.ToString("F2", CultureInfo.InvariantCulture)})";
        }
    }
}
