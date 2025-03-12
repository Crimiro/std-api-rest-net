using System;

namespace APIRestNet.Models;

public class Skill
{
    public int Id { get; set; }
    public string Name { get; set; } = string.Empty;

    public EPower Power { get; set; }

    public enum EPower 
    {
        Soft,
        Moderate,
        Strong,
        VeryStrong,
        Extreme 
    }
}
