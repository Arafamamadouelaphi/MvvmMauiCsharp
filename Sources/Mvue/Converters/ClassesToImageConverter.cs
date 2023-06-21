using System;
using System.Globalization;
using Model;

namespace Mvue.Converters
{
    public class ClassesToImageConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return null;
            var Classe = (ChampionClass)value;

            switch (Classe)
            {
                case ChampionClass.Assassin:
                    return "assassin_icon.png";
                    break;
                         case ChampionClass.Mage:
                    return "mage_icon?png";
                    break;
                        case ChampionClass.Marksman:
                    return "marksman_icon.png";
                    break;
                case ChampionClass.Fighter:
                    return "fighter_icon.png";
                    break;
                case ChampionClass.Support:
                    return "support_icon.png";
                case ChampionClass.Tank:
                    return "tank_icon.png";
          
                default:
                    return null;
            }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}

