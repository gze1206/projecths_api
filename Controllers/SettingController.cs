using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;

namespace API.Controllers {

	[Route("api/[controller]")]
	public class SettingController : Controller {
		private readonly Data.SettingContext context = null;

		public SettingController(Data.SettingContext context) {
			this.context = context;
		}

		public ActionResult Get(string key) {
			// 전달받은 키로 설정값 찾기 (대소문자 무시)
			var setting = context?.Settings
				?.FirstOrDefault(iter => key.Equals(iter.KEY, StringComparison.OrdinalIgnoreCase));
			if (null == setting) return NotFound();
			return Ok(setting.VAL);
		}
	}
}