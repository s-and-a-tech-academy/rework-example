using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.Diagnostics;
 
public class NewsletterModel : PageModel
{
    // The data model for the subscription form, bound to the page on post.
    [BindProperty]
    public Newsletter Subscription { get; set; } = new Newsletter();
 
    public bool IsSubscriptionSuccessful { get; private set; }
 
    public void OnGet()
    {
        IsSubscriptionSuccessful = false;
    }
 
    // Handles the form submission (POST request).
    public IActionResult OnPost()
    {
        // Check if the form data is valid based on the model's data annotations.
        if (!ModelState.IsValid)
        {
            // If invalid, return to the page with validation errors.
            IsSubscriptionSuccessful = false;
            return Page();
        }
 
        // Simulate saving the subscription (in a real app, you would save this to a database).
        Debug.WriteLine($"New newsletter subscription from: {Subscription.Name} ({Subscription.Email})");
        IsSubscriptionSuccessful = true;
 
        // Redirect to a success state or just return the page with a success message.
        return Page();
    }
}