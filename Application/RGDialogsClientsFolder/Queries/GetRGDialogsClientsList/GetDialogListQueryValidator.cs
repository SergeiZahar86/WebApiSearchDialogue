using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RGDialogsntsFolder.Queries.GetRGDialogsClientsList
{
    public class GetDialogListQueryValidator : AbstractValidator<GetDialogListQuery>
    {
        public GetDialogListQueryValidator()
        {
            //RuleFor(x => x.Clients).NotNull(); 
            //NotEqual(Guid.Empty);
        }
    }
}
