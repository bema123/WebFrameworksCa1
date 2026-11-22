namespace Registration.Pages;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Registration.Models;
using System;
using System.IO;

public class IndexModel : PageModel
{
	public string SavedInfo { get; set; } = "";
	public void OnGet()
	{
		ReadSavedInfo();
	}
	
	public string Message { get; set; } = "";
	public void OnPost()
	{
		ReadSavedInfo();
        string name = Request.Form["fname"];
		string ageCheck = Request.Form["age"];
		string workshop = Request.Form["workshop"];
		string requiresLaptopCheck = Request.Form["requiresLaptop"];

		if (string.IsNullOrWhiteSpace(name))
		{
			Message = "First Name is required";
			return;

		}
		if (!int.TryParse(ageCheck,out int age))
		{
			Message = "please enter a valid age";
			return;
        }

		if(age < 16 || age > 120)
		{
			Message = "Age must be between 16 and 120";
			return;
		}
		if (workshop != "Web Development" &&
					workshop != "Data Science"
					&& workshop != "Networking")
			{
				Message = "Please select a valid workshop";
				return;
			}

		if (!bool.TryParse(requiresLaptopCheck, out bool requiresLaptop))
		{
			Message = "Invalid value for laptop requirement";
			return;
		}


		try {
			Registration registration = new Registration(name, age, workshop, requiresLaptop);
			Message = "new registration\n" + registration.ToString();

			string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
			Directory.CreateDirectory(folderPath);
			string filePath = Path.Combine(folderPath, "registrations.txt");

			System.IO.File.AppendAllText(filePath, registration.ToString() + Environment.NewLine);
			SavedInfo = System.IO.File.ReadAllText(filePath);
        }
		catch (IOException) {
			Message = "Error writing  to file";
		}

	}
	private void ReadSavedInfo()
	{
        string folderPath = Path.Combine(Directory.GetCurrentDirectory(), "Data");
        string filePath = Path.Combine(folderPath, "registrations.txt");
        if (System.IO.File.Exists(filePath))
        {
            SavedInfo = System.IO.File.ReadAllText(filePath);
        }
        else
        {
            SavedInfo = "No registrations found.";
        }
    }
}