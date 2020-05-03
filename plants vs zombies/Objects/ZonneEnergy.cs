using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace plants_vs_zombies.Objects
{
    class ZonneEnergy : SpriteGameObject
    {
        public bool zonClicked = false;
      public  ZonneEnergy(Vector2 Startposition) : base("zon")
      {
            position = Startposition;
            Origin = Center;

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButtonPressed()
                && inputHelper.MousePosition.X < position.X + Width
                && inputHelper.MousePosition.X > position.X
                && inputHelper.MousePosition.Y < position.Y + Height
                && inputHelper.MousePosition.Y > position.Y)
            {
              
                zonClicked = true;
            }

            if (inputHelper.MouseLeftButtonReleased())
            {
                zonClicked = false;
            }



        }
    }
}
