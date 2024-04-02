using System.ComponentModel.DataAnnotations;

namespace Mc2.CrudTest.Domain.Common.Entities;
public class BaseEntity : IBaseEntity
{
    public int Id { get; set; }
}

public interface IBaseEntity
{
    [Key] int Id { get; set; }
}