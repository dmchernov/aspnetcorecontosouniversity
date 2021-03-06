﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ContosoUniversity.Models
{
	public class Student
	{
		public int Id { get; set; }

		[Display(Name = "Last Name")]
		[StringLength(50)]
		[RegularExpression(@"^[A-Z]+[a-zA-Z""'\s-]*$")]
		[Required]
		public string LastName { get; set; }

		[Display(Name = "First Name")]
		[StringLength(50, ErrorMessage = "First name cannot be longer than 50 characters.")]
		[Column("FirstName")]
		[Required]
		public string FirstMidName { get; set; }

		[Display(Name = "Enrollment date")]
		[DataType(DataType.Date)]
		[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
		public DateTime EnrollmentDate { get; set; }

		public ICollection<Enrollment> Enrollments { get; set; }

		[Display(Name = "Full Name")]
		public string FullName => $"{LastName}, {FirstMidName}";
	}
}
