namespace Infrastructure.Data.DataBaseContext;

// для подключения конкретной реализации БД через DI
public class ApplicationDbContext : DbContext, IApplicationDbContext
{
    public DbSet<Topic> Topics => Set<Topic>();

    public ApplicationDbContext(DbContextOptions options) : base(options)
    {
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        // указание приложению, откуда брать конфиги
        base.OnModelCreating(modelBuilder);

        modelBuilder.ApplyConfigurationsFromAssembly(
            Assembly.GetExecutingAssembly() // получение содержимого сборки через рефлексию
        );
    }
}