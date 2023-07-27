using System.ComponentModel.DataAnnotations;
using EntreEmpregos.Domain.Entities;

namespace EntreEmpregos.Api.Entities;

public class JobLevel
{
    [Key]
    public Guid Id { get; set; }

    [StringLength(60)]
    public string Description { get; set; }
    
    public IList<Job> Jobs { get; set; }
}