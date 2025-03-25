using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System.Diagnostics;
using System;

namespace MonoGame_04_2D_TicTacToe
{

    // the code was blocked (screenshot) assuming some security feature 
    public class Game1 : Game
    {
        public static GraphicsDeviceManager _graphics;
        private SpriteBatch _spriteBatch;
        private readonly Grid grid; // (REMIDNER!!) Added Grid instance
        private SpriteFont font; // Added for displaying text
        private string winnerMessage = ""; // Added to store the winner message

        public Game1()
        {
            _graphics = new GraphicsDeviceManager(this);
            Content.RootDirectory = "Content";
            IsMouseVisible = true;
            grid = new Grid(); // (REMIDNER!!) Initialize the newly made Grid instance
        }

        protected override void Initialize()
        {
            base.Initialize();
        }

        // Set the position of the camera in world space, for our view matrix.
        Vector3 cameraPosition = new Vector3(0.0f, 350.0f, 350.0f);

        // The aspect ratio determines how to scale 3d to 2d projection.
        float aspectRatio;

        Boolean lastTimeWasNotSpace = false;
        Boolean lastTimeWasNotUp = false;
        Boolean lastTimeWasNotRight = false;
        Boolean lastTimeWasNotDown = false;
        Boolean lastTimeWasNotLeft = false;

        private readonly myModel[] m = new myModel[4];

        protected override void LoadContent()
        {
            Debug.WriteLine("BasicCameraSample LoadContent");

            _spriteBatch = new SpriteBatch(GraphicsDevice);

            // Flyweight pattern: create one of each mesh, and reuse
            // these 4 meshes in the grid.  
            // load each mesh one at a time, 4 types of mesh objects
            // All mesh objects displayed, will render from one of these 4
            myModel.setupGraphics(_graphics);
            m[0] = new myModel(Content.Load<Model>("Models\\X"), Vector3.Zero, Vector3.Zero, Color.Yellow);
            m[1] = new myModel(Content.Load<Model>("Models\\O"), Vector3.Zero, Vector3.Zero, Color.Yellow);
            m[2] = new myModel(Content.Load<Model>("Models\\Z"), Vector3.Zero, Vector3.Zero, Color.Yellow);
            m[3] = new myModel(Content.Load<Model>("Models\\dot"), Vector3.Zero, Vector3.Zero, Color.Yellow);

            font = Content.Load<SpriteFont>("Fonts/DefaultFont"); // Load the font and made sure  it is set to "Rersource" in properties... broke other wise

            aspectRatio = (float)_graphics.GraphicsDevice.Viewport.Width /
                            (float)_graphics.GraphicsDevice.Viewport.Height;
        }




        protected override void Update(GameTime gameTime)
        {
            if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
                Exit();

            //Get Keyboard Keystroke
            KeyboardState k = Keyboard.GetState();

            // Act on the keystroke
            if (k.IsKeyDown(Keys.E))
                this.Exit(); // E = Exit Game

            // cameraPosition
            if (k.IsKeyDown(Keys.D1))
            {
                cameraPosition = new Vector3(0.0f, 350.0f, 350.0f);
            }
            if (k.IsKeyDown(Keys.D2))
            {
                cameraPosition = new Vector3(50.0f, 450.0f, 450.0f);
            }
            if (k.IsKeyDown(Keys.D3))
            {
                cameraPosition = new Vector3(100.0f, 250.0f, 250.0f);
            }
            if (k.IsKeyDown(Keys.D4))
            {
                cameraPosition = new Vector3(0.0f, -350.0f, 250.0f);
            }

            // (REMIDNER!!) Replaced direct manipulation of grid and selection arrays with calls to Grid methods
            if ((k.IsKeyDown(Keys.Up)) && lastTimeWasNotUp)
            {
                int[] current = grid.GetCurrent();
                current[1] = ((current[1] + 1) % 3);
                grid.SetCurrent(current[0], current[1]);
            }

            if ((k.IsKeyDown(Keys.Right)) && lastTimeWasNotRight)
            {
                int[] current = grid.GetCurrent();
                current[0] = (current[0] + 1) % 3;
                grid.SetCurrent(current[0], current[1]);
            }

            if ((k.IsKeyDown(Keys.Down)) && lastTimeWasNotDown)
            {
                int[] current = grid.GetCurrent();
                current[1] = (current[1] - 1 + 3) % 3;
                grid.SetCurrent(current[0], current[1]);
            }

            if ((k.IsKeyDown(Keys.Left)) && lastTimeWasNotLeft)
            {
                int[] current = grid.GetCurrent();
                current[0] = (current[0] - 1 + 3) % 3;
                grid.SetCurrent(current[0], current[1]);
            }

            if (k.IsKeyDown(Keys.Space) && lastTimeWasNotSpace)
            {
                int[] current = grid.GetCurrent();
                Debug.WriteLine(" current[0]=" + current[0] + " current[1]=" + current[1]);
                grid.ToggleSelection(current[0], current[1]);
                grid.UpdateGridValue(current[0], current[1]);
            }

            lastTimeWasNotUp = !(k.IsKeyDown(Keys.Up));
            lastTimeWasNotRight = !(k.IsKeyDown(Keys.Right));
            lastTimeWasNotDown = !(k.IsKeyDown(Keys.Down));
            lastTimeWasNotLeft = !(k.IsKeyDown(Keys.Left));
            lastTimeWasNotSpace = !(k.IsKeyDown(Keys.Space));

            Grid.gridVal winner = grid.getWhoWon(); // (REMIDNER!!) Check who won
            if (winner != Grid.gridVal.dot)
            {
                winnerMessage = $"Player {winner} wins!";
            }

            base.Update(gameTime);
        }

        protected override void Draw(GameTime gameTime)
        {
            GraphicsDevice.Clear(Color.CornflowerBlue);

            // (!!) Replaced direct access to grid and selection arrays with calls to Grid methods
            Grid.gridVal[,] gridArray = grid.GetGrid();
            int[] current = grid.GetCurrent();
            Grid.gridVal WhoWon = grid.getWhoWon();

            // (!!) Draw the grid
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    bool won = ((gridArray[i, j] != Grid.gridVal.dot) && (WhoWon == gridArray[i, j]));

                    Vector3 location;
                    location.X = i * 100 - 50.0f;
                    location.Y = j * 100 - 50.0f;
                    location.Z = 0.0f;

                    myModel here = m[(int)gridArray[i, j]];
                    here.pos = location;

                    here.color = Color.PaleGreen;

                    if (gridArray[i, j] == Grid.gridVal.X) { here.color = Color.BlueViolet; }
                    if (gridArray[i, j] == Grid.gridVal.O) { here.color = Color.DarkOrange; }

                    if ((i == current[0]) && (j == current[1]))
                    {
                        here.color = Color.Red;
                    }

                    Vector3 cameraTarget = Vector3.Zero;
                    Vector3 cameraUpDirection = Vector3.Up;

                    here.draw(cameraPosition, aspectRatio, cameraTarget, cameraUpDirection, won);
                }
            }

            // Draw the winner message if there is one
            if (!string.IsNullOrEmpty(winnerMessage))
            {
                _spriteBatch.Begin();
                _spriteBatch.DrawString(font, winnerMessage, new Vector2(10, 10), Color.White);
                _spriteBatch.End();
            }

            base.Draw(gameTime);
        }
    }
}
