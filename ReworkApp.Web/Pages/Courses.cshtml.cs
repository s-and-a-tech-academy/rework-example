using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReworkApp.Web.Pages;

public class CoursesModel : PageModel
{
    public List<Course> Courses { get; set; } = new List<Course>();

    // The OnGet method fetches courses data.
    public void OnGet()
    {
        Courses = new List<Course>
        {
            new Course { Title = "Career Relaunch Bootcamp", Description = "A comprehensive 4-week course covering modern resume writing, interview skills, and networking strategies.", DurationWeeks = 4 },
            new Course { Title = "Introduction to Digital Marketing", Description = "Learn the fundamentals of SEO, content marketing, and social media advertising in this self-paced online course.", DurationWeeks = 8 },
            new Course { Title = "Project Management Fundamentals", Description = "Gain a solid foundation in project management principles and prepare for certification exams.", DurationWeeks = 6 }
        };
    }
}