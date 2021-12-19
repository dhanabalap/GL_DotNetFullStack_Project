﻿using System;

namespace GL_DotNetFullStack_Project.Models
{
    public class Task :IBaseEntity
    {
        public int ID { get; set; }
        public int ProjectID { get; set; }
        public int Status { get; set; }
        public int AssignedToUserID { get; set; }
        public string Detail { get; set; }
        public DateTime CreatedOn { get; set; }
        
    }
}
