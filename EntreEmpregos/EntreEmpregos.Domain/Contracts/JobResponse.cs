namespace EntreEmpregos.Domain.Contracts;

public class JobResponse : JobRequest
{
    public Guid Id { get; set; }

    public string Employer { get; set; }
}