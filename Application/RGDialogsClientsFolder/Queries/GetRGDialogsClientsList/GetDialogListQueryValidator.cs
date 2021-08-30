using FluentValidation;

namespace Application.RGDialogsntsFolder.Queries.GetRGDialogsClientsList
{
    public class GetDialogListQueryValidator : AbstractValidator<GetDialogListQuery>
    {
        public GetDialogListQueryValidator()
        {
            RuleFor(x => x.Clients).Must(list => list.Count > 0)
                .WithMessage("Переданный список не содержит необходимых элементов, \n" +
                " ошибка валидации"); ;
        }
    }
}
