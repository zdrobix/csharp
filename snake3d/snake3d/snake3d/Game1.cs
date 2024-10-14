using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace snake3ds
{
	public class Game1 : Game
	{
		GraphicsDeviceManager graphics;
		SpriteBatch spriteBatch;

		// Camera settings
		Vector3 cameraPosition;
		Matrix viewMatrix;
		Matrix projectionMatrix;

		// Snake
		List<Vector3> snakeSegments = new List<Vector3>();
		Vector3 snakeDirection = new Vector3(1, 0, 0); // Direction of movement
		float movementTimer = 0;
		float movementDelay = 0.2f; // Speed of the snake

		// Food
		Vector3 foodPosition;
		Random random = new Random();

		// BasicEffect for drawing
		BasicEffect basicEffect;

		// Size of the playing field
		int gridSize = 20;

		public Game1()
		{
			graphics = new GraphicsDeviceManager(this);
			Content.RootDirectory = "Content";
			IsMouseVisible = true;
		}

		protected override void Initialize()
		{
			// Set up camera
			cameraPosition = new Vector3(0, 20, 30);
			viewMatrix = Matrix.CreateLookAt(cameraPosition, Vector3.Zero, Vector3.Up);
			projectionMatrix = Matrix.CreatePerspectiveFieldOfView(MathHelper.PiOver4,
				GraphicsDevice.Viewport.AspectRatio, 0.1f, 100f);

			// Initialize snake with one segment at (0,0,0)
			snakeSegments.Add(Vector3.Zero);

			// Generate initial food
			GenerateNewFood();

			base.Initialize();
		}

		protected override void LoadContent()
		{
			spriteBatch = new SpriteBatch(GraphicsDevice);

			// BasicEffect for rendering
			basicEffect = new BasicEffect(GraphicsDevice)
			{
				World = Matrix.Identity,
				View = viewMatrix,
				Projection = projectionMatrix,
				VertexColorEnabled = true
			};
		}

		protected override void Update(GameTime gameTime)
		{
			if (Keyboard.GetState().IsKeyDown(Keys.Escape))
				Exit();

			// Handle input and snake direction
			var keyboardState = Keyboard.GetState();
			if (keyboardState.IsKeyDown(Keys.W) && snakeDirection != new Vector3(0, 0, 1))
				snakeDirection = new Vector3(0, 0, -1); // Forward (z negative)
			else if (keyboardState.IsKeyDown(Keys.S) && snakeDirection != new Vector3(0, 0, -1))
				snakeDirection = new Vector3(0, 0, 1);  // Backward (z positive)
			else if (keyboardState.IsKeyDown(Keys.A) && snakeDirection != new Vector3(1, 0, 0))
				snakeDirection = new Vector3(-1, 0, 0); // Left (x negative)
			else if (keyboardState.IsKeyDown(Keys.D) && snakeDirection != new Vector3(-1, 0, 0))
				snakeDirection = new Vector3(1, 0, 0);  // Right (x positive)

			// Update snake movement based on the timer
			movementTimer += (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (movementTimer >= movementDelay)
			{
				movementTimer = 0;

				// Move the snake
				Vector3 newHeadPosition = snakeSegments[0] + snakeDirection;
				snakeSegments.Insert(0, newHeadPosition);
				snakeSegments.RemoveAt(snakeSegments.Count - 1); // Remove tail

				// Check if snake eats the food
				if (snakeSegments[0] == foodPosition)
				{
					snakeSegments.Add(snakeSegments[snakeSegments.Count - 1]); // Add new segment
					GenerateNewFood();
				}

				// Check if the snake collides with itself
				for (int i = 1; i < snakeSegments.Count; i++)
				{
					if (snakeSegments[0] == snakeSegments[i])
					{
						// End game or restart logic (you can implement a game-over screen)
						Exit();
					}
				}

				// Check boundaries (you can define your own play area limits)
				if (Math.Abs(snakeSegments[0].X) >= gridSize || Math.Abs(snakeSegments[0].Z) >= gridSize)
				{
					Exit(); // End game if snake goes out of bounds
				}
			}

			base.Update(gameTime);
		}

		private void GenerateNewFood()
		{
			// Generate food at a random position within the grid
			foodPosition = new Vector3(random.Next(-gridSize + 1, gridSize - 1), 0, random.Next(-gridSize + 1, gridSize - 1));
		}

		protected override void Draw(GameTime gameTime)
		{
			GraphicsDevice.Clear(Color.CornflowerBlue);

			// Draw the snake
			foreach (Vector3 segment in snakeSegments)
			{
				DrawCube(segment, Color.Green);
			}

			// Draw the food
			DrawCube(foodPosition, Color.Red);

			base.Draw(gameTime);
		}

		private void DrawCube(Vector3 position, Color color)
		{
			// Define the vertices of a cube relative to the position
			VertexPositionColor[] cubeVertices = new VertexPositionColor[8]
			{
				new VertexPositionColor(new Vector3(-0.5f, -0.5f, -0.5f) + position, color),
				new VertexPositionColor(new Vector3(0.5f, -0.5f, -0.5f) + position, color),
				new VertexPositionColor(new Vector3(-0.5f, 0.5f, -0.5f) + position, color),
				new VertexPositionColor(new Vector3(0.5f, 0.5f, -0.5f) + position, color),
				new VertexPositionColor(new Vector3(-0.5f, -0.5f, 0.5f) + position, color),
				new VertexPositionColor(new Vector3(0.5f, -0.5f, 0.5f) + position, color),
				new VertexPositionColor(new Vector3(-0.5f, 0.5f, 0.5f) + position, color),
				new VertexPositionColor(new Vector3(0.5f, 0.5f, 0.5f) + position, color)
			};

			// Define indices for the cube faces
			short[] cubeIndices = new short[]
			{
				0, 1, 2, 1, 3, 2, // Front face
                4, 5, 6, 5, 7, 6, // Back face
                0, 2, 4, 2, 6, 4, // Left face
                1, 3, 5, 3, 7, 5, // Right face
                2, 3, 6, 3, 7, 6, // Top face
                0, 1, 4, 1, 5, 4  // Bottom face
            };

			basicEffect.World = Matrix.Identity;
			foreach (EffectPass pass in basicEffect.CurrentTechnique.Passes)
			{
				pass.Apply();

				GraphicsDevice.DrawUserIndexedPrimitives(
					PrimitiveType.TriangleList, cubeVertices, 0, 8, cubeIndices, 0, 12);
			}
		}
	}
}
