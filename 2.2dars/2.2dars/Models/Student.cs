﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _2._2dars.Models;

public class Student
{
    public Guid Id { get; set; }

    public string FirstName { get; set; }

    public string LastName { get; set; }

    public int  Age { get; set; }

    public string Degree { get; set; }

    public string Gender { get; set; }

    public List<int> Results { get; set; }
}
