namespace Application.Data.DataBaseContext;

// абстракция для работы с БД (Use Cases)
public interface IApplicationDbContext
{
    DbSet<Topic> Topics { get; }

    // обозначение наличие функционала сохранения данных (для абстракции)
    Task<int> SaveChangesAsync(CancellationToken ct);
}