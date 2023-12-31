using CodeFirst.Data;
using CodeFirst.Models;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirst.Controllers
{
    
    public class ClientController : Controller
    {
        private readonly ClientDbContext _dbCleintContext;
        
        public ClientController(ClientDbContext dbCleintContext)
        {
            _dbCleintContext = dbCleintContext;
        }
        public IActionResult Index()
        {
            return View(_dbCleintContext.Clients.ToList());
        }

        public IActionResult Create()
        {
            return View();
        }
        [HttpPost]
        public IActionResult Create([Bind("Id","Nom","Prenom","Ville")] Client client)
        {
            _dbCleintContext.Add(client);
            _dbCleintContext.SaveChanges();
            return RedirectToAction("Index");
        }

        public IActionResult Edit(int id)
        {
            var client=_dbCleintContext.Clients.Find(id);
            return View(client);
        }
        [HttpPost]
        public IActionResult Edit([Bind("Id", "Nom", "Prenom", "Ville")] Client client)
        {
            _dbCleintContext.Update(client);
            _dbCleintContext.SaveChanges();
            return RedirectToAction("Index");
        }

        
        public IActionResult Delete(int id)
        {
            var client = _dbCleintContext.Clients.Find(id);
            if(client != null)
            {
                _dbCleintContext.Clients.Remove(client);
                _dbCleintContext.SaveChanges();
            }
            return RedirectToAction("Index");
        }
    }
}
