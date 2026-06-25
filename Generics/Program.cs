using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    internal class Program
    {
        static void Main(string[] args)
        {




        }

    }



    internal interface IRepository<T>
    {
        void Add(T entity);
        void Remove(T entity);

    }

    internal class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }


    internal class ProductRepository: IRepository<Product>
    {

        public void Add(Product product)
        {

        }


        public void Remove(Product product)
        {

        }

    }
}  



