using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.AccessControl;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using _2._2.dars.Api.Models;

namespace _2._2.dars.Api.Services;

public class StudentService : IStudentService
{
    private string studentFilePath;

    private List<Student> _students;

    public StudentService()
    {
        studentFilePath = "../../../Data/Students.json";

        if(File.Exists(studentFilePath) is false)
        {
            File.WriteAllText(studentFilePath, "[]");
        }

        _students = new List<Student>();
    }

    public Student GetById(Guid studentId)
    {
        foreach (var student in _students)
        {
            if (student.Id == studentId)
            {
                return student;
            }
        }

        return null;
    }

    public Student AddStudent(Student student)
    {
        student.Id = Guid.NewGuid();
        _students.Add(student);
        SaveData();
        return student;
    }

    public bool UpdateStudent (Student student)
    {
        var studentOld = GetById(student.Id);
        if (studentOld is null)
        {
            return false;
        }

        var index = _students.IndexOf(studentOld);
        _students[index] = student;
        SaveData();
        return true;
    }

    public List<Student> GetAllStudents()
    {
        return GetStudents();
    }

    private void SaveData()
    {
        var studentsJson = JsonSerializer.Serialize(_students);
        File.WriteAllText(studentFilePath, studentsJson);
    }

    private List<Student> GetStudents()
    {
        var studentsJson = File.ReadAllText(studentFilePath);
        var students = JsonSerializer.Deserialize<List<Student>>(studentsJson);
        return students;
    }

    public bool DeleteStudent(Guid studentId)
    {
        var oldStudent = GetById(studentId);
        if (oldStudent is null)
        {
            return false;
        }

        _students.Remove(oldStudent);
        SaveData();
        return true;
    }
}
