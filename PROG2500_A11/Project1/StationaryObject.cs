using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public class StationaryObject : myModel
    {
        public StationaryObject(Model m) : base(m) { }
        public StationaryObject(Model m, Vector3 pos, Vector3 vel, Color color) : base(m, pos, vel, color) { }
        public StationaryObject(Model m, Color color) : base(m, color) { }

        // Override the Move method to do nothing
        public override void Move()
        {
            // The stationary object doesn't move
        }
    }
}

