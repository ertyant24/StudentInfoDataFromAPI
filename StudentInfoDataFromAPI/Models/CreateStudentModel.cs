namespace StudentInfoDataFromAPI.Models
{
	public class CreateStudentModel
	{
		public string FullName { get; set; }
		public string College { get; set; }
		public int Age { get; set; }
		public string Computer { get; set; }
		public bool IsSuccess { get; set; }
	}
}
