using System.ComponentModel.DataAnnotations;

namespace NewDyCalcWasm.Data
{
    public class MealInfo
    {
        public int Position { get; set; }
        [Required]
        public string BoxId { get;  set; } = string.Empty;
        [Required]
        public string BoxPosition { get;  set; } = string.Empty;

        [Required]
        public string BoxName { get; set; } = string.Empty;
        [Required]
        public int? BoxPiecesPerCartonBox { get; set; }
        [Required]
        public int? BoxPiecesPerPlasticCase { get; set; }
        [Required]
        public string BoxColor { get;  set; } = string.Empty;
        [Required]
        public string HotMealId { get;  set; } = string.Empty;
        [Required]
        public string HotMealPosition { get;  set; } = string.Empty;
        [Required]
        public string HotMealName { get; set; } = string.Empty;
        [Required]
        public int? HotMealPiecesPerCartonBox { get; set; }
        [Required]
        public int? HotMealPiecesPerPlasticCase { get; set; }
    }
}
