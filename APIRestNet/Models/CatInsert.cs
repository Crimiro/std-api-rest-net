using System;
using System.ComponentModel.DataAnnotations;

namespace APIRestNet.Models;

public class CatInsert
{
    [Required]
    [MaxLength(50)]
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
}
