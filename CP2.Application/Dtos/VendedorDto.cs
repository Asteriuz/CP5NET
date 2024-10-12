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
                .NotEmpty().WithMessage("O nome deve ser preenchido.")
                .Length(3, 100).WithMessage("O nome deve ter entre 3 e 100 caracteres.");

            RuleFor(v => v.Email)
                .NotEmpty().WithMessage("O e-mail não pode estar vazio.")
                .EmailAddress().WithMessage("Insira um e-mail válido.");

            RuleFor(v => v.Telefone)
                .NotEmpty().WithMessage("O telefone é necessário.")
                .Matches(@"^\(\d{2}\) \d{5}-\d{4}$").WithMessage("Formato do telefone deve ser (XX) XXXXX-XXXX.");

            RuleFor(v => v.DataNascimento)
                .NotEmpty().WithMessage("A data de nascimento é essencial.")
                .LessThan(DateTime.Now).WithMessage("A data de nascimento deve ser anterior à data atual.");

            RuleFor(v => v.Endereco)
                .NotEmpty().WithMessage("O endereço deve ser informado.");

            RuleFor(v => v.DataContratacao)
                .NotEmpty().WithMessage("A data de contratação é obrigatória.")
                .GreaterThan(DateTime.Now.AddYears(-5)).WithMessage("A data de contratação deve ser nos últimos 5 anos.");

            RuleFor(v => v.ComissaoPercentual)
                .GreaterThan(0).WithMessage("O percentual de comissão deve ser maior que zero.")
                .LessThanOrEqualTo(50).WithMessage("O percentual de comissão não pode exceder 50.");

            RuleFor(v => v.MetaMensal)
                .GreaterThan(0).WithMessage("A meta mensal deve ser positiva.");
        }

    }
}
