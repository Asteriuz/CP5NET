using CP2.Data.AppData;
using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace CP2.Data.Repositories
{
    public class VendedorRepository : IVendedorRepository
    {
        private readonly ApplicationContext _context;

        public VendedorRepository(ApplicationContext context)
        {
            _context = context;
        }

        public VendedorEntity? DeletarDados(int id)
        {
            var vendedor = _context.Vendedor.Find(id);

            if (vendedor is not null)
            {
                _context.Vendedor.Remove(vendedor);
                _context.SaveChanges();

                return vendedor;
            }

            return null;
        }

        public VendedorEntity? EditarDados(VendedorEntity entity)
        {
            _context.Vendedor.Attach(entity);
            _context.Entry(entity).State = EntityState.Modified;
            _context.SaveChanges();
            return entity;
        }

        public VendedorEntity? ObterPorId(int id)
        {
            var vendedor = _context.Vendedor.Find(id);

            if (vendedor is not null)
            {
                return vendedor;
            }

            return null;
        }

        public IEnumerable<VendedorEntity> ObterTodos()
        {
            var vendedores = _context.Vendedor.ToList();

            return vendedores;
        }

        public VendedorEntity? SalvarDados(VendedorEntity entity)
        {
            _context.Vendedor.Add(entity);
            _context.SaveChanges();

            return entity;
        }
    }
}
