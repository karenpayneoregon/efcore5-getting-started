﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace LogToFile.Models
{
    public partial class CourseDay
    {
        public int id { get; set; }
        public int? CourseID { get; set; }
        public int? DayIndex { get; set; }
        public bool? Offered { get; set; }

        public virtual WeekDayName DayIndexNavigation { get; set; }
    }
}