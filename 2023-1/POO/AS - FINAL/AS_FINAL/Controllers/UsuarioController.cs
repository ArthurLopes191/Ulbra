using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Domain.Entities;
using AS_FINAL.Domain.Interfaces;
using AS_FINAL.Domain.Interfaces.ServiceInterfaces;
using AS_FINAL.Domain.ViewModels;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;

namespace AS_FINAL.Controllers
{
    [Route("api/usuarios")]
    public class UsuarioController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly IUsuarioService _usuarioService;
        private readonly IMapper _mapper;

        public UsuarioController(IUsuarioRepository usuarioRepository, IUsuarioService usuarioService, IMapper mapper)
        {
            _usuarioRepository = usuarioRepository;
            _usuarioService = usuarioService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var usuarios = _mapper.Map<IList<UsuarioDTO>>(await _usuarioRepository.GetAllAsync());
            return HttpMessageOk(usuarios);
        }

        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var usuario = _mapper.Map<UsuarioDTO>(await _usuarioRepository.GetByIdAsync(id));
            return HttpMessageOk(usuario);
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var usuario = _mapper.Map<Usuario>(model);
            var result = await _usuarioService.Add(usuario);

            if (!result) return HttpMessageError("Dados invalidos");

            return HttpMessageOk(_mapper.Map<UsuarioDTO>(usuario));
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, UsuarioViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var usuario = _mapper.Map<Usuario>(model);
            //var result = await _autorService.Update(autor);

            //if (!result) return HttpMessageError("Dados invalidos");

            return HttpMessageOk(_mapper.Map<UsuarioDTO>(usuario));
        }

        /*
        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var produto = await _livroRepository.ObterFornecedorEndereco(id);

            if (produto == null) return NotFound();

            var result = await _livroService.Remove(id);

            if (!result) return HttpMessageError("Não foi possível remover o fornecedor");

            return HttpMessageOk(id);
        }
        */

        /*
        [HttpGet("obter-fornecedor-produto-endereco/{id:int}")]
        public async Task<IActionResult> ObterProdutosFornecedores(int id)
        {
            var fornecedor = _mapper.Map<FornecedorDTO>(await _fornecedorRepository.ObterFornecedorProdutoEndereco(id));
            return HttpMessageOk(fornecedor);
        }
        */

        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
                return NoContent();
            else
                return Ok(new
                {
                    data,
                });
        }

        private IActionResult HttpMessageError(string message = "")
        {
            return BadRequest(new
            {
                message
            });
        }
    }
}