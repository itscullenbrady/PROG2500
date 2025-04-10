using System;
using System.Linq;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Project1
{
    public abstract class myModel
    {
        // Contain the mesh, position, velocity, rotation, and color for this object
        public Model m;
        public Vector3 pos;
        public Vector3 vel;
        public Vector3 rot;
        public Vector3 rot_vel;
        public Color color;
        public bool selected;

        static GraphicsDeviceManager _graphics;

        // Constructor, set up the shape
        public myModel(Model m)
        {
            this.m = m;
            pos = Vector3.Zero;
            vel = Vector3.Zero;
            rot = Vector3.Zero;
            rot_vel = Vector3.Zero;
            color = Color.Blue;
            selected = false;
        }

        // Constructor to set up the shape with position, velocity, and color
        public myModel(Model m, Vector3 pos, Vector3 vel, Color color)
        {
            this.m = m;
            this.pos = pos;
            this.vel = vel;
            this.rot = Vector3.Zero;
            this.rot_vel = Vector3.Zero;
            this.color = color;
            selected = false;
        }

        // Constructor to set up the shape with color
        public myModel(Model m, Color color)
        {
            this.m = m;
            pos = Vector3.Zero;
            vel = Vector3.Zero;
            rot = Vector3.Zero;
            rot_vel = Vector3.Zero;
            this.color = color;
            selected = false;
        }

        public static void setupGraphics(GraphicsDeviceManager graphics)
        {
            // One and only instance of graphics screen
            _graphics = graphics;
        }

        public void setColor(Color color)
        {
            this.color = color;
        }

        public static Texture2D CreateTexture(int width, int height, Func<int, Color> paint)
        {
            // Initialize a texture
            Texture2D texture = new Texture2D(_graphics.GraphicsDevice, width, height);

            // The array holds the color for each pixel in the texture
            Color[] data = new Color[width * height];
            for (int pixel = 0; pixel < data.Length; pixel++)
            {
                // The function applies the color according to the specified pixel
                data[pixel] = paint(pixel);
            }

            // Set the color
            texture.SetData(data);

            return texture;
        }

        // Abstract move method to be implemented by derived classes
        public abstract void Move();

        // Draw method to render the model
        public void draw(Vector3 cameraPosition, float aspectRatio, Vector3 cameraTarget, Vector3 cameraUpDirection)
        {
            // Settings of each iteration through the models
            Model Models = m;
            Vector3 modelPosition = pos;
            Vector3 modelRotation = rot;

            // Copy any parent transforms.
            Matrix[] transforms = new Matrix[Models.Bones.Count];
            Models.CopyAbsoluteBoneTransformsTo(transforms);

            // Draw the model. A model can have multiple meshes, so loop.
            foreach (ModelMesh mesh in Models.Meshes)
            {
                // This is where the mesh orientation is set, as well as our camera and projection.
                foreach (BasicEffect effect in mesh.Effects)
                {
                    effect.EnableDefaultLighting();
                    effect.World = transforms[mesh.ParentBone.Index]
                        * Matrix.CreateRotationY(modelRotation.Y)
                        * Matrix.CreateRotationX(modelRotation.X)
                        * Matrix.CreateTranslation(modelPosition);
                    effect.View = Matrix.CreateLookAt(cameraPosition, cameraTarget, cameraUpDirection);
                    effect.Projection = Matrix.CreatePerspectiveFieldOfView(MathHelper.ToRadians(45.0f),
                        aspectRatio, 1.0f, 10000.0f);

                    // Need texture enabled to change color
                    effect.TextureEnabled = true;
                    effect.Texture = CreateTexture(64, 64, pixel => color);

                    // Change color of the selected model
                    if (selected)
                    {
                        effect.Texture = CreateTexture(64, 64, pixel => Color.Blue);
                    }
                }
                // Draw the mesh, using the effects set above.
                mesh.Draw();
            }
        }
    }
}
