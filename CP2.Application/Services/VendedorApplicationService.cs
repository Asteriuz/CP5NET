using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class VendedorApplicationService : IVendedorApplicationService
    {
        private readonly IVendedorRepository _repository;

        public VendedorApplicationService(IVendedorRepository repository)
        {
            _repository = repository;
        }
        public VendedorEntity? DeletarDadosVendedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public VendedorEntity? EditarDadosVendedor(int id, IVendedorDto entity)
        {
            entity.Validate();

            var vendedor = _repository.ObterPorId(id);
            if (vendedor == null) return null;

            vendedor.Nome = entity.Nome;
            vendedor.Email = entity.Email;
            vendedor.Telefone = entity.Telefone;
            vendedor.DataNascimento = entity.DataNascimento;
            vendedor.Endereco = entity.Endereco;
            vendedor.DataContratacao = entity.DataContratacao;
            vendedor.ComissaoPercentual = entity.ComissaoPercentual;
            vendedor.MetaMensal = entity.MetaMensal;

            return _repository.EditarDados(vendedor);
        }

        public IEnumerable<VendedorEntity> ObterTodosVendedores()
        {
            return _repository.ObterTodos();
        }

        public VendedorEntity? ObterVendedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public VendedorEntity? SalvarDadosVendedor(IVendedorDto entity)
        {
            entity.Validate();

            var vendedor = new VendedorEntity
            {
                Nome = entity.Nome,
                Email = entity.Email,
                Telefone = entity.Telefone,
                DataNascimento = entity.DataNascimento,
                Endereco = entity.Endereco,
                DataContratacao = entity.DataContratacao,
                ComissaoPercentual = entity.ComissaoPercentual,
                MetaMensal = entity.MetaMensal,
                CriadoEm = DateTime.Now
            };

            return _repository.SalvarDados(vendedor);
        }
    }
}
