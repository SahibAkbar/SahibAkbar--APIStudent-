using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTables.Models
{
    public class Student
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]
        public string Surname { get; set; }
        public byte Age { get; set; }
        [MaxLength(250)]
        public string Address { get; set; }
        [MaxLength(30)]
        public string Phone { get; set; }
        public DateTime CreatedDate { get; set; }

        [ForeignKey("Group")]
        public int GroupId { get; set; }
        public Group Group { get; set; }

    }
}
