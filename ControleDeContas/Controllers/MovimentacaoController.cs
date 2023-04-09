using ControleDeContas.Models;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Security.Cryptography;

namespace ControleDeContas.Controllers
{
    public class MovimentacaoController : Controller
    {
        private static List<Movimentacao> movimentacoes = new List<Movimentacao>()
        {
            new Movimentacao()
            {
                Id= 1,
                DataVencimento = DateTime.Today,
                DataPagamento = DateTime.Today,
                ValorDevido = 5000,
                ValorPago = 5000,
                TotalParcelas= 10,
                NumeroParcelas= 5,

            }
            
        };
        public IActionResult Index()
        {
            return View(movimentacoes);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Create(Movimentacao movimentacao)
        {
            movimentacao.Id = movimentacoes.Select(i => i.Id).Max() + 1;
            movimentacoes.Add(movimentacao);
            return RedirectToAction("Index");
        }

        public IActionResult Edit(long id)
        {
            return View(movimentacoes.Where(i => i.Id == id).First());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(Movimentacao movimentacao)
        {
            movimentacoes.Remove(movimentacoes.Where(i => i.Id == movimentacao.Id).First());
            movimentacoes.Add(movimentacao);
            return RedirectToAction("Index");
        }
        public IActionResult Details(long id)
        {
            return View(movimentacoes.Where(i => i.Id == id).First());
        }
        public IActionResult Delete(long id)
        {
            return View(movimentacoes.Where(i => i.Id == id).First());
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Delete(Movimentacao movimentacao)
        {
            movimentacoes.Remove(movimentacoes.Where((i) => i.Id == movimentacao.Id).First());
            return RedirectToAction("Index");
        }



    }
}
