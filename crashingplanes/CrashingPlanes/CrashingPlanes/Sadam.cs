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
		public Vector2 position;
		public int speed = 250;

		private Random random = new Random();

		private int width = 500;
		private int height = 100;

		public Sadam (int newSpeed)
		{
			this.speed = newSpeed;
			this.position = new Vector2(1300, this.random.Next(0, 620));
		}

		public void sadamUpdate(GameTime gameTime)
		{
			float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			this.position.X -= this.speed * deltaTime;
		}

		public Vector2 getDrawPosition() => new Vector2(this.position.X - 250, this.position.Y - 50);

	}
}
