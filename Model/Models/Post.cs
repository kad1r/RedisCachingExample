using System;
using System.Collections.Generic;

namespace Model.Models
{
    public partial class Post
    {
        public int Id { get; set; }
        public int CategoryId { get; set; }
        public string Heading { get; set; }
        public string Summary { get; set; }
        public string Description { get; set; }
        public string FriendlyUrl { get; set; }
        public string Tags { get; set; }
        public System.DateTime PublishDate { get; set; }
        public int ReadTime { get; set; }
        public int ReadCount { get; set; }
        public System.DateTime CreatedDate { get; set; }
        public Nullable<System.DateTime> UpdatedDate { get; set; }
        public bool IsActive { get; set; }
        public bool IsDeleted { get; set; }
        public virtual Category Category { get; set; }
    }
}
