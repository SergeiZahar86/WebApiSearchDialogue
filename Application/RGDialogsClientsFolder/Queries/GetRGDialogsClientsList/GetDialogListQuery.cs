using MediatR;
using System;
using System.Collections.Generic;

namespace Application.RGDialogsntsFolder.Queries.GetRGDialogsClientsList
{
    public class GetDialogListQuery : IRequest<DialogListVm>
    {
        public List<Guid> Clients { get; set; }
    }
}
