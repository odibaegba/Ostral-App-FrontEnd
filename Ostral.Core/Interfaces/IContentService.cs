using Ostral.Core.Responses;
using Ostral.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Interfaces
{
    public interface IContentService
    {
        Task<ResponseVM<ContentDetailedResponse>> GetContentById(string contentId);
    }
}
