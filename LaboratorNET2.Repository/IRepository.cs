using System.Collections.Generic;

namespace LaboratorNET2.Repository
{
    public interface IRepository<T>
    {
        void Create(T creationModel);
        void Update(int id, T updateModel);
        void Delete(int id);
        T GetById(int id);
        IEnumerable<T> GetAll();
    }
}