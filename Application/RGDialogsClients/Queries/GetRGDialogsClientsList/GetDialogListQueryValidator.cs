using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RGDialogsClients.Queries.GetRGDialogsClientsList
{
    public class GetDialogListQueryValidator : AbstractValidator<GetDialogListQuery>
    {
        public GetDialogListQueryValidator()
        {

        }
    }
}
