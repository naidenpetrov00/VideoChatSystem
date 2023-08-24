namespace VideoChatSystem.Services
{
	using System.Threading;
	using VideoChatSystem.Models;
	using VideoChatSystem.Services.Interfaces;

	public class UsersService : IUsersService
	{
		private ICollection<User> users;

		public UsersService()
		{
			this.users = new HashSet<User>();
		}

		public User Add(string connectionId, string userId)
		{
			var user = new User
			{
				ConnectionId = connectionId,
				UserId = userId
			};
			this.users.Add(user);

			return user;
		}

		public User GetUserById(string connectionId)
		{
			return this.users.FirstOrDefault(u => u.ConnectionId.Equals(connectionId));
		}
	}
}
