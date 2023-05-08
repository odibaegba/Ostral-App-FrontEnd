using Ostral.Core.Responses;
using Ostral.Core.ViewModel;

namespace Ostral.Core.Interfaces
{
	public interface IAuthService
	{
		Task<ResponseVM<AuthResponse>> Login(LoginVM model);
		Task<ResponseVM<AuthResponse>> Register(RegisterVM model);
	}
}
