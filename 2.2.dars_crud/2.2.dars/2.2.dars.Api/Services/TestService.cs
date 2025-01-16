using System.Text.Json;
using _2._2.dars.Api.Models;

namespace _2._2.dars.Api.Services;

public class TestService : ITestService
{
    private string testFilePath;
    private List<Test> _tests;

    private TestService()
    {
        testFilePath = "../../../Data/Tests.json";
        if (File.Exists(testFilePath) is false)
        {
            File.WriteAllText(testFilePath, "[]");
        }
        _tests = new List<Test>();
    }

    

    public Test AddTest(Test test)
    {
        test.Id = Guid.NewGuid();
        _tests.Add(test);
        SaveData();
        return test;
    }

    public bool DeleteTest(Test test)
    {
        var oldTest = GetByIdTest(test.Id);
        if (oldTest is null)
        {
            return false;
        }
        _tests.Remove(oldTest);
        SaveData();
        return true;
    }

    public List<Test> GetTestList()
    {
        return GetTests();
    }

    public bool UpdateTest(Test test)
    {
        var oldTest = GetByIdTest(test.Id);
        if(oldTest is null)
        {
            return false;
        }
        var index = _tests.IndexOf(test);
        _tests[index] = test;
        SaveData();
        return true;
    }

    private void SaveData()
    {
        var testsJson = JsonSerializer.Serialize(_tests);
        File.WriteAllText(testFilePath, testsJson);
    }

    private List<Test> GetTests()
    {
        var testsJson = File.ReadAllText(testFilePath);
        var tests = JsonSerializer.Deserialize<List<Test>>(testsJson);
        return tests;
    }


    public List<Test> GetRandomTests(int count)
    {
        if (count >= _tests.Count)
        {
            return _tests;
        }

        var randomTests = new List<Test>();
        var rand = new Random();
        for (var i = 0; i < count;)
        {
            var option = rand.Next(0, _tests.Count);
            if (randomTests.Contains(_tests[option]) is false)
            {
                randomTests.Add(_tests[option]);
                i++;
            }
        }

        return randomTests;
    }

    public Test GetByIdTest(Guid testId)
    {
        foreach (var test in _tests)
        {
            if (test.Id == testId)
            {
                return test;
            }
        }
        return null;
    }
}
