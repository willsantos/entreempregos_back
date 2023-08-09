using System.ComponentModel.DataAnnotations;

namespace EntreEmpregos.Domain.Entities;

public class TransGroup : Entity
{
    [StringLength(20)] public string GroupId { get; set; }

    [StringLength(100)] public string Name { get; set; }
}