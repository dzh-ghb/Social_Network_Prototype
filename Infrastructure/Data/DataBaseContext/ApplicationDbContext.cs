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
        // base.OnModelCreating(modelBuilder);

        // преобразование TopicId (значимый тип) в простой тип данных, который будет храниться в БД;
        // + обеспечение типобезопасности при работе с идентификаторами (работа только с Guid для TopicId)
        modelBuilder.Entity<Topic>()
            .Property(topic => topic.Id)
            .HasConversion(
                id => id.Value,
                value => TopicId.Of(value)
            );

        // определение порядка хранения полей из Location (значимый тип) в таблице топиков в БД
        modelBuilder.Entity<Topic>()
            .OwnsOne(topic => topic.Location, location =>
            {
                location.Property(l => l.City).HasColumnName("City");
                location.Property(l => l.Street).HasColumnName("Street");
            });
    }
}