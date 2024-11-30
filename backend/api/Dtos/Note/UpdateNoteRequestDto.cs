namespace api.Dtos.Note
{
    public class UpdateNoteRequestDto
    {
        public int NoteId { get; set; }
        public string NoteTitle { get; set; } = string.Empty;  
        public string NoteContent { get; set; } = string.Empty;
        public DateTime NoteDate { get; set; } = DateTime.Now;
        public string MemberName { get; set; } = string.Empty;
        public string MemberPassword { get; set; } = string.Empty;
    }
}
