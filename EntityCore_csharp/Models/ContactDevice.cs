﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
using System;
using System.Collections.Generic;

#nullable disable

namespace EntityCore_csharp.Models
{
    public partial class ContactDevice
    {
        public int Id { get; set; }
        public int? ContactId { get; set; }
        public int? PhoneTypeIdentifier { get; set; }
        public string PhoneNumber { get; set; }

        public virtual Contact Contact { get; set; }
        public virtual PhoneType PhoneTypeIdentifierNavigation { get; set; }
    }
}