using DevIO.UI.Site.Data;
using DevIO.UI.Site.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevIO.UI.Site.Controllers
{
    public class TesteCrudController : Controller
    {
        private readonly MeuDbContext _contexto;

        public TesteCrudController(MeuDbContext contexto)
        {
            _contexto = contexto;
        }

        public IActionResult Index()
        {
            var aluno = new Aluno 
            {
                Nome = "Bryan",
                DataNascimento = DateTime.Now,
                Email = "bryanlima.dev@gmail.com"
            };

            // Adicionar
            _contexto.Alunos.Add(aluno);
            _contexto.SaveChanges();

            // Buscar
            var aluno2 = _contexto.Alunos.Find(aluno.Id);
            var aluno3 = _contexto.Alunos.FirstOrDefault(aluno => aluno.Email.Equals("bryanlima.dev@gmail.com"));
            var aluno4 = _contexto.Alunos.Where(aluno => aluno.Nome.Equals("Bryan"));

            // Atualizar
            aluno.Nome = "João";
            _contexto.Alunos.Update(aluno);
            _contexto.SaveChanges();

            // Remover
            _contexto.Alunos.Remove(aluno);
            _contexto.SaveChanges();

            return View();
        }
    }
}
