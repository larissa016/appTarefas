namespace appTarefas.Models
{
    public class Tarefa
    {
        //Nome da chave primaria deve ser nome da classe + "Id"
        public int TarefaId { get; set; } // Id e a chave primaria 
        public string? Titulo { get; set; }
        public string? Descricao { get; set; }
        public bool Concluida { get; set; }

    }
}
