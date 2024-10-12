using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace CrashingPlanes
{
	public class Osama
	{
		public Vector2 position = new Vector2(100, 300);
		private int speed = 200;
		private bool dead = true;

		public bool isDead() => this.dead;

		public void revive() => this.dead = false;
		public void die() => this.dead = true;

		internal void shipUpdate(GameTime gameTime)
		{
			var kState = Keyboard.GetState();
			float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kState.IsKeyDown(Keys.W))
				this.position.Y -= this.speed * deltaTime;
			if (kState.IsKeyDown(Keys.S))
				this.position.Y += this.speed * deltaTime;
			if (kState.IsKeyDown(Keys.A))
				this.position.X -= this.speed * deltaTime;
			if (kState.IsKeyDown(Keys.D))
				this.position.X += this.speed * deltaTime;
		}

		public Vector2 getRealPosition() => new Vector2(this.position.X - 100, this.position.Y - 100);

		public bool didItCollide(Vector2 positionSadam)
		{
			//de optimizat
			if (Vector2.Distance(this.getRealPosition(), positionSadam) < 40)
				return true;
			return false;
		}
	}
}
