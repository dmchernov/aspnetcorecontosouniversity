﻿using ContosoUniversity.Data;
using ContosoUniversity.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;

namespace ContosoUniversity.Controllers
{
	public class StudentsController : Controller
	{
		private readonly SchoolContext _context;

		public StudentsController(SchoolContext context)
		{
			_context = context;
		}

		public async Task<IActionResult> Index()
		{
			return View(await _context.Students.ToListAsync());
		}

		public async Task<IActionResult> Details(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var student = await _context.Students
				.Include(s => s.Enrollments)
				.ThenInclude(e => e.Course)
				.AsNoTracking()
				.SingleOrDefaultAsync(m => m.Id == id);

			if (student == null)
			{
				return NotFound();
			}

			return View(student);
		}

		public IActionResult Create()
		{
			return View();
		}

		// POST: Students/Create
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("LastName,FirstMidName,EnrollmentDate")] Student student)
		{
			try
			{
				if (ModelState.IsValid)
				{
					_context.Add(student);
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
			}
			catch (DbUpdateException /* ex */)
			{
				//Log the error (uncomment ex variable name and write a log.
				ModelState.AddModelError("", "Unable to save changes. " +
				                             "Try again, and if the problem persists " +
				                             "see your system administrator.");
			}
			return View(student);
		}

		public async Task<IActionResult> Edit(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}

			var student = await _context.Students.FindAsync(id);
			if (student == null)
			{
				return NotFound();
			}
			return View(student);
		}

		// POST: Students/Edit/5
		// To protect from overposting attacks, please enable the specific properties you want to bind to, for 
		// more details see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost, ActionName("Edit")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> EditPost(int? id)
		{
			if (id == null)
			{
				return NotFound();
			}
			var studentToUpdate = await _context.Students.SingleOrDefaultAsync(s => s.Id == id);
			if (await TryUpdateModelAsync(
				studentToUpdate,
				"",
				s => s.FirstMidName, s => s.LastName, s => s.EnrollmentDate))
			{
				try
				{
					await _context.SaveChangesAsync();
					return RedirectToAction(nameof(Index));
				}
				catch (DbUpdateException /* ex */)
				{
					//Log the error (uncomment ex variable name and write a log.)
					ModelState.AddModelError("", "Unable to save changes. " +
					                             "Try again, and if the problem persists, " +
					                             "see your system administrator.");
				}
			}
			return View(studentToUpdate);
		}

		public async Task<IActionResult> Delete(int? id, bool? saveChangesError = false)
		{
			if (id == null)
			{
				return NotFound();
			}

			var student = await _context.Students
				.AsNoTracking()
				.SingleOrDefaultAsync(m => m.Id == id);
			if (student == null)
			{
				return NotFound();
			}

			if (saveChangesError.GetValueOrDefault())
			{
				ViewData["ErrorMessage"] =
					"Delete failed. Try again, and if the problem persists " +
					"see your system administrator.";
			}

			return View(student);
		}

		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id)
		{
			var student = await _context.Students
				.AsNoTracking()
				.SingleOrDefaultAsync(m => m.Id == id);
			if (student == null)
			{
				return RedirectToAction(nameof(Index));
			}

			try
			{
				_context.Students.Remove(student);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			catch (DbUpdateException /* ex */)
			{
				//Log the error (uncomment ex variable name and write a log.)
				return RedirectToAction(nameof(Delete), new {id, saveChangesError = true });
			}
		}

		private bool StudentExists(int id)
		{
			return _context.Students.Any(e => e.Id == id);
		}
	}
}
