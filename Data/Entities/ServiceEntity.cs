﻿using System.ComponentModel.DataAnnotations;

namespace Data.Entities;

public class ServiceEntity
{
    [Key]
    public int Id { get; set; }
    public string ServiceName { get; set; } = null!;
    public int Price { get; set; }

    public IEnumerable<ProjectEntity>? Projects { get; set; }
}
