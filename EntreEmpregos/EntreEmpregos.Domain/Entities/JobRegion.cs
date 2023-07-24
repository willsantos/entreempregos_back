using System.ComponentModel.DataAnnotations;
using EntreEmpregos.Domain.Entities;

namespace EntreEmpregos.Api.Entities;

public class JobRegion
{
    [Key]
    public int Id { get; set; }

    [StringLength(100)]
    public string Name { get; set; }

    [StringLength(3)]
    public string Abbr { get; set; }

    public IList<Job> Jobs { get; set; }
}