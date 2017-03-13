using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using IssueTracker.Models.Enums;

namespace IssueTracker.Models
{
    public class Issue
    {
        [Key]
        public int Id { get; set; }

        public string Name { get; set; }

        public Priority Priority { get; set; }

        public Status Status { get; set; }

        public DateTime CreationDate { get; set; }

        [ForeignKey("Author")]
        public int AuthorId { get; set; }

        public virtual User Author { get; set; }
    }
}
