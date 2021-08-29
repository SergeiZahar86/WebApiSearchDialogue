using AutoMapper;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Application.RGDialogsClients.Queries.GetRGDialogsClientsList
{
    public class GetDialogListQueryHandler : IRequestHandler<GetDialogListQuery, DialogListVm>
    {


        public Task<DialogListVm> Handle(GetDialogListQuery request, CancellationToken cancellationToken)
        {
            throw new System.NotImplementedException();
        }
    }
}
