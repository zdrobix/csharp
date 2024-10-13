using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrashingPlanes
{
	public class Sadam
	{
		private Vector2 position;
		private int speed = 250;

		private Random random = new Random();

		private int width = 500;
		private int height = 100;

		private bool dead = true;

		public Sadam (int newSpeed)
		{
			this.speed = newSpeed;
			this.position = new Vector2(1300, this.random.Next(0, 620));
		}

		public void sadamUpdate(GameTime gameTime)
		{
			float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (this.dead)
				this.position.X -= this.speed * deltaTime;
			else this.position.X += this.speed * deltaTime;
		}

		public Vector2 getDrawPosition() => new Vector2(this.position.X + 112, this.position.Y + 15);
		public void reviveSadam() => this.dead = false;
		public bool isDead() => this.dead;
		public Vector2 getPosition() => this.position;
	}
}
