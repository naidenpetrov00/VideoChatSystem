namespace VideoChatSystem.Services.Interfaces
{
	using System.Threading;
	using VideoChatSystem.Models;

	public interface IUsersService
	{
		User Add(string connectionId, string userId);
		User GetUserById(string connectionId);
	}
}
