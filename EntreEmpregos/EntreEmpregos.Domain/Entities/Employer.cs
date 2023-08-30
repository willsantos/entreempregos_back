using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Entities;

public class Employer : Entity
{
    [StringLength(60)] public string Name { get; set; } = string.Empty;

    public decimal? Rating { get; set; }


    //public IList<Job> Jobs { get; set; }
}