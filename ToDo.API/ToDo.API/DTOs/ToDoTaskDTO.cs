namespace ToDo.API.DTOs
{
    public class ToDoTaskDTO
    {
        public string Titulo { get; set; }
        public string? Descricao { get; set; }
        public string Status { get; set; }
        public string Prioridade { get; set; }
        public DateOnly? DataInicio { get; set; }
        public DateOnly? DataFim { get; set; }
        public int? GrupoId { get; set; }
    }
}
