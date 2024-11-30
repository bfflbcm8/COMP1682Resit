using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace api.Dtos.Note
{
    public class NoteDto
    {
        public int NoteId  { get; set; }
        public string NoteTitle { get; set; } =string.Empty;
        public string NoteContent { get; set; } =string.Empty;
        public DateTime NoteDate { get; set; } = DateTime.Now;
        
    }
}