using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace ToDo.API.Models
{
    public class ToDoTask
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public DateOnly? Data_inicio { get; set; }
        public DateOnly? Data_fim { get; set; }


        public int? GroupId { get; set; } 
        public Group? Grupo { get; set; }
    }
}
