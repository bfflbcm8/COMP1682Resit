using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using api.Data;
using api.Dtos.Note;
using api.Mappers;
using api.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace api.Controllers
{
    [Route("api/note")]
    [ApiController]
    public class NoteController : ControllerBase
    {
        private readonly ApplicationDBContext _context;

        public NoteController(ApplicationDBContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<IActionResult> GetAll()
        {
            var notes = await _context.Notes.ToListAsync();
            var noteDto = notes.Select(s => s.ToNoteDto());
            return Ok(noteDto);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetById([FromRoute] int id)
        {
            var note = await _context.Notes.FindAsync(id);
            if (note == null)
            {
                return NotFound();
            }
            return Ok(note.ToNoteDto());
        }

        [HttpPost]
        public async Task<IActionResult> Create([FromBody] CreateNoteRequestDto noteDto)
        {
            var noteModel = new Note
            {
                NoteTitle = noteDto.NoteTitle,
                NoteContent = noteDto.NoteContent,
                NoteDate = noteDto.NoteDate
            };

            await _context.Notes.AddAsync(noteModel);
            await _context.SaveChangesAsync();
            return CreatedAtAction(nameof(GetById), new { id = noteModel.NoteId }, noteModel.ToNoteDto());
        }


        [HttpPut("{id}")]
        public async Task<IActionResult> Update([FromRoute] int id, [FromBody] UpdateNoteRequestDto updateDto)
        {
            var noteModel = await _context.Notes.FirstOrDefaultAsync(x => x.NoteId == id);
            if (noteModel == null)
            {
                return NotFound();
            }
            noteModel.NoteTitle = updateDto.NoteTitle;
            noteModel.NoteContent = updateDto.NoteContent;
            noteModel.NoteDate = updateDto.NoteDate;

            if (noteModel.Member != null)
            {
                noteModel.Member.MemberName = updateDto.MemberName;
                noteModel.Member.MemberPassword = updateDto.MemberPassword;
            }

            await _context.SaveChangesAsync();

            return Ok(noteModel.ToNoteDto());
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> Delete([FromRoute] int id)
        {
            var noteModel = await _context.Notes.FirstOrDefaultAsync(x => x.NoteId == id);
            if (noteModel == null)
            {
                return NotFound();
            }

            _context.Notes.Remove(noteModel);
            await _context.SaveChangesAsync();
            return NoContent();
        }
    }
}
