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


    internal interface IEntity
    {
        int Id { get; }
    }


    internal interface IRepository<T> where T: IEntity
    {
        void Add(T entity);
        void Remove(T entity);

    }

    internal class Product: IEntity
    {
        public int Id { get; }
        public string Name { get; set; }
    }

    internal class User: IEntity
    {

        public int Id { get;  }
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


    internal class UserRepository: IRepository<User>
    {
        public void Add(User user)
        {

        }


        public void Remove(User user)
        {

        }
    }
}  



