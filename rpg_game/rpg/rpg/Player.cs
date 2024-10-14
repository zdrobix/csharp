using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rpg
{
	public class Player
	{
		private Vector2 position = new Vector2(200, 200);
		private Direction direction = Direction.Down;
		private int speed = 300;
		private bool isMoving = false;
		public bool dead = false;

		public SpriteAnimation animation;
		public List<SpriteAnimation> animations = new List<SpriteAnimation>();

		private KeyboardState kStateOld = Keyboard.GetState();

		public Vector2 getPosition() => this.position;
		public void setPosition(Vector2 newPosition) => this.position = newPosition;
		public int getSpeed() => this.speed;
		public void Update (GameTime gameTime)
		{
			var kState = Keyboard.GetState();
			var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			this.isMoving = false;
			if (kState.IsKeyDown(Keys.A))
			{
				this.isMoving = true;
				this.direction = Direction.Left;
			}
			if (kState.IsKeyDown(Keys.W))
			{
				this.isMoving = true;
				this.direction = Direction.Up;
			}
			if (kState.IsKeyDown(Keys.S))
			{
				this.isMoving = true;
				this.direction = Direction.Down;
			}
			if (kState.IsKeyDown(Keys.D))
			{
				this.isMoving = true;
				this.direction = Direction.Right;
			}

			if (kState.IsKeyDown(Keys.Space))
				this.isMoving = false;

			if (this.dead)
				this.isMoving = false;

			if (this.isMoving)
			{
				switch (this.direction)
				{
					case Direction.Left:
						if (this.position.X > 225)
							this.position.X -= deltaTime * this.speed;
						break;
					case Direction.Up:
						if (this.position.Y > 200)
							this.position.Y -= deltaTime * this.speed;
						break;
					case Direction.Down:
						if (this.position.Y < 1250)
						this.position.Y += deltaTime * this.speed;
						break;
					case Direction.Right:
						if (this.position.X < 1275)
							this.position.X += deltaTime * this.speed;
						break;
				}
			}
			this.animation = this.animations.ElementAt((int)this.direction);

			this.animation.Position = new Vector2(this.position.X - 48, this.position.Y - 48);
			if (kState.IsKeyDown(Keys.Space))
				this.animation.setFrame(0);
			else if (this.isMoving)
				this.animation.Update(gameTime);
			else this.animation.setFrame(1);

			if (kState.IsKeyDown(Keys.Space) && kStateOld.IsKeyUp(Keys.Space))
				Projectile.projectiles.Add(new Projectile(this.position, this.direction));
			this.kStateOld = Keyboard.GetState();
		}	
	}
}
