using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Core;
using System.Linq;
using Application.RGDialogsntsFolder.Queries.GetRGDialogsClientsList;

namespace Application.RGDialogsClientsFolder.Queries.GetRGDialogsClientsList
{
    public class GetDialogListQueryHandler : IRequestHandler<GetDialogListQuery, DialogListVm>
    {
        public GetDialogListQueryHandler() { }

        public async Task<DialogListVm> Handle(GetDialogListQuery request, CancellationToken cancellationToken)
        {
            Task<DialogListVm> dialogList = new Task<DialogListVm>(() =>
            {
                DialogListVm dialogListVm = new DialogListVm();

                RGDialogsClients fff = new RGDialogsClients();
                var dialogs = fff.Init().Where(a =>
                {
                    foreach (var dial in request?.Clients)
                    {
                        return a.IDClient == dial;
                    }
                    return false;
                });





                return dialogListVm;
            });
            dialogList.Start();

            return await dialogList;
        }
    }
}
