using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RGDialogs.Queries.GetRGDialogs
{
    public class Get_DialogListQueryHandler : IRequestHandler<Get_DialogListQuery, Dialog_List_VM>
    {
        public Task<Dialog_List_VM> Handle(Get_DialogListQuery request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }
}
