using Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Application.Data.DataBaseContext;

// абстракция для работы с БД (Use Cases)
public interface IApplicationDbContext
{
    DbSet<Topic> Topics { get; }
}