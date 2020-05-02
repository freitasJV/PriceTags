using PriceTags.Entities;
using System;
using System.Collections.Generic;
using System.Globalization;

namespace PriceTags
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Product> list = new List<Product>();

            Console.Write("Digite o número de produtos: ");
            int n = int.Parse(Console.ReadLine());

            for (int i = 1; i <= n; i++)
            {
                Console.WriteLine($"Dados do produto #{i}:");
                Console.WriteLine("Tipo do produto:");
                bool valido = false;
                string tipo;
                do
                {
                    Console.Write("Digite c para Comum, u para usado ou i para importado: ");
                    tipo = Console.ReadLine();

                    if (tipo.ToUpper().Equals("C") || tipo.ToUpper().Equals("U") || tipo.ToUpper().Equals("I"))
                    {
                        valido = true;
                    }
                    else
                    {
                        Console.WriteLine("Escolha um tipo válido");
                    }
                } while (!valido);

                Console.Write("Nome: ");
                string name = Console.ReadLine();
                Console.Write("Preço: ");
                double price = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);

                if (tipo.ToUpper().Equals("U"))
                {
                    Console.Write("Data de fabricação (DD/MM/YYYY): ");
                    DateTime date = DateTime.Parse(Console.ReadLine());
                    list.Add(new UsedProduct(name, price, date));
                }

                else if (tipo.ToUpper().Equals("I"))
                {
                    Console.Write("Custos de importação: ");
                    double fee = double.Parse(Console.ReadLine(), CultureInfo.InvariantCulture);
                    list.Add(new ImportedProduct(name, price, fee));
                }

                else
                {
                    list.Add(new Product(name, price));
                }
            }

            Console.WriteLine();
            Console.WriteLine("Etiquetas:");

            foreach(Product p in list)
            {
                Console.WriteLine(p.PriceTag());
            }
        }
    }
}
