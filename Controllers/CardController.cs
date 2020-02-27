using API.Models;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;

namespace API.Controllers {

	[Route("api/[controller]")]
	public class CardController : Controller {
		private readonly Data.CardContext context = null;

		public CardController(Data.CardContext context) {
			this.context = context;
		}

		public IEnumerable<Card> activeCards {
			get => context?.Cards?.Where(card => card.ACTIVE);
		}

		public IEnumerable<Card> ActiveCardByType(CardType type)
			=> activeCards.Where(card => type == card.TYPE);

		[HttpGet()]
		public ActionResult Find(int id, string type) {
			var card = context?.Cards?.FirstOrDefault(iter => id == iter.ID);
			if (null == card) return NotFound();
			// 타입을 지정했으면 찾은 카드가 해당 타입이 맞는지 체크
			if (false == string.IsNullOrEmpty(type)) {
				CardType parsedType;
				if (System.Enum.TryParse(type, true, out parsedType)) {
					if (parsedType != card.TYPE) return BadRequest();
				} else return BadRequest();
			}
			return Json(card);
		}

		[HttpGet("all")]
		public ActionResult AllCards(string type) {
			CardType targetType;
			if (false == System.Enum.TryParse(type, true, out targetType)) {
				// type에 뭔가가 있는데 파싱 실패인 경우, BadRequest. 아니면 하수인 목록 반환
				if (false == string.IsNullOrEmpty(type)) return BadRequest();

				targetType = CardType.MINION;
			}

			var cards = ActiveCardByType(targetType);
			if (0 == cards.Count()) return NotFound();
			return Json(cards);
		}

		[HttpGet("gold")]
		public ActionResult GoldCard(int id) {
			var card = activeCards.FirstOrDefault(iter => id == iter.ID);
			if (null == card || card.IS_GOLD) return NotFound();
			if (CardType.MINION != card.TYPE) return BadRequest();

			var gold = activeCards
				.FirstOrDefault(c => c.IS_GOLD && c.NAME.Equals(card.NAME));
			if (null == gold) return NotFound();
			return Json(gold);
		}
	}
}