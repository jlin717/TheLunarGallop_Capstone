namespace ZodiacAPI.Models;

public class UserProfile
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;
    public int BirthYear { get; set; } 
    public string? AssignedSign { get; set; } //I will calculate this later on
}