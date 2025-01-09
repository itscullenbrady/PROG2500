using System;
using System.Collections.Generic;
using System.Text;

namespace Hello_Console
{
    class Chicken : AnimalClass
    {
        // Constructor
        public Chicken(int r)
        {
            this.R = r;
            this.SpeedX = 1;
            this.SpeedY = 1;
        }

        public int R { get; set; }

        // Implement the abstract Voice method
        public override void Voice()
        {
            Console.WriteLine("Buk Buk!");
        }

        // Implement the abstract Move method
        public override void Move()
        {
            // Default move is 2,2
            Move(1, 1);
        }

        // Method to move in any direction
        public void Move(int dx, int dy)
        {
            // Ensure speed components do not exceed 4
            this.SpeedX = Math.Min(dx, 3);
            this.SpeedY = Math.Min(dy, 3);

            // Update position based on speed
            this.X += this.SpeedX;
            this.Y += this.SpeedY;
        }
    }
}
