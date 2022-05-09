using System;
using System.Collections.Generic;

namespace studentsLabSQL.models
{
    public partial class Student
    {
        public int Id { get; set; }
        public string? StudentName { get; set; }
        public string? HomeTown { get; set; }
        public string? FavoriteFood { get; set; }
    }
}
