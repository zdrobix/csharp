using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;

namespace snake_
{
	public class Snake
	{
		public List<Vector2> Body { get; private set; } = new List<Vector2>();
		public Vector2 Direction { get; set; }

		private bool alive = true;

		private int segmentSize;

		public Snake(int startX, int startY, int segmentSize)
		{
			this.segmentSize = segmentSize;
			Body.Add(new Vector2(startX, startY));
			Direction = new Vector2(1, 0);
		}

		public void Move()
		{
			if (this.alive)
			{
				for (int i = Body.Count - 1; i > 0; i--)
				{
					Body[i] = Body[i - 1];
				}
				Body[0] += Direction * segmentSize;
			}
		}

		public void Grow()
		{
			Body.Add(Body[Body.Count - 1]);
		}

		public void Kill()
		{
			this.alive = false;
		}
	}

}
