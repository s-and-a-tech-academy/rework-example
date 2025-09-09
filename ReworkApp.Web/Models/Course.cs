using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class Course
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public int DurationWeeks { get; set; }
}
