using System;


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

    public Registration(string firstName, int age, string workshop, bool requiresLaptop)
    {
        FirstName = firstName;
        Age = age;
        Workshop = workshop;
        RequiresLaptop = requiresLaptop;
    }
    
    public override string ToString()
    {
        return "First Name is - " + FirstName + 
            " age is - "  + Age +
            " Workshop is - " +Workshop + 
            "Requires Laptop - " + RequiresLaptop;
    }

}
}
