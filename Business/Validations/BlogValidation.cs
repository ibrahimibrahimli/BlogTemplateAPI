using Business.BaseMessages;
using Entity.Concrete.TableModels;
using FluentValidation;

namespace Business.Validations
{
    public class BlogValidation : AbstractValidator<Blog>
    {
        public BlogValidation()
        {
            RuleFor(x => x.Description)
                .MinimumLength(100)
                .WithMessage(UIMessages.MINIMUM_100_SYMBOL_MESSAGE)
                .MaximumLength(3000)
                .WithMessage(UIMessages.MAXIMUM_3000_SYMBOL_MESSAGE)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE);

            RuleFor(x => x.Title)
                .MinimumLength(3)
                .WithMessage(UIMessages.MINIMUM_3_SYMBOL_MESSAGE)
                .MaximumLength(1000)
                .WithMessage(UIMessages.MAXIMUM_1000_SYMBOL_MESSAGE)
                .NotEmpty()
                .WithMessage(UIMessages.NOT_EMPTY_MESSAGE);
        }
    }
}
