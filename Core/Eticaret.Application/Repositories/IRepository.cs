using Eticaret.Domain.Entities.Commen;
using Microsoft.EntityFrameworkCore;

namespace Eticaret.Application.Repositories;

public interface IRepository<T> where T:BaseEntity
{
    DbSet<T> Table { get; }
}