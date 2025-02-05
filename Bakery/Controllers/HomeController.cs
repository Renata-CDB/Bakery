﻿using Bakery.Data.Interface;
using Bakery.Dominio.Dto;
using Bakery.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bakery.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class HomeController : ControllerBase
    {
        private readonly IUsuarioRepositorio _usuarioRepositorio;

        public HomeController(IUsuarioRepositorio usuarioRepositorio)
        {
            _usuarioRepositorio = usuarioRepositorio;
        }

        [HttpPost]
        [Route("Login")]
        public IActionResult Login([FromBody] LoginDTO login) 
        {
            try
            {
                if (!login.ValidaLogin())
                    return BadRequest("Email e/ou senha não devem ser vazias.");
                
                var usuario = _usuarioRepositorio.Login(login);
                if (usuario == null)
                    return NotFound("Email e/ou senha não corresponde(m).");

                var token =  TokenService.GerarToken(usuario);

                return Ok(token);

            }
            catch (Exception e)
            {

                return StatusCode(StatusCodes.Status500InternalServerError);
            }
        
        }
    }
}
