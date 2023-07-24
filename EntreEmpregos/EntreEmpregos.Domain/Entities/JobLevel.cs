using System.ComponentModel.DataAnnotations;
using EntreEmpregos.Domain.Entities;

namespace EntreEmpregos.Api.Entities;

public class JobLevel
{
    [Key]
    public int Id { get; set; }

    [StringLength(60)]
    public string Description { get; set; }
    
    public IList<Job> Jobs { get; set; }
}