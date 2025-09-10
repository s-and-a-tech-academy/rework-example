// A suite of unit tests for the Newsletter page model.
 
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Xunit;
using Xunit.Abstractions;
 
public class NewsletterTests
{
    private readonly ITestOutputHelper _output;
 
    public NewsletterTests(ITestOutputHelper output)
    {
        _output = output;
    }
 
    [Fact]
    public void OnPost_ValidSubscription_ReturnsPageWithSuccessMessage()
    {
        // Arrange
        var model = new NewsletterModel();
        model.Subscription = new Newsletter { Name = "John Doe", Email = "" };
 
        // Act
        var result = model.OnPost();
 
        // Assert
        var pageResult = Assert.IsType<PageResult>(result);
        Assert.True(model.IsSubscriptionSuccessful);
        _output.WriteLine("Test passed: Valid form submission returned a success message.");
    }
 
    [Fact]
    public void OnPost_InvalidEmail_ReturnsPageWithValidationError()
    {
        // Arrange
        var model = new NewsletterModel();
        model.Subscription = new Newsletter { Name = "Jane Doe", Email = "invalid-email" };
        model.ModelState.AddModelError("Subscription.Email", "Invalid email address.");
 
        // Act
        var result = model.OnPost();
 
        // Assert
        var pageResult = Assert.IsType<PageResult>(result);
        Assert.False(model.IsSubscriptionSuccessful);
        Assert.True(model.ModelState.ContainsKey("Subscription.Email"));
        Assert.Single(model.ModelState["Subscription.Email"].Errors);
        _output.WriteLine("Test passed: Invalid email submission returned validation error.");
    }
 
    [Fact]
    public void OnPost_MissingName_ReturnsPageWithValidationError()
    {
        // Arrange
        var model = new NewsletterModel();
        model.Subscription = new Newsletter { Name = "", Email = "test@example.com" };
        model.ModelState.AddModelError("Subscription.Name", "Please enter your name.");
 
        // Act
        var result = model.OnPost();
 
        // Assert
        var pageResult = Assert.IsType<PageResult>(result);
        Assert.False(model.IsSubscriptionSuccessful);
        Assert.True(model.ModelState.ContainsKey("Subscription.Name"));
        Assert.Single(model.ModelState["Subscription.Name"].Errors);
        _output.WriteLine("Test passed: Missing name returned validation error.");
    }
}