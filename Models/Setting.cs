using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace API.Models {

	[Table("settings")]
	public class Setting {
		[Key]
		public string KEY { get; set; }
		public string VAL { get; set; }
	}
}