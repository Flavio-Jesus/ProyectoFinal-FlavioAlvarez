﻿using Microsoft.AspNetCore.Mvc;
using ProyectoFinal_FlavioAlvarez.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProyectoFinal_FlavioAlvarez.Controllers
{
    public class ControladorProducto : Controller
    {
        private readonly ICosmosDBServiceProducto _cosmosDbService;

        public ControladorProducto(ICosmosDBServiceProducto  cosmosDBService)
        {
            this._cosmosDbService = cosmosDBService;
        }

        public async Task<ActionResult> Producto()
        {
            return View((await this._cosmosDbService.GetProductosAsync("SELECT * FROM producto")).ToList());
        }
        public IActionResult Create()
        {
            return View();
        }

        public async Task<ActionResult> CrearProducto(Producto producto)
        {
            producto.id = Guid.NewGuid().ToString();
            await this._cosmosDbService.AddProductoAsync(producto);
            return RedirectToAction("Producto");
        }
        public IActionResult Edit(Producto producto)
        {
            return View(producto);
        }

        public async Task<ActionResult> EditProducto(Producto producto)
        {
            await this._cosmosDbService.UpdateProductoAsync(producto.id, producto);
            return RedirectToAction("Producto");
        }
        public ActionResult Delete(Producto producto)
        {
            return View(producto);
        }

        public async Task<ActionResult> DeleteProduct(Producto producto)
        {
            await _cosmosDbService.DeleteProductoAsync(producto.id);
            return RedirectToAction("Producto");
        }

    }
}
