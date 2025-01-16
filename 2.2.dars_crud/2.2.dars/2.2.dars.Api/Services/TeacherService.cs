using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _2._2.dars.Api.Models;

namespace _2._2.dars.Api.Services;

public class TeacherService : ITeacherService
{
    private List<Teacher> _teachers;

    private string teacherFilePath;

    private TeacherService()
    {
        teacherFilePath = "../../../Data/Teachers.json";
        if(File.Exists(teacherFilePath) is false)
        {
            File.WriteAllText(teacherFilePath, "[]");
        }

        _teachers = new List<Teacher>();
    }

    public Teacher AddTeacher(Teacher teacher)
    {
        teacher.Id = Guid.NewGuid();
        _teachers.Add(teacher);
        SaveData();
        return teacher;
    }

    public bool DeleteById(Guid TeacherId)
    {
        var teacherFromConsole = GetById(TeacherId);
        if (teacherFromConsole is null)
        {
            return false;
        }
        _teachers.Remove(teacherFromConsole);
        return true;
    }

    public List<Teacher> GetAllTeachers()
    {
        return GetTeachers();
    }

    public Teacher GetById(Guid TeacherId)
    {
        foreach(var teacher in _teachers)
        {
            if(teacher.Id == TeacherId)
            {
                return teacher;
            }
        }

        return null;
    }

    public bool UpdateTeacher(Teacher teacher)
    {
        var teacherFromConsole = GetById(teacher.Id);
        if(teacherFromConsole is null)
        {
            return false;
        }
        var index = _teachers.IndexOf(teacherFromConsole);
        _teachers[index] = teacher;
        SaveData();
        return true;
    }

    private void SaveData()
    {
        var teachersJson = JsonSerializer.Serialize(_teachers);
        File.WriteAllText(teacherFilePath, teachersJson);
    }

    private List<Teacher> GetTeachers()
    {
        var teachersJson = File.ReadAllText(teacherFilePath);
        var teachers = JsonSerializer.Deserialize<List<Teacher>>(teachersJson);
        return teachers;
    }
}
