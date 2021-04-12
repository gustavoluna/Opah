using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Opah.Application.Features.Clientes.Queries.RetornarCliente;
using Opah.Application.Interfaces;
using Opah.Domain.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace Opah.WebApi.Controllers.v1
{
    [ApiVersion("1.0")]
    public class ClienteController : BaseApiController
    {
        private readonly IClienteService _clienteService;

        public ClienteController(IClienteService clienteService)
        {
            _clienteService = clienteService;
        }

      

        [HttpGet("RetornarCliente/{id}")]
        public async Task<IActionResult> RetornarCliente(int id)
        {
            var result = await _clienteService.RetornarCliente(id);
            return Ok(result);
        }

        [HttpGet("RetornarClientes")]
        public async Task<IActionResult> RetornarClientes(string CodEmpresa, string Nome, string Cpf, string idCidade, string UF)
        {
            if (!string.IsNullOrEmpty(CodEmpresa))
            {
                var result = await _clienteService.RetornarClientes(CodEmpresa, Nome, Cpf, idCidade, UF);
                return Ok(result);
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpPut("AlterarCliente")]
        public async Task<IActionResult> AlterarCliente([FromBody] Cliente obj)
        {
            if (obj != null)
            {
                _clienteService.AlterarCliente(obj);
                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

        [HttpPost("InsereCliente")]
        public async Task<IActionResult> InsereCliente([FromBody] Opah.Application.DTOs.ClienteRequest obj)
        {
            if (obj != null)
            {
                try
                {
                    var ret = await _clienteService.InsereCliente(obj);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }


        [HttpDelete("DeleteCliente")]
        public async Task<IActionResult> DeleteCliente(int IdCliente)
        {
            if (IdCliente > 0)
            {
                try
                {
                    await _clienteService.DeletaCliente(IdCliente);
                }
                catch (Exception ex)
                {
                    return BadRequest();
                }

                return Ok();
            }
            else
            {
                return BadRequest();
            }
        }

    }
}
