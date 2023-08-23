namespace VideoChatSystem.Controllers
{
	using Microsoft.AspNetCore.SignalR;

	public class DefaultHub : Hub
	{
		public async Task JoinRoom(string roomId, string userId)
		{
			await this.Groups.AddToGroupAsync(Context.ConnectionId, roomId);
			await this.Clients.Group(roomId).SendAsync("user-connected", userId);
		}
	}
}
