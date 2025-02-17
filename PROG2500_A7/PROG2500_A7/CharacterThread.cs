using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.Windows;

namespace PROG2500_A7
{
    public class CharacterThread
    {
        private Dorothy dorothy;
        private string characterName;
        private Color color;

        public CharacterThread(Dorothy dorothy, string characterName, Color color)
        {
            this.dorothy = dorothy;
            this.characterName = characterName;
            this.color = color;
        }

        public void Run()
        {
            Thread.Sleep(10); // Simulate some delay
            dorothy.FavoriteCharacter = characterName;
            dorothy.FavoriteColor = color;
        }
    }
}

// below vv reading out the battle for favorite line by line
//Application.Current.Dispatcher.Invoke(() =>
//{
//    ((MainWindow)Application.Current.MainWindow).Text_Output.AppendText(
//        $"{characterName} set favorite character to {dorothy.FavoriteCharacter} and color to {dorothy.FavoriteColor}\n");
//});
