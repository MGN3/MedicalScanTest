namespace MedicalScanWebApp.Models {
	public class DoctorSpecialty {
		public int DoctorId { get; set; }
		public Doctor Doctor { get; set; }

		public int SpecialtyId { get; set; }
		public Specialty Specialty { get; set; }

		//Empty constructor for Entity Framework
		public DoctorSpecialty() {

		}
	}
}