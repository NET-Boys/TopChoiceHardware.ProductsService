using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TopChoiceHardware.Products.Domain.Commands
{
    public interface IGenericRepository
    {
        void Add<T>(T entity) where T : class;
        List<T> GetAll<T>() where T : class;
        void Update<T>(T entity) where T : class;
        void Delete<T>(T entity) where T : class;
        void DeleteById<T>(int id) where T : class;
        T GetById<T>(int id) where T : class;
    }
}
