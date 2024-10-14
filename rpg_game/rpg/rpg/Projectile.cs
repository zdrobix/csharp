using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rpg
{
	public class Projectile
	{
		public static List<Projectile> projectiles = new List<Projectile>();

		private Vector2 position;
		private int speed = 1000;
		public int radius = 20;
		private Direction direction;
		private bool colided = false;


		public Projectile(Vector2 newPosition, Direction newDirection)
		{
			this.position = newPosition;
			this.direction = newDirection;
		}

		public Vector2 getPosition() => this.position;
		public int getSpeed() => this.speed;
		public bool getColided() => this.colided;
		public void setColided() => this.colided = !this.colided;

		public void Update(GameTime gameTime)
		{
			var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			switch (this.direction)
			{
				case Direction.Left:
					this.position.X -= deltaTime * this.speed;
					break;
				case Direction.Up:
					this.position.Y -= deltaTime * this.speed;
					break;
				case Direction.Down:
					this.position.Y += deltaTime * this.speed;
					break;
				case Direction.Right:
					this.position.X += deltaTime * this.speed;
					break;
			}
		}
	}
}
