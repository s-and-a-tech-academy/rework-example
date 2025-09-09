using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace ReworkApp.Web.Pages;

public class JobsModel : PageModel
{
    public List<Job> Jobs { get; set; } = new List<Job>();

    // The OnGet method fetches job data.
    public void OnGet()
    {
        Jobs = new List<Job>
        {
            new Job { Title = "Senior Project Manager", Description = "A leading tech firm is looking for a skilled project manager to lead their new initiative.", Type = "Full-time" },
            new Job { Title = "Marketing Coordinator (Part-time)", Description = "Join a creative agency and help manage social media campaigns. Flexible hours available, ideal for those re-entering the workforce.", Type = "Part-time" },
            new Job { Title = "Web Developer (Entry-Level)", Description = "A fast-growing startup is hiring for a junior role. Training and mentorship provided.", Type = "Full-time" }
        };
    }
}