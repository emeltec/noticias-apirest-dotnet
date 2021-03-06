﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using NoticiasAPI.Models;
using NoticiasAPI.Services;

namespace NoticiasAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiaController : ControllerBase
    {
        private readonly NoticiaService _noticiaService;
        public NoticiaController(NoticiaService noticiaService)
        {
            _noticiaService = noticiaService;
        }

        [HttpGet]
        [Route("obtener")] //api/noticia/obtener
        public IActionResult Obtener()
        {
            var resultado = _noticiaService.Obtener();
            return Ok(resultado);
        }

        [HttpPost]
        [Route("agregar")] //api/noticia/agregar
        public IActionResult Agregar([FromBody] Noticia _noticia)
        {
            var resultado = _noticiaService.AgregarNoticia(_noticia);
            if (resultado)
            {
                return Ok();
            } else
            {
                return BadRequest();
            } 
        }

        [HttpPut]
        [Route("editar")] //api/noticia/editar
        public IActionResult Editar([FromBody] Noticia _noticia)
        {
            var resultado = _noticiaService.EditarNoticia(_noticia);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }

        }

        [HttpDelete]
        [Route("eliminar/{noticiaID}")]
        public IActionResult Eliminar(int noticiaID)
        {
            var resultado = _noticiaService.EliminarNoticia(noticiaID);
            if (resultado)
            {
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
