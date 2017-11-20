namespace FitnessWebApi.DAL
{
    using System.Collections.Generic;

    public interface IFitnessRepository<T>
    {
        IEnumerable<T> GetAll(string orderBy);

        T GetById(int id);

        IEnumerable<T> GetAllContaining(string name, string orderBy);

        void AddEntity(T entity);

        void UpdateEntity(int id, T newEntity);

        void DeleteEntity(int id);

        void AddConnection(int onObjectId, int toObjectId);
    }
}
