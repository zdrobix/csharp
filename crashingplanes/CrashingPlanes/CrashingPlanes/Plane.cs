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
	public class Plane
	{
		private Vector2 position;
		private bool reachedTarget = false;

		public Plane (Vector2 position_)
		{
			this.position = position_;
		}

		public void Update ()
		{
			this.position = new Vector2(this.position.X + 10, this.position.Y);
		}

		public Vector2 getPosition() => this.position;
		public Vector2 getRealPosition() => new Vector2(this.position.X + 15, this.position.Y + 15);
		public bool getReachedTarget() => this.reachedTarget;
		public void hasReachedTarget() => this.reachedTarget = true;

	}
}
