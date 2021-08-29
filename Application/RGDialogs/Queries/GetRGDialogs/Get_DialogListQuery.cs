using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.RGDialogs.Queries.GetRGDialogs
{
    public class Get_DialogListQuery : IRequest<Dialog_List_VM>
    {
        public List<Guid> Clients { get; set; }
    }
}
