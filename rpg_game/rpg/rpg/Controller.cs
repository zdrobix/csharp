using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace rpg
{
	internal class Controller
	{
		public static double timer = 2D;
		public static double maxTime = 5D;

		public static void Update(GameTime gameTime, Texture2D spriteSheet)
		{
			timer -= gameTime.ElapsedGameTime.TotalSeconds;
			if (timer <= 0)
			{
				Enemy.enemies.Add(new Enemy(new Vector2(new Random().Next(-500, 2000), new Random().Next(-500, 2000)), spriteSheet));
				timer = maxTime;

				if (maxTime > 2)
					maxTime -= 0.05D;
			}
		}

	}
}
