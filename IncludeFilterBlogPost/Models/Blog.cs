using System;
using System.Collections.Generic;

#nullable disable

namespace IncludeFilter.Models
{
    public partial class Blog
    {
        public Blog()
        {
            Posts = new HashSet<Post>();
        }

        public int BlogId { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Title { get; set; }
        public DateTime? DateModified { get; set; }
        public override string ToString() => Name;


        public virtual ICollection<Post> Posts { get; set; }
    }
}