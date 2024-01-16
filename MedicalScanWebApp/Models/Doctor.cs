namespace MedicalScanWebApp.Models {
	public class Doctor {

		public int DoctorId { get; set; }
		public string Name { get; set; }

		// Other properties

		//Navigation property for Entity Framework
		public ICollection<DoctorSpecialty>? DoctorSpecialties { get; set; }

		//Empty constructor for Entity Framework
		public Doctor() {

		}
	}
}
