//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Forum.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class Post
    {
        public int groupId { get; set; }
        public int userId { get; set; }
        public string comments { get; set; }
        public bool IsPublished { get; set; }
        public int logId { get; set; }
    
        public virtual ForumGroup ForumGroup { get; set; }
        public virtual UserRegistration UserRegistration { get; set; }
    }
}
