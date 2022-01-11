using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentTables.Data;
using StudentTables.Models;
using StudentTables.Models.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace StudentTables.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ControllerBase
    {
        private readonly AppDbContext _context;

        public StudentController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetStudent()
        {
            List<DtoStudent> dtoStudents = new List<DtoStudent>();
            foreach (var item in _context.Students.ToList())
            {
                DtoStudent dtoStudent = new DtoStudent();

                dtoStudent.Id = item.Id;
                dtoStudent.Name = item.Name;
                dtoStudent.Surname = item.Surname;
                dtoStudent.Age = item.Age;
                dtoStudent.Address = item.Address;
                dtoStudent.Phone = item.Phone;
                //dtoStudent.GroupId = item.GroupId;
                //dtoStudent.Group = _context.Groups.Select(g => new { g.Id, g.Name })
                //    .FirstOrDefault(pa => pa.Id == item.GroupId);

                dtoStudents.Add(dtoStudent);
            };

            return Ok(dtoStudents);
        }

        [HttpGet("{id}")]
        public IActionResult GetStudent(int? id)
        {
            if (id == null)
            {
                //return BadRequest();

                //ModelState.AddModelError("", "Error nese oluf!");
                //return StatusCode(StatusCodes.Status400BadRequest, ModelState);

                return StatusCode(StatusCodes.Status400BadRequest, "Payt dedee neyledineee?!");
            }

            Student student = _context.Students.Find(id);
            if (student == null)
            {
                ModelState.AddModelError("", "Error, Qaqa bacarmisan qurdalama!");
                return StatusCode(StatusCodes.Status404NotFound, ModelState);

                //return StatusCode(StatusCodes.Status400BadRequest, "Aee naqardin?!");
            }

            return Ok(student);
        }

        [HttpPost]
        public IActionResult CreateStudent(Student model)
        {
            if (ModelState.IsValid)
            {
                model.CreatedDate = DateTime.Now;
                _context.Students.Add(model);
                _context.SaveChanges();
                return Ok();
            }

            return BadRequest();
        }
    }
}
