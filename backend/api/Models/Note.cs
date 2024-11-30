using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Note
    {
        public int NoteId { get; set; }
        public string NoteTitle { get; set; } = string.Empty; 
        public string NoteContent { get; set; } = string.Empty;
        public DateTime NoteDate { get; set; } = DateTime.Now;
        public int? MemberId { get; set; }
        // Navigation property
        public Member? Member { get; set; }
    }
}
