namespace MedicalScanWebApp.Models {
	public class Specialty {
		public int SpecialtyId { get; set; }
		public string Name { get; set; }

		// Other properties of Specialty


		//Navigation property for Entity Framework
		public ICollection<DoctorSpecialty>? DoctorSpecialties { get; set; }

		//Empty constructor for Entity Framework
		public Specialty() {

		}

	}
}