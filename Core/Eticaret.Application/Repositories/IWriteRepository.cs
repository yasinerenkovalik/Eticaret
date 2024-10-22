using Eticaret.Domain.Entities.Commen;

namespace Eticaret.Application.Repositories;

public interface IWriteRepository<T>:IRepository<T> where T:BaseEntity
{
  Task<bool> AddAsync(T entity);
  Task<bool> AddRanceAsync(List<T> entity);
  bool  Remove(T entity);
  bool RemoveRange(List<T> entities);
  Task<bool>  RemoveAsync(string id);
  bool Update(T entity);
  Task<int> SaveAsync();

}