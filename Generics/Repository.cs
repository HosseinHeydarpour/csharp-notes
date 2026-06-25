using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Generics
{
    public interface IEntity {
        int Id { get; }

    }



    // What every type we use as T -> that type has to impelement IEntity interface
    internal class Repository<T> where T : IEntity
    {
        private List<T> values = new List<T>();

        public void Add(T entity) 
        {
           values.Add(entity);
        }
    }
}}
