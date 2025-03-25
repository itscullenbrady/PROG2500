using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections;
using System.Diagnostics;

namespace Project1
{
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;

            // Set the GraphicsDeviceManager's fullscreen property
            _graphics.IsFullScreen = false;
        }

        protected override void Initialize()
        {
            // No specific initialization logic required
            base.Initialize();
        }

        // List of models to draw
        ArrayList Model_list = new ArrayList();

        // The current model to change, of the List
        int current = 0;

        // Used to detect the B button being pressed
        ButtonState lastUpdateState;
        ButtonState thisUpdateState;

        // The aspect ratio determines how to scale 3d to 2d projection.
        float aspectRatio;

        protected override void LoadContent()
        {
            Debug.WriteLine("BasicCameraSample LoadContent");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            try
            {
                // Read mesh from file, set into arraylist
                Model_list.Add(new MovingObject(Content.Load<Model>("Models/R"), new Vector3(0, 0, 0), new Vector3(1, 0, 0), Color.Red));
                Model_list.Add(new StationaryObject(Content.Load<Model>("Models/U"), new Vector3(10, 0, 0), Vector3.Zero, Color.Pink));
                Model_list.Add(new MovingObject(Content.Load<Model>("Models/S"), new Vector3(20, 0, 0), new Vector3(1, 0, 0), Color.Orange));
                Model_list.Add(new StationaryObject(Content.Load<Model>("Models/S"), new Vector3(30, 0, 0), Vector3.Zero, Color.Black));
                Model_list.Add(new MovingObject(Content.Load<Model>("Models/Sphere"), new Vector3(40, 0, 0), new Vector3(1, 0, 0), Color.White));
            }
            catch (Exception ex)
            {
                Debug.WriteLine("Error loading models: " + ex.Message);
                throw;
            }

            aspectRatio = (float)_graphics.GraphicsDevice.Viewport.Width / (float)_graphics.GraphicsDevice.Viewport.Height;

            // Model needs graphics device to muck with color
            myModel.setupGraphics(_graphics);
        }


        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            MouseState m = Mouse.GetState();
            int mouseX = m.X;
            Trace.WriteLine("mouseX = " + mouseX);

            // TODO: Add your update logic here
            KeyboardState k = Keyboard.GetState();

            if (k.IsKeyDown(Keys.E))
                this.Exit(); // E = Exit Game

            if (k.IsKeyDown(Keys.Up))
                ((myModel)Model_list[current]).rot.X += 0.01f; // Rotate Up

            if (k.IsKeyDown(Keys.Down))
                ((myModel)Model_list[current]).rot.X -= 0.01f; // Rotate Down

            if (k.IsKeyDown(Keys.PageUp))
                ((myModel)Model_list[current]).pos.X += 5.0f; // Move Up

            if (k.IsKeyDown(Keys.PageDown))
                ((myModel)Model_list[current]).pos.X -= 5.0f; // Move Down

            if (k.IsKeyDown(Keys.Left))
                ((myModel)Model_list[current]).rot.Y += 0.1f; // Rotate Left

            if (k.IsKeyDown(Keys.Right))
                ((myModel)Model_list[current]).rot.Y -= 0.1f; // Rotate Right

            if (k.IsKeyDown(Keys.Space))
                current = (current + 1) % Model_list.Count; // Spacebar...next

            // Allows the game to exit
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed)
                this.Exit();

            // Cycle through array of meshes. B button went from not pressed to pressed
            thisUpdateState = GamePad.GetState(PlayerIndex.One).Buttons.B;
            if ((thisUpdateState == ButtonState.Pressed) && (lastUpdateState == ButtonState.Released))
                current = (current + 1) % Model_list.Count;

            // Get rotation from thumbstick
            float yRotation = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.X;
            float xRotation = GamePad.GetState(PlayerIndex.One).ThumbSticks.Left.Y;

            // Set Rotation
            ((myModel)Model_list[current]).rot.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds * MathHelper.ToRadians(xRotation);
            ((myModel)Model_list[current]).rot.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds * MathHelper.ToRadians(yRotation);

            // Get position from thumbstick
            float yPosition = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.X;
            float xPosition = GamePad.GetState(PlayerIndex.One).ThumbSticks.Right.Y;

            // Set Position
            ((myModel)Model_list[current]).pos.X += (float)gameTime.ElapsedGameTime.TotalMilliseconds * MathHelper.ToRadians(yPosition);
            ((myModel)Model_list[current]).pos.Y += (float)gameTime.ElapsedGameTime.TotalMilliseconds * MathHelper.ToRadians(xPosition);

            // This is next time's last time...er...you know what I mean.
            lastUpdateState = thisUpdateState;

            // Update movement of models
            foreach (myModel model in Model_list)
            {
                model.Move();
            }

            base.Update(gameTime);
        }


        // Set the position of the camera in world space, for our view matrix.
        Vector3 cameraPosition = new Vector3(0.0f, 350.0f, 350.0f);
        Vector3 cameraTarget = Vector3.Zero;
        Vector3 cameraUpDirection = Vector3.Up;

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            foreach (myModel model in Model_list)
            {
                model.draw(cameraPosition, aspectRatio, cameraTarget, cameraUpDirection);
            }

            base.Draw(gameTime);
        }
    }
}
