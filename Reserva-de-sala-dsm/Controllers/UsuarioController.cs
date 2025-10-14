﻿using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis.CSharp.Syntax;
using Reserva_de_sala_dsm.Interfaces;
using Reserva_de_sala_dsm.Models;
using System.Linq.Expressions;

namespace Reserva_de_sala_dsm.Controllers
{
    public class UsuarioController : Controller
    {
        private readonly IUsuarioService _usuarioService;

        public UsuarioController(IUsuarioService usuarioService)
        {
            _usuarioService = usuarioService;
        }
        
        //Get /Usuario
        public async Task<IActionResult> Index()
        {
            var usuarios = await _usuarioService.GetAllAsync();
            return View(usuarios);
        }

        //GET /Usuarios/Details/id
        public async Task<IActionResult> Details(long id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);

            if(usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        //GET /Usuario/Create
        public IActionResult Create()
        {
            return View();
        }

        //POST /Usuario/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Usuario usuario)
        {
            if(ModelState.IsValid)
            {
                try
                {
                    await _usuarioService.CreateAsync(usuario);
                    return RedirectToAction(nameof(Index));
                }
                catch(InvalidOperationException ex)
                {
                    ModelState.AddModelError(string.Empty, ex.Message);
                }
            }
            return View(usuario);
        }

        //GET /Usuario/Edit/Id
        public async Task<IActionResult> Edit(long id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if(usuario == null)
            {
                return NotFound();
            }

            return View(usuario);
        }

        //POST /Usuario/Edit/Id
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(long id, Usuario usuario)
        {
            if(id != usuario.Id)
            {
                return BadRequest();
            }

            if (ModelState.IsValid)
            
            try
            {
                await _usuarioService.UpdateAsync(usuario);
                return RedirectToAction(nameof(Index));   
                
            }
            catch(InvalidOperationException ex)
            {
                ModelState.AddModelError(string.Empty, ex.Message);
            }
            return View(Usuario);
        }
        

        //GET /Usuario/Delete/id
        public async Task<IActionResult> Delete(long id)
        {
            var usuario = await _usuarioService.GetByIdAsync(id);
            if (usuario == null)
            {
                return NotFound();
            }
            return View(usuario);
        }

        //POST /Usuario/Delete/id
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task <IActionResult> DeleteConfirmed(long id)
        {
            await _usuarioService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

    }
}
