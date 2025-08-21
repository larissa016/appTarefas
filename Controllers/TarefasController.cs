using appTarefas.Models;
using Microsoft.AspNetCore.Mvc;

namespace appTarefas.Controllers
{
    public class TarefasController : Controller
    {
        //Lista em memorias(grava as informações apenas quando a aplicação esta rodando)
        private static List<Tarefa> _tarefa = new List<Tarefa>();
        private static int _proximoId = 1;
        private object _tarefas;

        // GET:Tarefas
        public IActionResult Index()
        {
            return View(_tarefa);//Envia a lista de tarefa como oarametro para a pagina index.
        }

        // GET: Tarefas/Create
        // GET: metodo para "pegar" a pagina Create
        public IActionResult Create()
        {
            return View();
        }
        // POST: Tarefas/Create
        [HttpPost] // Especifica que este metodo responde a requisicoes POST
        [ValidateAntiForgeryToken] // Protege contra ataques 
        public IActionResult Create(Tarefa tarefa)
        {
            if (ModelState.IsValid)
            {
                //atribui um ID inico para tarefa
                tarefa.TarefaId = _proximoId++;
                //adiciona a tarefa a lista de tarefa (_tarefas)
                _tarefa.Add(tarefa);
                //redireciona para a pagina  Index
                return RedirectToAction("Index");
            }

            return View(tarefa);

        }
        //GET : Tarefas/Edit/1
        public IActionResult Edit(int id)
        {
            // var tarefa = _tarefas[id]; //trabalhando com listas
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);

        }

        //POST : tarefas/Edit/1
        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Edit(int id, Tarefa tarefaAtualizada)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);

            tarefa.Titulo = tarefaAtualizada.Titulo;
            tarefa.Descricao = tarefaAtualizada.Descricao;
            tarefa.Concluida = tarefaAtualizada.Concluida;

            return RedirectToAction("Index");
        }


        //GET : Tarefas/Details/1
        public IActionResult Details(int id)
        {
            // var tarefa = _tarefas[id]; //trabalhando com listas
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);

        }

        //GET : Tarefas/Delete/1
        public IActionResult Delete(int id)
        {
            // var tarefa = _tarefas[id]; //trabalhando com listas
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            return View(tarefa);

        }


        // POST: Tarefas/Delete/1
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public IActionResult DeleteConfirmed(int id)
        {
            var tarefa = _tarefas.FirstOrDefault(t => t.TarefaId == id);
            if (tarefa != null)
            {
                _tarefas.Remove(tarefa);
            }
            return RedirectToAction("Index");
        }
    }
}
