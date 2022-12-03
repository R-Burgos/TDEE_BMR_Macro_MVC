using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace TDEE_BMR_Macro_MVC.Models
{
    public class UserModel
    {
        public double Weight { get; set; }
        public double Height { get; set; }
        [DisplayName ("Activity")]
        public string ActivityLevel { get; set; }
        public string Gender { get; set; }
        [Range (1, 100)]
        public int Age { get; set; }
        [DisplayName("Diet Modifier")]
        public int CalorieTargetModifier { get; set; }  // 1,2,3,4,5
        [DisplayName("Macro Distribution")]
        public int CarbLevel { get; set; } // 1,2,3
        public double TDEE { get; set; }
        public double BMR { get; set; }
        public void GoalCalories(UserModel user)
        {
            switch (user.CalorieTargetModifier)
            {
                case 1:
                    user.DietCalories = Math.Round(user.TDEE - 500, 0, MidpointRounding.AwayFromZero);
                    break;
                case 2:
                    user.DietCalories = Math.Round(user.TDEE - 250, 0, MidpointRounding.AwayFromZero);
                    break;
                case 3:
                    user.DietCalories = Math.Round(user.TDEE, 0);
                    break;
                case 4:
                    user.DietCalories = Math.Round(user.TDEE + 250, 0, MidpointRounding.AwayFromZero);
                    break;
                case 5:
                    user.DietCalories = Math.Round(user.TDEE + 500, 0, MidpointRounding.AwayFromZero);
                    break;
                default:
                    user.DietCalories = Math.Round(user.TDEE, 0);
                    break;
            }
        }
        [DisplayName("Target Calories")]
        public double DietCalories { get; set; }
        public void GetMacros(UserModel user)
        {
            switch (user.CarbLevel)
            {
                case 1: // P30/F35/C35
                    user.ProteinCalories = Math.Round(user.DietCalories * 0.3, 0, MidpointRounding.AwayFromZero);
                    user.Protein = Math.Round(user.ProteinCalories / 4, 0, MidpointRounding.AwayFromZero);
                    user.FatCalories = Math.Round(user.DietCalories * 0.35, 0, MidpointRounding.AwayFromZero);
                    user.Fat = Math.Round(user.FatCalories / 9, 0, MidpointRounding.AwayFromZero);
                    user.CarbohydrateCalories = Math.Round(user.DietCalories * 0.35, 0, MidpointRounding.AwayFromZero);
                    user.Carbohydrate = Math.Round(user.CarbohydrateCalories / 4, 0, MidpointRounding.AwayFromZero);
                    break;
                case 2: // P40/F40/C20
                    user.ProteinCalories = Math.Round(user.DietCalories * 0.4, 0, MidpointRounding.AwayFromZero);
                    user.Protein = Math.Round(user.ProteinCalories / 4, 0, MidpointRounding.AwayFromZero);
                    user.FatCalories = Math.Round(user.DietCalories * 0.4, 0, MidpointRounding.AwayFromZero);
                    user.Fat = Math.Round(user.FatCalories / 9, 0, MidpointRounding.AwayFromZero);
                    user.CarbohydrateCalories = Math.Round(user.DietCalories * 0.2, 0, MidpointRounding.AwayFromZero);
                    user.Carbohydrate = Math.Round(user.CarbohydrateCalories / 4, 0, MidpointRounding.AwayFromZero);
                    break;
                case 3: // P30/F20/C50
                    user.ProteinCalories = Math.Round(user.DietCalories * 0.3, 0, MidpointRounding.AwayFromZero);
                    user.Protein = Math.Round(user.ProteinCalories / 4, 0, MidpointRounding.AwayFromZero);
                    user.FatCalories = Math.Round(user.DietCalories * 0.2, 0, MidpointRounding.AwayFromZero);
                    user.Fat = Math.Round(user.FatCalories / 9, 0, MidpointRounding.AwayFromZero);
                    user.CarbohydrateCalories = Math.Round(user.DietCalories * 0.5, 0, MidpointRounding.AwayFromZero);
                    user.Carbohydrate = Math.Round(user.CarbohydrateCalories / 4, 0, MidpointRounding.AwayFromZero);
                    break;
            }
        }
        public double Protein { get; set; }
        public double ProteinCalories { get; set; }
        public double Fat { get; set; }
        public double FatCalories { get; set; }
        public double Carbohydrate { get; set; }
        public double CarbohydrateCalories { get; set; }
    }
}
