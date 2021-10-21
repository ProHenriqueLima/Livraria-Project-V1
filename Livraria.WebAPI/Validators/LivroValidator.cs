using FluentValidation;
using Livraria.WebAPI.Models;

namespace Livraria.WebAPI.Validators
{
    public class LivroValidator : AbstractValidator<Livro>
    {
        public LivroValidator()
        {
            RuleFor(m => m.NomeLivro)
                .Empty()
                    .WithMessage("O campo nome do livro não pode está vazio !");
            RuleFor(n => n.AutorLivro)
                .Empty()
                    .WithMessage("O campo autor do livro não pode está vazio !");
            RuleFor(o => o.LancamentoLivro)
                .Empty()
                    .WithMessage("O Lançamento não pode está vazio !");
            RuleFor(p => p.Quantidade)
                .Empty()
                    .WithMessage("A quantidade deve ser válida ! !")
                .IsInEnum()
                    .WithMessage("Precisa ser um número !");
        }
    }
}