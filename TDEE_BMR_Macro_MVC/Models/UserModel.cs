using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TDEE_BMR_Macro_MVC.Models
{
    public class UserModel
    {
        public string Name { get; set; }
        public double Weight { get; set; }
        public double Height { get; set; }
        [DisplayName ("Activity")]
        public string ActivityLevel { get; set; }
        public string Gender { get; set; }
        [Range (1, 100)]
        public int Age { get; set; }
        [DisplayName("Diet Modifier")]
        public int CalorieTargetModifier { get; set; }
        [DisplayName("Macro Split")]
        public int CarbLevel { get; set; }
        public double TDEE { get; set; }
        public double BMR { get; set; }
    }
}
