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
            Repository<Product> repository
                = new Repository<Product>();

            var product = new Product();

            repository.Add(product);
         
        }

    }


    public class Product: IEntity
    {
        public int Id { get;  }
        

    }






    
}  



