using System;
using System.Collections.Generic;
using WorkingWithJson1.Models;

namespace WorkingWithJson1.Classes
{
    public sealed class Sample
    {
        private static readonly Lazy<Sample> Lazy =
            new Lazy<Sample>(() =>
                new Sample());

        /// <summary>
        /// Entry point to access information in this class
        /// </summary>
        public static Sample Instance => Lazy.Value;
        public List<Person> People { get; set; }

        private Sample()
        {
            People = new List<Person>();
        }
    }
}