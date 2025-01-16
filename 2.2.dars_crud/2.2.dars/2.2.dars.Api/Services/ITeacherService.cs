using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2._2.dars.Api.Models;

namespace _2._2.dars.Api.Services;

public interface ITeacherService
{
    public Teacher AddTeacher(Teacher teacher);

    public Teacher GetById(Guid TeacherId);

    public bool UpdateTeacher(Teacher teacher);

    public bool DeleteById(Guid TeacherId);
    
    public List<Teacher> GetAllTeachers();

}
