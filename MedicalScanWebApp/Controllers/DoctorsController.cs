using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MedicalScanWebApp.DatabaseContext;
using MedicalScanWebApp.Models;

namespace MedicalScanWebApp.Controllers {
	public class DoctorsController : Controller {
		private readonly MedicalScanDbContext _context;

		public DoctorsController(MedicalScanDbContext context) {
			_context = context;
		}

		// CUSTOMIZED QUERY:
		[HttpGet("BySpecialization")]
		public IActionResult GetDoctorsBySpecialization([FromQuery] string specialization) {
			// LINQ query to query the database using EntityFramework
			if (specialization.ToLower() == "all") {
				// Query to get all the doctors
				var allDoctorsWithSpecializations = _context.Doctors
					.Select(d => new DoctorDto {
						DoctorId = d.DoctorId,
						DoctorName = d.Name,
						Specialties = d.DoctorSpecialties.Select(ds => ds.Specialty.Name).ToList()
					})
					.ToList();

				return Ok(allDoctorsWithSpecializations);
			} else {
				//Query to get doctors by specialty
				var doctorsWithSpecialization = _context.Doctors
					.Where(d => d.DoctorSpecialties.Any(ds => ds.Specialty.Name == specialization))
					.Select(d => new DoctorDto {
						DoctorId = d.DoctorId,
						DoctorName = d.Name,
						Specialties = d.DoctorSpecialties.Select(ds => ds.Specialty.Name).ToList()
					})
					.ToList();

				return Ok(doctorsWithSpecialization);
			}
		}

		//Alternative: send all the doctors and filter in the client to make less server requests.
		[HttpGet("AllDoctors")]
		public IActionResult GetAllDoctors() {
			// LINQ query to query the database using EntityFramework

			var allDoctorsWithSpecializations = _context.Doctors
				.Select(d => new DoctorDto {
					DoctorId = d.DoctorId,
					DoctorName = d.Name,
					Specialties = d.DoctorSpecialties.Select(ds => ds.Specialty.Name).ToList()
				})
				.ToList();

			return Ok(allDoctorsWithSpecializations);
		}

		// GET: Doctors
		public async Task<IActionResult> Index() {
			return View(await _context.Doctors.ToListAsync());
		}

		// GET: Doctors/Details/5
		public async Task<IActionResult> Details(int? id) {
			if (id == null) {
				return NotFound();
			}

			var doctor = await _context.Doctors
				.FirstOrDefaultAsync(m => m.DoctorId == id);
			if (doctor == null) {
				return NotFound();
			}

			return View(doctor);
		}

		// GET: Doctors/Create
		public IActionResult Create() {
			return View();
		}

		// POST: Doctors/Create
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Create([Bind("DoctorId,Name")] Doctor doctor) {
			if (ModelState.IsValid) {
				_context.Add(doctor);
				await _context.SaveChangesAsync();
				return RedirectToAction(nameof(Index));
			}
			return View(doctor);
		}

		// GET: Doctors/Edit/5
		public async Task<IActionResult> Edit(int? id) {
			if (id == null) {
				return NotFound();
			}

			var doctor = await _context.Doctors.FindAsync(id);
			if (doctor == null) {
				return NotFound();
			}
			return View(doctor);
		}

		// POST: Doctors/Edit/5
		// To protect from overposting attacks, enable the specific properties you want to bind to.
		// For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
		[HttpPost]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> Edit(int id, [Bind("DoctorId,Name")] Doctor doctor) {
			if (id != doctor.DoctorId) {
				return NotFound();
			}

			if (ModelState.IsValid) {
				try {
					_context.Update(doctor);
					await _context.SaveChangesAsync();
				} catch (DbUpdateConcurrencyException) {
					if (!DoctorExists(doctor.DoctorId)) {
						return NotFound();
					} else {
						throw;
					}
				}
				return RedirectToAction(nameof(Index));
			}
			return View(doctor);
		}

		// GET: Doctors/Delete/5
		public async Task<IActionResult> Delete(int? id) {
			if (id == null) {
				return NotFound();
			}

			var doctor = await _context.Doctors
				.FirstOrDefaultAsync(m => m.DoctorId == id);
			if (doctor == null) {
				return NotFound();
			}

			return View(doctor);
		}

		// POST: Doctors/Delete/5
		[HttpPost, ActionName("Delete")]
		[ValidateAntiForgeryToken]
		public async Task<IActionResult> DeleteConfirmed(int id) {
			var doctor = await _context.Doctors.FindAsync(id);
			if (doctor != null) {
				_context.Doctors.Remove(doctor);
			}

			await _context.SaveChangesAsync();
			return RedirectToAction(nameof(Index));
		}

		private bool DoctorExists(int id) {
			return _context.Doctors.Any(e => e.DoctorId == id);
		}
	}

	public class DoctorDto {
		public int DoctorId { get; set; }
		public string DoctorName { get; set; }
		public List<string> Specialties { get; set; }
	}
}
