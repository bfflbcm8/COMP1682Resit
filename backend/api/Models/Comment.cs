using System;

namespace api.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; } = string.Empty;
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int NoteId { get; set; }
        public Note? Note { get; set; }  
        public int? MemberId { get; set; }
        public Member? Member { get; set; }
    }
}
