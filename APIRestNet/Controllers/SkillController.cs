using System;
using APIRestNet.Helpers;
using APIRestNet.Models;
using APIRestNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIRestNet.Controllers;

[ApiController]
[Route("api/cat/{catId}/[controller]")]
public class SkillController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Skill>> GetSkills(int catId)
    {
        var cat = CatDataStore.Current.Cats.FirstOrDefault(c => c.Id == catId);
        if (cat == null)
            return NotFound(Messages.Cat.NotFound);
        return Ok(cat.Skills);
    }

    [HttpGet("{skillId}")]
    public ActionResult<Skill> GetSkill(int catId, int skillId)
    {
        var cat = CatDataStore.Current.Cats.FirstOrDefault(c => c.Id == catId);
        if (cat == null)
            return NotFound(Messages.Cat.NotFound);

        var skill = cat.Skills?.FirstOrDefault(s => s.Id == skillId);
        if (skill == null)
            return NotFound(Messages.Skill.NotFound);

        return Ok(skill);
    }

    [HttpPost]
    public ActionResult<Skill> PostSkill(int catId, SkillInsert skillInsert)
    {
        var cat = CatDataStore.Current.Cats.FirstOrDefault(c => c.Id == catId);
        if (cat == null)
            return NotFound(Messages.Cat.NotFound);
        
        var skillExists = cat.Skills.FirstOrDefault(s => s.Name == skillInsert.Name);
        if (skillExists != null)
            return BadRequest(Messages.Skill.Found);

        var maxSkillId = cat.Skills.Max(s => s.Id);

        var newSkill = new Skill()
        {
            Id = maxSkillId + 1,
            Name = skillInsert.Name,
            Power = skillInsert.Power
        };

        cat.Skills.Add(newSkill);

        return CreatedAtAction(nameof(GetSkill), new { catId = catId, skillId = newSkill.Id }, newSkill);
    }

    [HttpPut("{skillId}")]
    public ActionResult<Skill> PutSkill(int catId, int skillId, SkillInsert skillInsert)
    {
        var cat = CatDataStore.Current.Cats.FirstOrDefault(c => c.Id == catId);

        if (cat == null)
            return NotFound(Messages.Cat.NotFound);
        
        var existingSkill = cat.Skills.FirstOrDefault(s => s.Name == skillInsert.Name);
        if (existingSkill == null)
            return NotFound(Messages.Skill.NotFound);
        
        var sameSkill = cat.Skills.FirstOrDefault(s => s.Id != skillId && s.Name == skillInsert.Name);
        if (sameSkill != null)
            return BadRequest("Ya existe una habilidad con el mismo nombre.");

        existingSkill.Name = skillInsert.Name;
        existingSkill.Power = skillInsert.Power;

        return NoContent();
    }

    [HttpDelete("{skillId}")]
    public ActionResult DeleteSkill(int catId, int skillId)
    {
        var cat = CatDataStore.Current.Cats.FirstOrDefault(c => c.Id == catId);

        if (cat == null)
            return NotFound(Messages.Cat.NotFound);
        
        var existingSkill = cat.Skills.FirstOrDefault(s => s.Id == skillId);
        if (existingSkill == null)
            return NotFound(Messages.Skill.NotFound);

        cat.Skills.Remove(existingSkill);

        return NoContent();
    }
}
