using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoChatSystem.Models;

namespace VideoChatSystem.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return this.Redirect($"/room={Guid.NewGuid()}");
		}

		[HttpGet("/room={roomId}")]
		public IActionResult Room(string roomId)
		{
			var roomModel = new RoomInputModel
			{
				RoomId = roomId,
			};
			return this.View(roomModel);
		}
	}
}