using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using Newtonsoft.Json;
using WorkingWithJson1.Models;
using WorkingWithJson1.Classes;

namespace WorkingWithJson1.Context
{
    public class PersonConfiguration : IEntityTypeConfiguration<Person>
    {
        public void Configure(EntityTypeBuilder<Person> builder)
        {
            builder.ToTable("Person");
            
            
            builder.Property(e => e.Addresses).HasConversion(
                list => JsonConvert.SerializeObject(list, 
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }),
                list => JsonConvert.DeserializeObject<IList<Address>>(list, 
                    new JsonSerializerSettings { NullValueHandling = NullValueHandling.Ignore }));
        }
    }
}
