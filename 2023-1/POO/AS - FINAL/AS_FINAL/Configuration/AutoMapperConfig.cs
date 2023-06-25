using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Domain.Entities;
using AS_FINAL.Domain.ViewModels;
using AutoMapper;

namespace AS_FINAL.Configuration
{
    public class AutoMapperDTOs : Profile
    {
        public AutoMapperDTOs()
        {
            CreateMap<Autor, AutorDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<AutorDTO, Autor>().PreserveReferences().MaxDepth(0);
            CreateMap<Livro, LivroDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<LivroDTO, Livro>().PreserveReferences().MaxDepth(0);
            CreateMap<Usuario, UsuarioDTO>().PreserveReferences().MaxDepth(0);
            CreateMap<UsuarioDTO, Usuario>().PreserveReferences().MaxDepth(0);
        }
    }

    public class AutoMapperViewModels : Profile
    {
        public AutoMapperViewModels()
        {
            CreateMap<AutorViewModel, Autor>();
            CreateMap<Autor, AutorViewModel>();
            CreateMap<LivroViewModel, Livro>();
            CreateMap<Livro, LivroViewModel>();
            CreateMap<UsuarioViewModel, Usuario>();
            CreateMap<Usuario, UsuarioViewModel>();
        }
    }
}
