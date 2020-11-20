using System;
using System.Collections.Generic;
using System.Text;

// ReSharper disable once CheckNamespace
namespace ConnectionConfiguration.Models
{
    public partial class Person
    {
        public string FullName => $"{FirstName} {LastName}";
    }
}
