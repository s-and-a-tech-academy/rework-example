// The data model for our newsletter subscription.
 
using System.ComponentModel.DataAnnotations;
 
public class Newsletter
{
    [Required(ErrorMessage = "Please enter your name.")]
    public string Name { get; set; } = string.Empty;
 
    [Required(ErrorMessage = "Please enter your email address.")]
    [EmailAddress(ErrorMessage = "Please enter a valid email address.")]
    public string Email { get; set; } = string.Empty;
}