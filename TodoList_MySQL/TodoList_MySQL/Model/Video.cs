using System.ComponentModel.DataAnnotations;

namespace TodoList_MySQL.Model
{
    public class Video
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public string PublicId { get; set; }
    }
}
