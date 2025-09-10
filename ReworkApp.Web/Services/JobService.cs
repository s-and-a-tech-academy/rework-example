// A simple service class that we can test.
public class JobService
{
    public List<Job> GetAllJobs()
    {
        return new List<Job>
        {
            new Job { Title = "Accountant", Description = "Manages financial records.", Type = "Full-time" },
            new Job { Title = "Receptionist", Description = "Greets visitors and answers phones.", Type = "Part-time" }
        };
    }
}
