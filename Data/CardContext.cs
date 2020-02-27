using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

namespace API.Data {

	public class CardContext : DbContext {
		public CardContext(DbContextOptions<CardContext> options) : base(options) {

		}

		public DbSet<Models.Card> Cards { get; set; }

		protected override void OnModelCreating(ModelBuilder modelBuilder) {
			var intToBool = new BoolToStringConverter("N", "Y");
			// ACTIVE : bool <-> int
			modelBuilder
				.Entity<Models.Card>()
				.Property(card => card.ACTIVE)
				.HasConversion(intToBool);
			// TYPE : CardType <-> int
			modelBuilder
				.Entity<Models.Card>()
				.Property(card => card.TYPE)
				.HasConversion(new EnumToStringConverter<Models.CardType>());
			// RANK : CardRank <-> int
			modelBuilder
				.Entity<Models.Card>()
				.Property(card => card.RANK)
				.HasConversion(new EnumToStringConverter<Models.CardRank>());
			// IS_GOLD : bool <-> int
			modelBuilder
				.Entity<Models.Card>()
				.Property(card => card.IS_GOLD)
				.HasConversion(intToBool);
			// RACE : CardRace <-> int
			modelBuilder
				.Entity<Models.Card>()
				.Property(card => card.RACE)
				.HasConversion(new EnumToStringConverter<Models.CardRace>());
		}
	}
}