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
     [Route("api/livros")]
    public class LivroController : ControllerBase
    {
        private readonly ILivroRepository _livroRepository;
        private readonly ILivroService _livroService;
        private readonly IMapper _mapper;

        public LivroController(ILivroRepository livroRepository, ILivroService livroService, IMapper mapper)
        {
            _livroRepository = livroRepository;
            _livroService = livroService;
            _mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetAllAsync()
        {
            var livros = _mapper.Map<IList<LivroDTO>>(await _livroRepository.GetAllAsync());
            return HttpMessageOk(livros);
        }
        
        [HttpGet("{id:int}")]
        public async Task<IActionResult> GetByIdAsync(int id)
        {
            var livro = _mapper.Map<LivroDTO>(await _livroRepository.GetByIdAsync(id));
            return HttpMessageOk();
        }

        [HttpPost]
        public async Task<IActionResult> AddAsync(LivroViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var livro = _mapper.Map<Livro>(model);
            var result = await _livroService.Add(livro);

            if (!result) return HttpMessageError("Dados invalidos");

            return HttpMessageOk(_mapper.Map<LivroDTO>(livro));
        }

        [HttpDelete("{id:int}")]
        public async Task<IActionResult> RemoveAsync(int id)
        {
            var livro = await _livroRepository.GetByIdAsync(id);

            if (livro == null) return NotFound();

            var result = await _livroService.Remove(id);

            if (!result) return HttpMessageError("Não foi possível remover o livro");

            return HttpMessageOk(id);
        }

        [HttpPut("{id:int}")]
        public async Task<IActionResult> UpdateAsync(int id, LivroViewModel model)
        {
            if (!ModelState.IsValid) return HttpMessageError("Dados incorretos");

            var livro = _mapper.Map<Livro>(model);
            var result = await _livroService.Update(livro);

            if (!result) return HttpMessageError("Dados invalidos");

            return HttpMessageOk(_mapper.Map<LivroDTO>(livro));
        }

        private IActionResult HttpMessageOk(dynamic data = null)
        {
            if (data == null)
                return NoContent();
            else
                return Ok(new
                {
                    data
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