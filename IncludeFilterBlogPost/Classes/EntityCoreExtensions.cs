using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace IncludeFilter.Classes
{
    public static class DbContexts
    {


        /// <summary>
        /// Get model comments by model type
        /// </summary>
        /// <param name="context">Live DbContext</param>
        /// <param name="modelType">Model type</param>
        /// <returns>IEnumerable&lt;ModelComment&gt;</returns>
        /// <remarks>
        /// context.Comments(typeof(Customers));
        /// WILL NOT WORK WITH EF Core 6
        /// </remarks>
        public static IEnumerable<ModelComment> Comments(this DbContext context, Type modelType)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));

            IEntityType entityType = context.Model.FindRuntimeEntityType(modelType);

            return entityType.GetProperties().Select(property => new ModelComment
            {
                Name = property.Name,
                Comment = property.GetComment()
            });

        }

    

    }
    public class ModelComment
    {
        /// <summary>
        /// Property name
        /// </summary>
        public string Name { get; internal set; }
        /// <summary>
        /// Comment value
        /// </summary>
        public string Comment { get; internal set; }
        public string Full => $"{Name}, {Comment}";
        public override string ToString() => Name;

    }
}