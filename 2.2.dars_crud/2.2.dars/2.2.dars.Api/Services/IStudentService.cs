using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2._2.dars.Api.Models;

namespace _2._2.dars.Api.Services;

public interface IStudentService
{
    public Student AddStudent(Student student);
    public Student GetById(Guid studentId);
    public bool DeleteStudent(Guid studentId);
    public bool UpdateStudent(Student student);
    public List<Student> GetAllStudents();
}
