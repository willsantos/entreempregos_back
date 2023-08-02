namespace EntreEmpregos.Domain.Contracts;

public class EmployerResponse : EmployerRequest
{
    public Guid Id { get; set; }
    public decimal Rating { get; set; }
}