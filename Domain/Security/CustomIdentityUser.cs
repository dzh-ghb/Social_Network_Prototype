using Microsoft.AspNetCore.Identity;

namespace Domain.Security;

// модель юзера (доп. поля для AspNetUsers)
public class CustomIdentityUser : IdentityUser
{
    // для использования класса/структуры/записи "человек" необходимо создавать ValueObject
    public string FullName { get; set; } = default!;
    public string About { get; set; } = default!;
}