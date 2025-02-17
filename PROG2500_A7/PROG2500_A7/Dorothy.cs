using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PROG2500_A7
{
    public enum Color { None, Silver, Brown, Yellow }

    public class Dorothy
    {
        public string FavoriteCharacter { get; set; } = "None";
        public Color FavoriteColor { get; set; } = Color.None;

        public override string ToString()
        {
            return $"Favorite Character: {FavoriteCharacter}, Favorite Color: {FavoriteColor}";
        }
    }
}