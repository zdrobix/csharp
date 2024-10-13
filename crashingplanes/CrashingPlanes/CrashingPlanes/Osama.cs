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
		private Vector2 position = new Vector2(100, 400);
		private List<Plane> planes = new List<Plane>();
		private int speed = 200;
		private bool dead = true;
		private double cooldown = 1;

		public Vector2 getPosition() => this.position;
		public bool isDead() => this.dead;
		public void revive() => this.dead = false;
		public void die() => this.dead = true;
		public Vector2 getRealPosition() => new Vector2(this.position.X - 100, this.position.Y - 100);
		public IEnumerable<Plane> getPlaneList() => this.planes;

		internal void shipUpdate(GameTime gameTime)
		{
			if (this.dead) return;
			var kState = Keyboard.GetState();
			float deltaTime = (float)gameTime.ElapsedGameTime.TotalSeconds;
			if (kState.IsKeyDown(Keys.W)  && this.position.Y > 80)
				this.position.Y -= this.speed * deltaTime;
			if (kState.IsKeyDown(Keys.S) && this.position.Y < 670)
				this.position.Y += this.speed * deltaTime;
			if (kState.IsKeyDown(Keys.A) && this.position.X > 80)
				this.position.X -= this.speed * deltaTime;
			if (kState.IsKeyDown(Keys.D) && this.position.X < 1000)
				this.position.X += this.speed * deltaTime;
			this.cooldown -= gameTime.ElapsedGameTime.TotalSeconds;
			if ((kState.IsKeyDown(Keys.P) || kState.IsKeyDown(Keys.X)) && this.cooldown <= 0)
			{
				this.shootPlane(gameTime);
				this.cooldown = 0.1;
			}

		}


		public bool didItCollide(Vector2 positionSadam)
		{
			//de optimizat
			if (Vector2.Distance(this.getRealPosition(), positionSadam) < 40)
				return true;
			return false;
		}

		private void shootPlane(GameTime gameTime)
		{
			this.planes.Add(new Plane(this.getRealPosition()));
			if (this.planes.Count > 30)
			{
				this.planes.RemoveRange(0, 10);
			}
		}
	}
}
