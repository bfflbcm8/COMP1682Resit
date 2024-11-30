using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Dtos.Note;
using api.Models;

namespace api.Mappers
{
    public static class NoteMappers
    {
        public static NoteDto ToNoteDto(this Note noteModel)
        {
            return new NoteDto
            {
                NoteId = noteModel.NoteId,
                NoteTitle = noteModel.NoteTitle,
                NoteContent = noteModel.NoteContent,
                NoteDate = noteModel.NoteDate,
                
            };
        }

        public static Note ToNoteFromCreateDTO(this CreateNoteRequestDto noteDto)
        {
            return new Note
            {
                
                NoteTitle = noteDto.NoteTitle,
                NoteContent = noteDto.NoteContent,
                NoteDate = noteDto.NoteDate,
                
            };
        }
    }
}