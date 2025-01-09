using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class SuperDog : AnimalClass
    {
        // Constructor
        public SuperDog(int r)
        {
            this.R = r;
            this.SpeedX = 10;
            this.SpeedY = 10;
        }

        public int R { get; set; }

        // Implement the abstract Voice method
        public override void Voice()
        {
            Console.WriteLine("I'm Krypto!");
        }

        // Implement the abstract Move method
        public override void Move()
        {
            // Default move is 2,2
            Move(10, 10);
        }

        // Method to move in any direction
        public void Move(int dx, int dy)
        {
            // Ensure speed components do not exceed 4
            this.SpeedX = dx;
            this.SpeedY = dy;

            // Update position based on speed
            this.X += this.SpeedX;
            this.Y += this.SpeedY;
        }
    }
}
