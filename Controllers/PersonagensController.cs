using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
using PersonagensApi.Models;

namespace Personagens.Controllers
{
    [Route("api/personagens")]
    [ApiController]
    public class PersonagensController : ControllerBase
    {
        private static List<Personagem> personagens = new List<Personagem>
        {
            new Personagem
            {
                Id = 1,
                Nome = "Peter",
                Sobrenome = "Parker",
                Fantasia = "Homem-Aranha",
                Local = "NY City"
            },
            new Personagem
            {
                Id = 2,
                Nome = "Wade",
                Sobrenome = "Wilson",
                Fantasia = "Deadpool",
                Local = "Brazil"
            }
        };

        [HttpGet]
        public ActionResult<List<Personagem>> getPerson()
        {
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public ActionResult<Personagem> GetById(int id)
        {
            var findId = (personagens.Find(x => x.Id == id));
            if (findId is null) return NotFound("Id nao existe.");

            return Ok(findId);
        }

        [HttpPost]
        public ActionResult<List<Personagem>> AddPerson(Personagem newPerson)
        {
            if (newPerson.Id == 0 && personagens.Count > 0) newPerson.Id = personagens[personagens.Count - 1].Id + 1;

            personagens.Add(newPerson);
            return Ok(personagens);
        }

        /* TODO: Implementar método PUT */


        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var delete = personagens.Find(x => x.Id == id);

            if (delete is null) NotFound("ID não existe.");

            personagens.Remove(delete);
            return Ok("Deletado com sucesso!");
        }

        [HttpGet("local/{locale}")]
        public ActionResult<List<Personagem>> GetPersonByLocale(string locale)
        {
            var findLocale = personagens.FindAll(x => x.Local == locale);

            if (findLocale.Count == 0) return NotFound("Local não encontrado");

            return Ok(findLocale);
        }
    }
}