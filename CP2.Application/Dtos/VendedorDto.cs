using CP2.Domain.Interfaces.Dtos;
using FluentValidation;

namespace CP2.Application.Dtos
{
    public class VendedorDto : IVendedorDto
    {
        public string Nome { get; set; }
        public string Email { get; set; }
        public string Telefone { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Endereco { get; set; }
        public DateTime DataContratacao { get; set; }
        public decimal ComissaoPercentual { get; set; }
        public decimal MetaMensal { get; set; }
        public DateTime CriadoEm { get; set; }

        public void Validate()
        {
            var validateResult = new VendedorDtoValidation().Validate(this);

            if (!validateResult.IsValid)
                throw new Exception(string.Join(" e ", validateResult.Errors.Select(x => x.ErrorMessage)));
        }
    }

    internal class VendedorDtoValidation : AbstractValidator<VendedorDto>
    {
        public VendedorDtoValidation()
        {
            RuleFor(v => v.Nome)
                .NotEmpty().WithMessage("Nome é obrigatório.")
                .Length(2, 100).WithMessage("O Nome deve ter entre 2 e 100 caracteres.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("Email é obrigatório.")
                .EmailAddress().WithMessage("Email deve ser válido.");

            RuleFor(v => v.Telefone)
                .NotEmpty().WithMessage("Telefone é obrigatório.")
                .Matches(@"^\(\d{2}\) \d{5}-\d{4}$").WithMessage("Telefone deve estar no formato (XX) XXXXX-XXXX.");

            RuleFor(v => v.DataNascimento)
                .NotEmpty().WithMessage("Data de nascimento é obrigatória.")
                .LessThan(DateTime.Now).WithMessage("Data de nascimento deve ser anterior à data atual.");

            RuleFor(v => v.Endereco)
                .NotEmpty().WithMessage("Endereço é obrigatório.");

            RuleFor(v => v.DataContratacao)
                .NotEmpty().WithMessage("Data de contratação é obrigatória.")
                .GreaterThan(DateTime.Now.AddYears(-10)).WithMessage("Data de contratação deve ser nos últimos 10 anos.");

            RuleFor(v => v.ComissaoPercentual)
                .GreaterThan(0).WithMessage("Percentual de comissão deve ser maior que zero.")
                .LessThanOrEqualTo(100).WithMessage("Percentual de comissão deve ser no máximo 100.");

            RuleFor(v => v.MetaMensal)
                .GreaterThan(0).WithMessage("Meta mensal deve ser maior que zero.");
        }
    }
}
