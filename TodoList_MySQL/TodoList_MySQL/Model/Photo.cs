using System.ComponentModel.DataAnnotations;

namespace TodoList_MySQL.Model
{
    public class Photo
    {
        [Key]
        public int Id { get; set; }
        public string Url { get; set; }
        public bool isMain { get; set; }
        public string PublicId { get; set; }
        public int MemberId { get; set; }
        public Member Member { get; set; }
    }
}
