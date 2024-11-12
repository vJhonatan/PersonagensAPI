using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.OpenApi.Expressions;
using PersonagensApi.Models;
using System;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.InteropServices.Marshalling;

namespace Personagens.Controllers
{
    [Route("api/personagens")]
    [ApiController]
    public class PersonagemController : ControllerBase
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
                Local = "NY City"
            },
        };

        [HttpGet]
        public ActionResult<List<Personagem>> getAllPersonagens()
        {
            return Ok(personagens);
        }

        [HttpGet("{id}")]
        public ActionResult<Personagem> GetPersonagemById(int id)
        {
            var findId = personagens.Find(x => x.Id == id);

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

        [HttpPut("{id}")]
        public ActionResult<List<Personagem>> UpdateCharacter(int id, Personagem edit)
        {
            var searchId = personagens.Find(x => x.Id == id);

            if (searchId is null) return NotFound("Personagem não encontrado.");

            searchId.Nome = edit.Nome == "" || edit.Nome == "string" ? searchId.Nome : edit.Nome;

            searchId.Sobrenome = edit.Sobrenome == "" || edit.Sobrenome == "string" ? searchId.Sobrenome : edit.Sobrenome;

            searchId.Fantasia = edit.Fantasia == "" || edit.Fantasia == "string" ? searchId.Fantasia : edit.Fantasia;

            searchId.Local = edit.Local == "" || edit.Local == "string" ? searchId.Local : edit.Local;

            return Ok(searchId);
        }

        [HttpGet("local/{locale}")]
        public ActionResult<List<Personagem>> GetPersonByLocale(string locale)
        {
            var findLocale = personagens.FindAll(x => x.Local == locale);

            if (findLocale is null) return NotFound("Local não encontrado");

            return Ok(findLocale);
        }

        [HttpDelete("{id}")]
        public ActionResult DeletePerson(int id)
        {
            var delete = personagens.Find(x => x.Id == id);

            if (delete is null) return NotFound("ID não existe.");

            personagens.Remove(delete);

            return Ok($"{delete.Nome} foi removido com sucesso!");
        }
    }
}