using CP2.Domain.Entities;
using CP2.Domain.Interfaces;
using CP2.Domain.Interfaces.Dtos;

namespace CP2.Application.Services
{
    public class FornecedorApplicationService : IFornecedorApplicationService
    {
        private readonly IFornecedorRepository _repository;

        public FornecedorApplicationService(IFornecedorRepository repository)
        {
            _repository = repository;
        }

        public FornecedorEntity? DeletarDadosFornecedor(int id)
        {
            return _repository.DeletarDados(id);
        }

        public FornecedorEntity? ObterFornecedorPorId(int id)
        {
            return _repository.ObterPorId(id);
        }

        public FornecedorEntity? EditarDadosFornecedor(int id, IFornecedorDto entity)
        {
            var fornecedor = _repository.ObterPorId(id);
            if (fornecedor == null) return null;

            fornecedor.Nome = entity.Nome;
            fornecedor.CNPJ = entity.CNPJ;
            fornecedor.Endereco = entity.Endereco;
            fornecedor.Telefone = entity.Telefone;
            fornecedor.Email = entity.Email;

            return _repository.EditarDados(fornecedor);
        }

        public IEnumerable<FornecedorEntity> ObterTodosFornecedores()
        {
            return _repository.ObterTodos();
        }

        public FornecedorEntity? SalvarDadosFornecedor(IFornecedorDto entity)
        {
             var fornecedor = new FornecedorEntity
            {
                Nome = entity.Nome,
                CNPJ = entity.CNPJ,
                Endereco = entity.Endereco,
                Telefone = entity.Telefone,
                Email = entity.Email,
                CriadoEm = DateTime.Now
            };
            return _repository.SalvarDados(fornecedor);
        }
    }
}
