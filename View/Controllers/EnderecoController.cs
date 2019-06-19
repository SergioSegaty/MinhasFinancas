using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Model;
using Repository;

namespace View.Controllers
{
    public class EnderecoController : Controller
    {
        // GET: Enderecos
        public ActionResult Index(string pesquisa)
        {
            EnderecoRepositorio repositorio = new EnderecoRepositorio();
            List<Endereco> enderecos = repositorio.ObterTodos(pesquisa);

            ViewBag.Enderecos = enderecos;
            return View();
        }

        public ActionResult Cadastro()
        {
            return View();
        }

        public ActionResult Store(string uf, string cidade, string lagradouro,
                                    string cep, string numero, string complemento)
        {
            Endereco endereco = new Endereco();

            endereco.Uf = uf;
            endereco.Cidade = cidade;
            endereco.Lagradouro = lagradouro;
            endereco.Cep = cep;
            endereco.Numero = numero;
            endereco.Complemento = complemento;

            EnderecoRepositorio repositorio = new EnderecoRepositorio();
            repositorio.Inserir(endereco);

            return RedirectToAction("Index");
        }

        public ActionResult Apagar(int id)
        {
            EnderecoRepositorio repositorio = new EnderecoRepositorio();
            repositorio.Apagar(id);
            return RedirectToAction("Index");
        }

        public ActionResult Editar(int id)
        {
            EnderecoRepositorio repositorio = new EnderecoRepositorio();
            Endereco endereco = repositorio.ObterPeloId(id);
            ViewBag.Endereco = endereco;

            return View();

        }

        public ActionResult Update(int id, string uf, string cidade, string lagradouro,
                                    string cep, string numero, string complemento)
        {
            Endereco endereco = new Endereco();

            endereco.Uf = uf;
            endereco.Cidade = cidade;
            endereco.Lagradouro = lagradouro;
            endereco.Cep = cep;
            endereco.Numero = numero;
            endereco.Complemento = complemento;
            endereco.Id = id;

            EnderecoRepositorio repositorio = new EnderecoRepositorio();
            repositorio.Atualizar(endereco);
            return RedirectToAction("Index");
            
        }





    }
}