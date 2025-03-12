using System;
using APIRestNet.Models;

namespace APIRestNet.Services;

public class CatDataStore
{
    public List<Cat> Cats { get; set; }

    public static CatDataStore Current { get; } = new CatDataStore(); // Patron singleton

    public CatDataStore()
    {
        Cats = new List<Cat>() {
          new Cat() {
            Id = 1,
            Name = "Mittens",
            Lastname = "Smith",
            Skills = new List<Skill>() {
              new Skill() {
                Id = 1,
                Name = "Jump",
                Power = Skill.EPower.Moderate
              },
              new Skill() {
                Id = 2,
                Name = "Run",
                Power = Skill.EPower.Strong
              }
            }
          },
          new Cat() {
            Id = 2,
            Name = "Whiskers",
            Lastname = "Johnson",
            Skills = new List<Skill>() {
              new Skill() {
                Id = 3,
                Name = "Jump",
                Power = Skill.EPower.Moderate
              },
              new Skill() {
                Id = 4,
                Name = "Run",
                Power = Skill.EPower.Strong
              }
            }
          },
          new Cat() {
            Id = 3,
            Name = "Fluffy",
            Lastname = "Williams",
            Skills = new List<Skill>() {
              new Skill() {
                Id = 5,
                Name = "Jump",
                Power = Skill.EPower.Moderate
              },
              new Skill() {
                Id = 6,
                Name = "Run",
                Power = Skill.EPower.Strong
              }
            }
          }
        };
    }
}
