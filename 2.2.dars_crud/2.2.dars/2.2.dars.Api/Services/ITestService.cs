using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using _2._2.dars.Api.Models;

namespace _2._2.dars.Api.Services;

public interface ITestService
{
    public Test AddTest(Test test);

    public bool DeleteTest(Test test);

    public bool UpdateTest(Test test);

    public List<Test> GetTestList();
    Test GetByIdTest(Guid testId);

    public List<Test> GetRandomTests(int count);
}
