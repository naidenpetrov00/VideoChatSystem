namespace VideoChatSystem.Hubs
{
	using Microsoft.AspNetCore.SignalR;
	using System;
	using VideoChatSystem.Models;
	using VideoChatSystem.Services.Interfaces;

	public class DefaultHub : Hub
	{
		private readonly IUsersService usersService;

		public DefaultHub(IUsersService usersService)
		{
			this.usersService = usersService;
		}

		public async Task JoinRoom(string roomId, string userId)
		{
			this.usersService.Add(Context.ConnectionId, userId);
			await Groups.AddToGroupAsync(Context.ConnectionId, roomId);
			await Clients.Group(roomId).SendAsync("user-connected", userId);
		}
		public override Task OnDisconnectedAsync(Exception? exception)
		{
			Clients.All.SendAsync("user-disconnected", this.usersService.GetUserById(Context.ConnectionId).UserId);
			return base.OnDisconnectedAsync(exception);
		}
	}
}
