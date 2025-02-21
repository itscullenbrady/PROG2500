using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Dog : AnimalClass
    {
        // Constructor
        public Dog(int r)
        {
            this.R = r;
            this.SpeedX = 2;
            this.SpeedY = 2;
        }

        public int R { get; set; }

        // Implement the abstract Voice method
        public override void Voice()
        {
            Console.WriteLine("Bark!");
        }

        // Implement the abstract Move method
        public override void Move()
        {
            // Default move is 2,2
            Move(2, 2);
        }

        // Method to move in any direction
        public void Move(int dx, int dy)
        {
            // Ensure speed components do not exceed 4
            this.SpeedX = Math.Min(dx, 4);
            this.SpeedY = Math.Min(dy, 4);

            // Update position based on speed
            this.X += this.SpeedX;
            this.Y += this.SpeedY;
        }
    }
}
