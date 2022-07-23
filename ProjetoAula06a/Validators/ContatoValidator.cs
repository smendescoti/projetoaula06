using FluentValidation;
using ProjetoAula06a.Entities;
using ProjetoAula06a.Validators.Commons;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjetoAula06a.Validators
{
    /// <summary>
    /// Classe de validação customizada para a entidade Contato
    /// </summary>
    public class ContatoValidator : AbstractValidator<Contato>
    {
        //construtor -> [ctor] + 2x[tab]
        public ContatoValidator()
        {
            RuleFor(c => c.IdContato)
                .NotEmpty().WithMessage("O id do contato é obrigatório.");

            RuleFor(c => c.Nome)
                .NotEmpty().WithMessage("O nome do contato é obrigatório.")
                .Length(6, 150).WithMessage("O nome de ter de 6 a 150 caracteres.");

            RuleFor(c => c.Email)
                .NotEmpty().WithMessage("O email do contato é obrigatório.")
                .EmailAddress().WithMessage("O email do contato é inválido.");

            RuleFor(c => c.Cpf)
                .NotEmpty().WithMessage("O cpf do contato é obrigatório.")
                .Must(CpfValidator.IsValid).WithMessage("O cpf do contato é inválido.");

            RuleFor(c => c.Telefone)
                .NotEmpty().WithMessage("O telefone do contato é obrigatório")
                .Matches(@"^\(?\d{2}\)?[\s-]?[\s9]?\d{4}-?\d{4}$").WithMessage("O telefone do contato é inválido.");
        }
    }
}
