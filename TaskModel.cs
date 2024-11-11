using System.ComponentModel.DataAnnotations;

namespace TaskManagerAPI;

public class TaskModel
{
    
    [Required]
    public string Title { get; set; } = null!;
    
    [Required]
    public string? Description { get; set; }

    [Required]
    public string Status { get; set; } = null!;
    
    [Required]
    public string Priority { get; set; } = null!;
}