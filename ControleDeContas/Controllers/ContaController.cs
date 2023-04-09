using ControleDeContas.Models;
using Microsoft.AspNetCore.Mvc;

namespace ControleDeContas.Controllers
{
    public class ContaController : Controller
    {
        private static IList<Conta> contas = new List<Conta>()
        {
            new Conta()
            {
                Id= 1,
                Nome = "Pedro",
                Detalhes = "Conta poupança",
            },
        };
        public IActionResult Index()
        {
            return View(contas);
        }
   

public IActionResult Create()
{
    return View();
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Create(Conta conta)
{
    conta.Id = contas.Select(i => i.Id).Max() + 1;
    contas.Add(conta);
    return RedirectToAction("Index");
}

public IActionResult Edit(long id)
{
    return View(contas.Where(i => i.Id == id).First());
}

[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Edit(Conta conta)
{
    contas.Remove(contas.Where(i => i.Id == conta.Id).First());
    contas.Add(conta);
    return RedirectToAction("Index");
}
public IActionResult Details(long id)
{
    return View(contas.Where(i => i.Id == id).First());
}
public IActionResult Delete(long id)
{
    return View(contas.Where(i => i.Id == id).First());
}
[HttpPost]
[ValidateAntiForgeryToken]
public IActionResult Delete(Movimentacao conta)
{
    contas.Remove(contas.Where((i) => i.Id == conta.Id).First());
    return RedirectToAction("Index");
}



    }
}
