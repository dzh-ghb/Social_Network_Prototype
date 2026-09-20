namespace Infrastructure.Data.Configurations;

// отдельная настройка идентификатора топика
public class TopicIdConfiguration : IEntityTypeConfiguration<Topic>
{
    public void Configure(EntityTypeBuilder<Topic> builder)
    {
        // преобразование TopicId (значимый тип) в простой тип данных, который будет храниться в БД;
        // + обеспечение типобезопасности при работе с идентификаторами (работа только с Guid для TopicId)
        builder.Property(topic => topic.Id)
            .HasConversion(
                id => id.Value,
                value => TopicId.Of(value)
            );
    }
}