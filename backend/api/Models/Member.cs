using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace api.Models
{
    public class Member
    {
        public int MemberId  { get; set; }
        
        public string MemberName { get; set; } = string.Empty;
        
       
        public string MemberEmail { get; set; } = string.Empty;
        
        public string MemberPassword { get; set; } = string.Empty;
        

        public List<Note> Notes { get; set; }= new List<Note>();


    }
}