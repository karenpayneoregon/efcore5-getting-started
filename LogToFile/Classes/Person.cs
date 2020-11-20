using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace LogToFile.Models
{
    public partial class Person
    {
        public string FullName => $"{FirstName} {LastName}";
    }
}
