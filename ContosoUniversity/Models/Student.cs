using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace ContosoUniversity.Models
{
	public class Student
	{
		public int Id { get; set; }

		[DisplayName("Фамилия")]
		public string LastName { get; set; }

		[DisplayName("Имя и отчество")]
		public string FirstMidName { get; set; }

		[DisplayName("Дата зачисления")]
		//[DisplayFormat(DataFormatString = "{0:dd.MM.yyyy}", ApplyFormatInEditMode = true)]
		public DateTime EnrollmentDate { get; set; }

		public ICollection<Enrollment> Enrollments { get; set; }
	}
}