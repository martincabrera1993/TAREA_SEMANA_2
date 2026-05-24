using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using Web_Clientes.Models;

namespace Web_Clientes.Controllers
{
    public class ClientesController : Controller
    {
        // Base de Datos en memoria
    private static
    List<ClienteModel> _lista_Clientes = new List<ClienteModel>() {
        new ClienteModel{

                id = 1,

                Nombres_Cliente="Martin",

                Apellidos = "Cabrera",

                Direccion = "Quito",

                Telefono = "0958739363",

                Correo = "Martin_mc@hotmail.com"},

            new ClienteModel{

                id = 2,

                Nombres_Cliente="Sebastian",

                Apellidos = "Morocho",

                Direccion = "Quito",

                Telefono = "0999999999",

                Correo = "sebas123@gmail.com"},

        };

        // GET: ClientesController
        public ActionResult Index()
        {
            return View(_lista_Clientes);
        }

        // GET: ClientesController/Details/5
        public ActionResult Details(int id)
        {
            var cliente = _lista_Clientes.FirstOrDefault(c => c.id == id);
            if (cliente == null) return NotFound();
             return View(cliente);
            }

        // GET: ClientesController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ClientesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ClienteModel cliente)
        {
            if (ModelState.IsValid)
            {
                cliente.id = _lista_Clientes.Count > 0
                    ? _lista_Clientes.Max(c => c.id) + 1 : 1;

                _lista_Clientes.Add(cliente);
                return RedirectToAction(nameof(Index));

            }
            else
                return View(cliente);
            }

        // GET: ClientesController/Edit/5
        public ActionResult Edit(int id)
        {
            var cliente = _lista_Clientes.FirstOrDefault(c => c.id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, ClienteModel cliente)
        {
            if (cliente == null) return BadRequest("Datos del cliente inválidos");
            if (id != cliente.id) return BadRequest("No se enconto el cliente");

            var clienteExistente = _lista_Clientes.FirstOrDefault(c => c.id == id);
            if (cliente  == null) return NotFound();

            clienteExistente.Nombres_Cliente = cliente.Nombres_Cliente;
            clienteExistente.Apellidos = cliente.Apellidos;
            clienteExistente.Direccion = cliente.Direccion;
            clienteExistente.Telefono = cliente.Telefono;
            clienteExistente.Correo = cliente.Correo;

            return RedirectToAction(nameof(Index));
        }

        // GET: ClientesController/Delete/5
        public ActionResult Delete(int id)
        {
            var cliente = _lista_Clientes.FirstOrDefault(c => c.id == id);
            if (cliente == null) return NotFound();
            return View(cliente);
        }

        // POST: ClientesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            var cliente = _lista_Clientes.FirstOrDefault(c => c.id == id);
            if (cliente == null) return NotFound();
            _lista_Clientes.Remove(cliente);
            return RedirectToAction(nameof(Index));
        }
    }
}
