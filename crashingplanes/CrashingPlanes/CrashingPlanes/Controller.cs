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
	public class Controller
	{
		private List<Sadam> sadamList = new List<Sadam>();
		private double timer = 2;
		private double toSubtract = 0.02;
		private double times = 1;

		private bool inGame = false;

		public void controllerUpdate(GameTime gameTime)
		{
			if (inGame)
				this.timer -= gameTime.ElapsedGameTime.TotalSeconds;
			else
			{
				var kState = Keyboard.GetState();
				if (kState.IsKeyDown(Keys.Enter))
				{
					this.inGame = true;
					this.times = 1;
					this.timer = 2;
				}
			}
			if ( this.timer <= 0)
			{
				this.sadamList.Add(new Sadam(250));
				this.timer = 2 - this.times * this.toSubtract;
				this.times++;
				if (this.timer < 0.8)
					this.timer = 0.8;
				
			}
		}

		public List<Sadam> getSadamList() => this.sadamList;

		public bool isInGame() => this.inGame;
		public bool endGame() => this.inGame = false;
	}
}
