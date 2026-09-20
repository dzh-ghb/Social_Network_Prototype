namespace Infrastructure.Data.Configurations;

// отдельная настройка поля местоположения на уровне топика
public class TopicLocationConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        // определение порядка хранения полей из Location (значимый тип) в таблице топиков в БД
        builder.OwnsOne(topic => topic.Location, location =>
            {
                location.Property(l => l.City).HasColumnName("City");
                location.Property(l => l.Street).HasColumnName("Street");
            });
    }
}