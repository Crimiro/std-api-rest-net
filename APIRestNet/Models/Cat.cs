using System;

namespace APIRestNet.Models;

public class Cat
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Lastname { get; set; } = string.Empty;
    public List<Skill> Skills { get; set; } = new List<Skill>([]);
}
