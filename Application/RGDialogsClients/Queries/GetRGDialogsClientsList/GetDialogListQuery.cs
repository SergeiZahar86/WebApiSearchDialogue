using MediatR;
using System;
using System.Collections.Generic;

namespace Application.RGDialogsClients.Queries.GetRGDialogsClientsList
{
    public class GetDialogListQuery : IRequest<DialogListVm>
    {
        public List<Guid> Clients { get; set; }
    }
}
