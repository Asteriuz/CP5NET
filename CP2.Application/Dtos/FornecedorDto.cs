using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class FornecedorDto : IFornecedorDto
    {
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Endereco { get; set; }
        public string Telefone { get; set; }
        public string Email { get; set; }

        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new FornecedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class FornecedorDtoValidation : AbstractValidator<FornecedorDto>
    {
        public FornecedorDtoValidation()
        {
            RuleFor(f => f.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .Length(2, 100).WithMessage("O Nome deve ter entre 2 e 100 caracteres.");

            RuleFor(f => f.CNPJ)
                .NotEmpty().WithMessage("CNPJ é obrigatório.")
                .Matches(@"^\d{2}\.\d{3}\.\d{3}/\d{4}-\d{2}$").WithMessage("CNPJ deve estar no formato XX.XXX.XXX/XXXX-XX.");

            RuleFor(f => f.Endereco)
                .NotEmpty().WithMessage("Endereço é obrigatório.");

            RuleFor(f => f.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .Matches(@"^\(\d{2}\) \d{5}-\d{4}$").WithMessage("Telefone deve estar no formato (XX) XXXXX-XXXX.");

            RuleFor(f => f.Email)
                .NotEmpty().WithMessage("Email é obrigatório.")
                .EmailAddress().WithMessage("Email deve ser válido.");
        }
    }
}
