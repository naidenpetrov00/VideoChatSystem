namespace VideoChatSystem.Controllers
{
	using Microsoft.AspNetCore.Mvc;
	using Microsoft.AspNetCore.SignalR;
	using System.Reflection;
	using System.Text.RegularExpressions;
	using VideoChatSystem.Hubs;
	using VideoChatSystem.Models;
	using VideoChatSystem.Services.Interfaces;

	public class RoomController : Controller
	{
		private readonly IUsersService usersService;

		public RoomController(IUsersService usersService)
        {
			this.usersService = usersService;
		}

        [HttpGet("Room/{roomId}")]
		public IActionResult Create(RoomInputModel model)
		{
			return this.View(model);
		}

		[HttpPost]
		public IActionResult Create(string roomId)
		{
			var model = new RoomInputModel
			{
				RoomId = roomId
			};
			return this.RedirectToAction($"Create", model);
		}

		[HttpPost]
		public IActionResult Join(string roomId)
		{
			return this.Redirect($"/{roomId}");
		}
	}
}
