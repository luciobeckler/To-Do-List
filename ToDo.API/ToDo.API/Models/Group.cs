namespace ToDo.API.Models
{
    public class Group
    {
        public int Id { get; set; }
        public string Titulo { get; set; }
        public string Cor { get; set; }
        public List<ToDoTask> Tasks { get; set; } = new List<ToDoTask>();
    }
}
