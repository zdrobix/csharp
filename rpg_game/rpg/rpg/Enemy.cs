using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace rpg
{
	public class Enemy
	{
		public static List<Enemy> enemies = new List<Enemy>();

		private Vector2 position = new Vector2(0, 0);
		private int speed = 150;
		public SpriteAnimation animation;
		public int radius = 30;
		private bool dead = false;

		public Enemy(Vector2 newPosition, Texture2D spriteSheet)
		{
			this.position = newPosition;
			this.animation = new SpriteAnimation(spriteSheet, 10, 6);
		}
		public Vector2 getPosition() => this.position;
		public bool getDead() => this.dead;
		public void setDead(bool d) => this.dead = d;
		public void Update(GameTime gameTime, Vector2 playerPosition)
		{
			this.animation.Position = new Vector2(this.position.X - 48, this.position.Y - 66);
			this.animation.Update(gameTime);

			var deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;

			Vector2 move = playerPosition - this.position;
			move.Normalize();
			this.position += move * speed * deltaTime;
		}
	}
}
