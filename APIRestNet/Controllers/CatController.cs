using System;
using APIRestNet.Models;
using APIRestNet.Services;
using Microsoft.AspNetCore.Mvc;

namespace APIRestNet.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CatController : ControllerBase
{
    [HttpGet]
    public ActionResult<IEnumerable<Cat>> GetCats()
    {
        return Ok(CatDataStore.Current.Cats);
    }

    [HttpGet("{id}")]
    public ActionResult<Cat> GetCat(int id)
    {
        var cat = CatDataStore.Current.Cats.FirstOrDefault(c => c.Id == id);
        if (cat == null)
            return NotFound("El gato solicitado no existe.");
        return Ok(cat);
    }

    [HttpPost]
    public ActionResult<Cat> PostCat(CatInsert catInsert) // Sin APIController habría que definir que el parámetro es del cuerpo
    {
        var maxCatId = CatDataStore.Current.Cats.Max(c => c.Id);
        var newCat = new Cat()
        {
            Id = maxCatId + 1,
            Name = catInsert.Name,
            Lastname = catInsert.Lastname
        };
        CatDataStore.Current.Cats.Add(newCat);
        return CreatedAtAction(nameof(GetCat), new { id = newCat.Id }, newCat);
    }

    [HttpPut("{catId}")]
    public ActionResult<Cat> PutCat(int catId, CatInsert catInsert) // public ActionResult<Cat> PutCat([FromRoute] int catId, [FromBody] CatInsert catInsert) 
    {
        var cat = CatDataStore.Current.Cats.FirstOrDefault(c => c.Id == catId);
        if (cat == null)
            return NotFound("El gato solicitado no existe.");
        cat.Name = catInsert.Name;
        cat.Lastname = catInsert.Lastname;
        return NoContent();
    }

    [HttpDelete("{catId}")]
    public ActionResult DeleteCat(int catId)
    {
        var cat = CatDataStore.Current.Cats.FirstOrDefault(c => c.Id == catId);
        if (cat == null)
            return NotFound("El gato solicitado no existe.");
        CatDataStore.Current.Cats.Remove(cat);
        return NoContent();
    }
}
