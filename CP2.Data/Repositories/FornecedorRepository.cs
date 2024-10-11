using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.Repositories
{
    public class FornecedorRepository : IFornecedorRepository
    {
        private readonly ApplicationContext _context;

        public FornecedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public FornecedorEntity? DeletarDados(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);
            if (fornecedor is not null)
            {
                _context.Fornecedor.Remove(fornecedor);
                _context.SaveChanges();

                return fornecedor;
            }

            return null;
        }

        public FornecedorEntity? EditarDados(FornecedorEntity entity)
        {
            _context.Fornecedor.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public FornecedorEntity? ObterPorId(int id)
        {
            var fornecedor = _context.Fornecedor.Find(id);

            if (fornecedor is not null)
            {
                return fornecedor;
            }

            return null;
        }

        public IEnumerable<FornecedorEntity> ObterTodos()
        {
            var fornecedores = _context.Fornecedor.ToList();

            return fornecedores;
        }

        public FornecedorEntity? SalvarDados(FornecedorEntity entity)
        {
            _context.Fornecedor.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
