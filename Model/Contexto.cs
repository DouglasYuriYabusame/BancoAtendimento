using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BancoAtendimento.Model
{
   
    public class Contexto : DbContext
    {
        public DbSet<Pagamento> Pagamentos { get; set; }
        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Prato> Prato { get; set; }
        public DbSet<Setor> Setores { get; set; }

        public DbSet<Funcionario> Funcionarios { get; set; }
        public Contexto(DbContextOptions<Contexto> opcoes) : base(opcoes)   // string para conexao
        {

        }

        #region OnModelCreating
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Funcionario>().ToTable("Funcionario");
            builder.Entity<Funcionario>().HasKey(p => p.Codigo);
            builder.Entity<Funcionario>().Property(b => b.Nome).IsRequired();
            builder.Entity<Funcionario>().Property(b => b.CodigoSetor).IsRequired();
            builder.Entity<Funcionario>().Property(b => b.Salario).HasColumnType("numeric(10,2)").IsRequired();
        }
        #endregion
    }
}
