using System.Text.Json;
using _2._2dars.Models;

namespace _2._2dars.Services;

public class TeacherService
{
    private string teacherFilePath;

    public TeacherService()
    {
        teacherFilePath = "../../../Data/teachers.json";
        File.WriteAllText(teacherFilePath, "[]");
    }

}
