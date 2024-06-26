namespace Backend.DTOs
{
    public class PostDto //Clase DTO que trae solo lo que necesecito
    {
        public int Id { get; set; }
        public int UserId { get; set; }
        public string? Title { get; set; }
        public string? Body { get; set; }
    }
}
