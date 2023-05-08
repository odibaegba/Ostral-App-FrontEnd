using Microsoft.AspNetCore.Mvc;
using Ostral.Core.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Ostral.Core.Interfaces
{
    public interface IUserAuthService
    {
        Task<LoginVM> Login();
        Task<ChallengeResult> ExternalLogin();
    }
}
