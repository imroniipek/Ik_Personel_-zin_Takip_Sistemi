using Shared.Entities;

namespace Personel.Personel.Domain;

public class Department : BaseEntity
{
    public string Name { get; set; } = null!;

    public List<Personel> Personels { get; set; } = new();

    public int? ManagerId { get; set; }

    public Personel? Manager { get; set; }
}