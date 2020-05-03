using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plants_vs_zombies.Objects
{
    class ZonneBloem : SpriteGameObject
    {
        public bool ZonneBloemClicked = false;
        public int groeneplantenlives = 3;
        public int ZonneBloemlivestimer = 100;
        public bool OnField = false;
        public int MouseCollisionOffsetX = 25;
        public int MouseCollisionOffsetY = 45;
        public ZonneBloem(Vector2 StartPosition) : base("zonnebloem")
        {

          
            origin = Center;
            position = StartPosition;


        }

        public override void Update(GameTime gametime)
        {

            ZonneBloemlivestimer--;
            base.Update(gametime);

        }
        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButtonPressed()
                && inputHelper.MousePosition.X < position.X + Width/2
                && inputHelper.MousePosition.X > position.X - MouseCollisionOffsetX
                && inputHelper.MousePosition.Y < position.Y + Height/2
                && inputHelper.MousePosition.Y > position.Y - MouseCollisionOffsetY)
            {
                ZonneBloemClicked = true;
            }

            
            if (inputHelper.MouseLeftButtonPressed()
                && inputHelper.MousePosition.X < position.X + Width / 2
                && inputHelper.MousePosition.X > position.X - MouseCollisionOffsetX
                && inputHelper.MousePosition.Y < position.Y + Height / 2
                && inputHelper.MousePosition.Y > position.Y - MouseCollisionOffsetY
                && OnField)
            {
                ZonneBloemClicked = false;
            }

            if (inputHelper.MouseLeftButtonReleased())
            {
                ZonneBloemClicked = false;
            }

            if (ZonneBloemClicked)
            {
                position = inputHelper.MousePosition;
            }

        }
    }
}
