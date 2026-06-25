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
        public int Id { get; }
        public string Name { get; set; }
    }

    internal class User
    {

        public int Id { get;  }
        public string Name { get; set; }
    }


    internal class Repository<T>: IRepository<T>
    {

        public void Add(T entity)
        {
            if(entity.GetType() == typeof(Product)) 
            {

            }
        }


        public void Remove(T entity)
        {

        }

    }


   
}  



