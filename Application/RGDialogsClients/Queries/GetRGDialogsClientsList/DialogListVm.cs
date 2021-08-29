using System;
using System.Collections.Generic;

namespace Application.RGDialogsClients.Queries.GetRGDialogsClientsList
{
    /// <summary>
    /// viewmodel запроса списка диалогов
    /// </summary>
    public class DialogListVm 
    {
        /// <summary>
        /// список клиентов
        /// </summary>
        public List<Guid> Dialogs { get; set; }
    }
}
