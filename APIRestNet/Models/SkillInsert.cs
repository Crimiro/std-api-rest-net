using System;
using static APIRestNet.Models.Skill;

namespace APIRestNet.Models;

public class SkillInsert
{
    public string Name { get; set; } = string.Empty;

    public EPower Power { get; set; }
}
