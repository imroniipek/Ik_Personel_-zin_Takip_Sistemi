namespace Shared.Dtos;

public record PersonelInfoDto
{
    public int PersonelId { get; set; }
    
    public DateOnly HireDate { get; set; }
}