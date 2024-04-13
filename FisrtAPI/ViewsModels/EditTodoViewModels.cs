using System.ComponentModel.DataAnnotations;

namespace FirstAPI.ViewsModels;

public class EditTodoViewModels
{
    [Required]
    public string Title { get; set; }
    [Required]
    public bool Done { get; set; }
}
