using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using VideoChatSystem.Models;

namespace VideoChatSystem.Controllers
{
	public class HomeController : Controller
	{
		public IActionResult Index()
		{
			return this.View();
		}
	}
}