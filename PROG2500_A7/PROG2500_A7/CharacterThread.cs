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

        //Added lock object vvvv
        private object lockObject;
                                                                                        // vvvv lockObject
        public CharacterThread(Dorothy dorothy, string characterName, Color color, object lockObject)
        {
            this.dorothy = dorothy;
            this.characterName = characterName;
            this.color = color;
            this.lockObject = lockObject;
        }

        public void Run()
        {
            lock (lockObject) //  <<<<<<< Lock the object to prevent multiple threads from accessing it at the same time
            {
                
                dorothy.FavoriteCharacter = characterName;
                Thread.Sleep(1);
                dorothy.FavoriteColor = color;
            }
        }
    }
}

// below vv reading out the battle for favorite line by line
//Application.Current.Dispatcher.Invoke(() =>
//{
//    ((MainWindow)Application.Current.MainWindow).Text_Output.AppendText(
//        $"{characterName} set favorite character to {dorothy.FavoriteCharacter} and color to {dorothy.FavoriteColor}\n");
//});
