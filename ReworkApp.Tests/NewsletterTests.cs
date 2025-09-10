// A suite of unit tests for the Newsletter page model.

using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
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
    public void Newsletter_ValidInput_ReturnsNoValidationErrors()
    {
        // Arrange
        var subscription = new Newsletter { Name = "John Doe", Email = "john.doe@example.com" };
        var validationContext = new ValidationContext(subscription, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(subscription, validationContext, validationResults, true);

        // Assert
        Assert.True(isValid);
        Assert.Empty(validationResults);
        _output.WriteLine("Test passed: Valid input correctly returns no validation errors.");
    }

    [Fact]
    public void Newsletter_InvalidInput_ReturnsValidationErrors()
    {
        // Arrange
        var subscription = new Newsletter { Name = "", Email = "invalid-email" };
        var validationContext = new ValidationContext(subscription, serviceProvider: null, items: null);
        var validationResults = new List<ValidationResult>();

        // Act
        var isValid = Validator.TryValidateObject(subscription, validationContext, validationResults, true);

        // Assert
        Assert.False(isValid);
        Assert.Equal(2, validationResults.Count);
        Assert.Contains(validationResults, vr => vr.ErrorMessage == "Please enter your name.");
        Assert.Contains(validationResults, vr => vr.ErrorMessage == "Please enter a valid email address.");
        _output.WriteLine("Test passed: Invalid input correctly returns validation errors.");
    }

    [Fact]
    public void OnPost_GivenInvalidModel_ReturnsValidationError()
    {
        // Arrange
        var model = new NewsletterModel();
        model.Subscription = new Newsletter { Name = "Jane Doe", Email = "invalid-email" };

        // Manually simulate a validation failure by setting ModelState.IsValid to false.
        model.ModelState.AddModelError("Subscription.Email", "Please enter a valid email address.");

        // Act
        var result = model.OnPost();

        // Assert
        var pageResult = Assert.IsType<PageResult>(result);
        Assert.False(model.IsSubscriptionSuccessful);
        Assert.False(model.ModelState.IsValid);
        _output.WriteLine("Test passed: OnPost method correctly handles invalid model state.");
    }
}
