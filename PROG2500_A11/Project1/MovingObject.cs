using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public class MovingObject : myModel
    {
        public MovingObject(Model m) : base(m) { }
        public MovingObject(Model m, Vector3 pos, Vector3 vel, Color color) : base(m, pos, vel, color) { }
        public MovingObject(Model m, Color color) : base(m, color) { }

        // Override the Move method to update position based on velocity
        public override void Move()
        {
            pos += vel;
            rot += rot_vel;
        }
    }
}
