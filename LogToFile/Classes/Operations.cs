using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using LogToFile.Context;
using LogToFile.Models;
using Microsoft.EntityFrameworkCore;

namespace LogToFile.Classes
{
    public class Operations
    {
        public static async Task<List<Person>> PeopleTask()
        {
            return await Task.Run(async () =>
            {
                await using var context = new SchoolContext();

                var results = await context
                    .People
                    .Include(person => person.StudentGrades)
                    .ThenInclude(person => person.Course)
                    .ToListAsync();

                return results.OrderBy(person => person.LastName).ToList();

            });

        }
    }
}
