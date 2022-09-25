using FluentValidation;

namespace WebApi.Application.BookOperations.Commands.CreateBook
{
    public class CreateBookCommandValidator : AbstractValidator<CreateBookCommand>
    {
        public CreateBookCommandValidator()
        {
            ValidatorOptions.Global.CascadeMode = CascadeMode.Continue;
            RuleFor(command=>command.Model.GenreId).GreaterThan(0);
            RuleFor(command=>command.Model.PageCount).GreaterThan(0);
            RuleFor(command => command.Model.PublishDate).NotEmpty().LessThan(System.DateTime.Now.Date);
            RuleFor(command=>command.Model.Title).NotEmpty().MinimumLength(4);
        }
    }

}