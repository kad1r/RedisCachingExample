using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Category
    {
        public Category()
        {
            this.Posts = new List<Post>();
        }

        public int Id { get; set; }
        public string Heading { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public virtual ICollection<Post> Posts { get; set; }
    }
}
