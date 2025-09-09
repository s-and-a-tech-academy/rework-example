// A simple service class that we can test.
public class JobService
{
    public List<Job> GetAllJobs()
    {
        return new List<Job>
        {
            new Job { Title = "Accountant", Type = "Full-time" },
            new Job { Title = "Receptionist", Type = "Part-time" }
        };
    }
}