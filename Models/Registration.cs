using System;

/// <summary>
/// Summary description for Class1
/// </summary>
public class Registration
{
	public Registration()
	{
		[Required(errorMessage = "First Name is required")]
		public string FirstName { get; set; } = "";

        [Required]
        [Range(16,100, ErrorMessage = "Age must be between 16 and 100")]
        public int Age { get; set; }

        [Required(ErrorMessage = "please select a workshop.")]
        public string Workshop { get; set; } = "";

        public bool RequiresLaptop { get; set; }
    //
    // TODO: Add constructor logic here
    //
}
}
