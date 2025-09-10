using Xunit;
using Xunit.Abstractions;

// Unit Tests
// This is an example of a unit test class using the XUnit framework.
// You would place this in a separate test project that references the main project.
public class JobServiceTests
{
    private readonly ITestOutputHelper _output;

    public JobServiceTests(ITestOutputHelper output)
    {
        _output = output;
    }

    [Fact]
    public void GetAllJobs_ReturnsCorrectNumberOfJobs()
    {
        // Arrange
        var service = new JobService();

        // Act
        var jobs = service.GetAllJobs();

        // Assert
        Assert.Equal(2, jobs.Count);
        _output.WriteLine($"Test passed: Expected 2 jobs, got {jobs.Count}.");
    }

    [Fact]
    public void GetAllJobs_ContainsSpecificJobTitle()
    {
        // Arrange
        var service = new JobService();

        // Act
        var jobs = service.GetAllJobs();

        // Assert
        Assert.Contains(jobs, j => j.Title == "Accountant");
        _output.WriteLine("Test passed: Job list contains 'Accountant'.");
    }
}

