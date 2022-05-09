using System;

namespace studentsLabSQL.models
{
	public class StudentsCrud
	{
		StudentsContext sc = new StudentsContext();
		public StudentsCrud()
		{
		}

		public List<Student> GetStudent()
        {
			return sc.Students.ToList();
        }
	}
}

