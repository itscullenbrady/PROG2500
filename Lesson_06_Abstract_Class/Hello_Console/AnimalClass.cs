using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    /// <summary>
    /// I changed the name of the class to AnimalClass
    /// </summary>
    abstract class AnimalClass
    {
        /// <summary>
        /// i removed the enum and other property
        /// </summary>

        // Location of shape as x,y coordinates
        private int x = 0;
        private int y = 0;

        // Speed of animal in x and y directions
        private int speedX = 0;
        private int speedY = 0;
        public int X
        {
            get { return x; }
            set { x = value; }
        }
        public int Y
        {
            get { return y; }
            set { y = value; }
        }
        public int SpeedX
        {
            get { return speedX; }
            set { speedX = value; }
        }
        public int SpeedY
        {
            get { return speedY; }
            set { speedY = value; }
        }

        // Use F11 in debug...when is this constructor run?
        public AnimalClass()
        {
            this.x = 0;
            this.y = 0;
            this.speedX = 0;
            this.speedY = 0;
        }

        // Methods to set and get the location
        public void moveShape(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        //Abstract method for voice and move
        abstract public void Voice();
        abstract public void Move();

        // get the x,y values
        public int getX() { return this.X; }
        public int getY() { return this.Y; }
    }
}
