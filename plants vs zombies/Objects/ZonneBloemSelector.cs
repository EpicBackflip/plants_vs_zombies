using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plants_vs_zombies.Objects
{
    class ZonneBloemSelector : SpriteGameObject
    {

        public bool ZonneBloemSelectorClicked = false;
        public int MouseCollisionOffsetX = 25;
        public int MouseCollisionOffsetY = 45;

        public ZonneBloemSelector() : base("zonnebloem")
        {

            Origin = Center;
            position = new Vector2(50, 500);


        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButtonPressed()
                && inputHelper.MousePosition.X < position.X + Width
                && inputHelper.MousePosition.X > position.X
                && inputHelper.MousePosition.Y < position.Y + Height
                && inputHelper.MousePosition.Y > position.Y)
            {
                ZonneBloemSelectorClicked = true;
            }

            if (inputHelper.MouseLeftButtonReleased())
            {
                ZonneBloemSelectorClicked = false;
            }



        }
    }
}












