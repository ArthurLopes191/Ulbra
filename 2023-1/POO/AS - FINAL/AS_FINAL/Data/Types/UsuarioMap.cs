using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AS_FINAL.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace AS_FINAL.Data.Types
{
    public class UsuarioMap : IEntityTypeConfiguration<Usuario>
    {
        public void Configure(EntityTypeBuilder<Usuario> builder)
        {
            builder.ToTable("Usuario");

            builder.Property(i => i.Id).HasColumnName("id");

            builder.HasKey(i => i.Id);

            builder.Property(i => i.Nome)
                .HasColumnName("nome")
                .IsRequired()
                .HasColumnType("varchar(200)");

            builder.Property(i => i.Telefone)
                .HasColumnName("telefone")
                .IsRequired()
                .HasColumnType("varchar(50)");

            builder.Property(i => i.Documento)
                .HasColumnName("documento")
                .IsRequired()
                .HasColumnType("varchar(50)");

             builder.HasMany(u => u.LivrosEmprestados)
                .WithOne(l => l.Usuario)
                .HasForeignKey(l => l.UsuarioId)
                .HasConstraintName("FK_Usuario_Empresta_Livros")
                .OnDelete(DeleteBehavior.Restrict);
            

        }
    }
}