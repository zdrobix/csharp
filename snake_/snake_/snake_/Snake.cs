using System;
using System.Collections.Generic;
using System.Linq;
using Microsoft.Xna.Framework;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using Microsoft.Xna.Framework.Graphics;
using System.Xml.Linq;
using System.Collections;

namespace snake_
{
	public class Snake
	{
		public List<Vector2> Body { get; private set; } = new List<Vector2>();
		public Vector2 Direction { get; set; }

		private bool alive = true;
		private bool visible = true;

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

		public int level() => 1;

		public void hide() => this.visible = false;
		public void show() => this.visible = true;

		public bool isVisible() => this.visible;

		public void drawSnake (SpriteBatch spriteBatch, Texture2D pixel, Snake snake)
		{
			int i = 0;
			foreach (var segment in snake.Body)
			{
				if (i % 2 != 1)
					spriteBatch.Draw(pixel, new Rectangle((int)segment.X, (int)segment.Y, this.segmentSize, this.segmentSize), Color.Green);
				else
					spriteBatch.Draw(pixel, new Rectangle((int)segment.X, (int)segment.Y, this.segmentSize, this.segmentSize), Color.Black);

				i++;
			}

			spriteBatch.Draw(pixel, new Rectangle((int)snake.Body[0].X + 2, (int)snake.Body[0].Y + 5, 4, 4), Color.White);
			spriteBatch.Draw(pixel, new Rectangle((int)snake.Body[0].X + 11, (int)snake.Body[0].Y + 5, 4, 4), Color.White);
		}

		public static Snake whichVisible(Snake sn1, Snake sn2)
		{
			if (sn1.isVisible())
				return sn1;
			if (sn2.isVisible())
				return sn2;
			return null;
		}

		public static void flipBothSnakes (Snake sn1, Snake sn2)
		{
			bool aux = sn1.alive;
			sn1.alive = sn2.alive;
			sn2.alive = aux;
		}

	}

}
