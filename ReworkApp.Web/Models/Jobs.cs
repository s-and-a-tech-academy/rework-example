using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

// Models for our application data
public class Job
{
    public required string Title { get; set; }
    public required string Description { get; set; }
    public required string Type { get; set; }
}