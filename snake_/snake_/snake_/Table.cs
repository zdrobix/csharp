using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace snake_
{
	public class Table
	{
		private Tuple<int, int> windowMeasures;
		private Tuple<int, int> tableMeasures;

		private int tableLeft;
		private int tableRight;
		private int tableTop;
		private int tableBottom;

		public Table(Tuple<int, int> windowMeasures_, Tuple<int, int> tableMeasures_)
		{
			this.windowMeasures = windowMeasures_;
			this.tableMeasures = tableMeasures_;

			this.tableLeft = (windowMeasures.Item1 - tableMeasures.Item1) / 2;
			this.tableRight = tableLeft + tableMeasures.Item1;
			this.tableTop = (windowMeasures.Item2 - tableMeasures.Item2) / 2;
			this.tableBottom = tableTop + tableMeasures.Item2;
		}

	
		public bool isDead (Tuple<float, float> headPositions, int level)
		{
			switch (level)
			{
				case 1:
					return headPositions.Item1 < tableLeft ||
						   headPositions.Item1 >= tableRight ||
						   headPositions.Item2 < tableTop ||
						   headPositions.Item2 >= tableBottom;

				case 2:
					return (headPositions.Item1 < tableLeft || headPositions.Item1 > tableRight) &&
						   (headPositions.Item2 < windowMeasures.Item2 / 2 - 30 ||
							headPositions.Item2 > windowMeasures.Item2 / 2 + 30) ||
							headPositions.Item2 < tableTop ||
							headPositions.Item2 >= tableBottom;
			}

			return false;
		}

		public bool canTeleport(Tuple<float, float> position, int level)
		{
			switch (level) {
				case 1:
					{
						return false;
					}
				case 2:
					{
						return (position.Item1 < tableLeft || position.Item1 >= tableRight) &&
						   (position.Item2 < windowMeasures.Item2 / 2 - 30 ||
							position.Item2 > windowMeasures.Item2 / 2 + 30);
					}
			}
			return false;
		}

		public void designMap(SpriteBatch spriteBatch, Texture2D pixel, int level)
		{
			switch (level)
			{
				case 1:
				case 3:
					{
						spriteBatch.Draw(pixel, new Rectangle(tableLeft - 10, tableTop - 10, tableMeasures.Item1 + 20, tableMeasures.Item2 + 20), Color.Black);
						spriteBatch.Draw(pixel, new Rectangle(tableLeft, tableTop, tableMeasures.Item1, tableMeasures.Item2), Color.LightBlue);
						break;
					}
				case 2:
				case 4:
					{
						spriteBatch.Draw(pixel, new Rectangle(tableLeft - 10, tableTop - 10, tableMeasures.Item1 + 20, tableMeasures.Item2 + 20), Color.Black);
						spriteBatch.Draw(pixel, new Rectangle(tableLeft - 10, windowMeasures.Item2 / 2 - 30, tableMeasures.Item1 + 20, 60), Color.White);
						spriteBatch.Draw(pixel, new Rectangle(tableLeft, tableTop, tableMeasures.Item1, tableMeasures.Item2), Color.White);
						break;
					}
			}
		}
	}
}


//tuple : width, height