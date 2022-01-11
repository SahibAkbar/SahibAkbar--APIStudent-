using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTables.Models
{
    public class Group
    {
        [Key]
        public int Id { get; set; }
        [MaxLength(30)]
        public string Name { get; set; }
        [MaxLength(30)]

        public DateTime CreatedDate { get; set; }

        public List<Student> Students { get; set; }

    }
}
