using System.ComponentModel.DataAnnotations;
using EntreEmpregos.Domain.Entities;

namespace EntreEmpregos.Api.Entities;

public class JobRegion
{
    [Key]
    public Guid Id { get; set; }

    [Required]
    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(3)]
    public string Abbr { get; set; }

    public IList<Job> Jobs { get; set; }
}