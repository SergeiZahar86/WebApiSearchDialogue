using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Core;
using System.Linq;
using Application.RGDialogsntsFolder.Queries.GetRGDialogsClientsList;
using System;
using System.Collections.Generic;
using Application.Common.Exception;

namespace Application.RGDialogsClientsFolder.Queries.GetRGDialogsClientsList
{
    public class GetDialogListQueryHandler : IRequestHandler<GetDialogListQuery, DialogListVm>
    {
        public GetDialogListQueryHandler() { }

        public async Task<DialogListVm> Handle(GetDialogListQuery request, CancellationToken cancellationToken)
        {
            Task<DialogListVm> dialogList = new Task<DialogListVm>(() =>
            {
                DialogListVm dialogListVm = new();
                dialogListVm.Dialogs = new List<Guid>();

                RGDialogsClients rgDialogsClients = new();

                // получение всех RGDialogsClients где фигурируют искомые клиенты
                List<RGDialogsClients> rg_dialogs_clients = new();
                foreach(RGDialogsClients rgdc in rgDialogsClients.Init())
                {
                    foreach(Guid cl in request.Clients)
                    {
                        if (rgdc.IDClient == cl)
                            rg_dialogs_clients.Add(rgdc);
                    }
                }
                //if (rg_dialogs_clients.Count == 0)
                //{
                //    throw new NotFoundException(nameof(RGDialogsClients), request.Clients);
                //}

                // поиск клиента с наименьшим количеством RGDialogsClients
                if (request.Clients.Count > 1 && rg_dialogs_clients != null)
                {
                    int count = int.MaxValue;
                    Guid client = Guid.Empty;

                    foreach (Guid guid_client in request.Clients)
                    {
                        int count_dialog = rg_dialogs_clients
                        .Count(c => c.IDClient == guid_client);
                        if (count_dialog < count)
                        {
                            count = count_dialog;
                            client = guid_client;
                        }
                    }


                    // получение коллекции RGDialog для клиента с наименьшим
                    // количеством записей
                    IEnumerable<Guid> id_RGDialog = rg_dialogs_clients
                        .Where(c => c.IDClient == client)
                        .Select(c => c.IDRGDialog).Distinct();


                    foreach (var dialig in id_RGDialog)
                    {
                        // получили клиентов участвующих в диалоге
                        IEnumerable<Guid> list_clt = rg_dialogs_clients
                        .Where(c => c.IDRGDialog == dialig)
                        .Select(c => c.IDClient);

                        IEnumerable<Guid> intersect = list_clt.Intersect(request.Clients);

                        if(intersect.Count() == request.Clients.Count)
                        {
                            dialogListVm.Dialogs.Add(dialig);
                        }
                        continue;
                    }

                    if (dialogListVm.Dialogs.Count == 0)
                        dialogListVm.Dialogs.Add(Guid.Empty);
                }

                if(request.Clients.Count == 1 && rg_dialogs_clients != null)
                {
                    IEnumerable<Guid> dialogs = rg_dialogs_clients.Select(c => c.IDRGDialog);
                    dialogListVm.Dialogs.AddRange(dialogs);
                }

                return dialogListVm;
            });
            dialogList.Start();

            return await dialogList;
        }
    }
}
