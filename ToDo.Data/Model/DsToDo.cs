namespace ToDo.Data.Model
{
    public class DsToDo : ToDoEntity
    {
        public int Id { get; set; }
        public string  Title { get; set; }
        public bool Completed { get; set; }
    }
}
