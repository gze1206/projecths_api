using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models {

	public enum CardType {
		MINION, HERO, ABILITY
	}

	public enum CardRank {
		COMMON, RARE, HEROIC, LEGENDARY
	}

	public enum CardRace {
		NONE, MURLOC, DEMON, MECH, ELEMENTAL, BEAST, DRAGON, ALL
	}

	[Table("cards")]
	public class Card {
		public int ID { get; set; }
		public bool ACTIVE { get; set; }
		public CardType TYPE { get; set; }
		public string NAME { get; set; }
		public int TIER { get; set; }
		public CardRank RANK { get; set; }
		public bool IS_GOLD { get; set; }
		public int COST { get; set; }
		public string SPRITE { get; set; }
		public string DESCRIPTION { get; set; }
		public string EFFECT { get; set; }
		public CardRace RACE { get; set; }
	}
}