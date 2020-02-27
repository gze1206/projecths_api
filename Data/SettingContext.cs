using Microsoft.EntityFrameworkCore;

namespace API.Data {

	public class SettingContext : DbContext {

		public SettingContext(DbContextOptions<SettingContext> options) : base(options) {
		}

		public DbSet<Models.Setting> Settings { get; set; }
	}
}