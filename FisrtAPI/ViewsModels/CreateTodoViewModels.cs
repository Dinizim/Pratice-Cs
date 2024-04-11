using System.ComponentModel.DataAnnotations;

namespace FisrtAPI.ViewsModels;

public class CreateTodoViewModels
{
    [Required] 
    public string Title { get; set; }    
}
