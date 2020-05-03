using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace plants_vs_zombies.Objects
{
    class GroenePlantSelector : SpriteGameObject
    {

        public bool GroenePlantSelectorClicked = false;
        public int MouseCollisionOffsetX = 25;
        public int MouseCollisionOffsetY = 45;

        public GroenePlantSelector() : base("plant_nog_kleine")
        {

            Origin = Center;
            position = new Vector2(50, 300);


        }

        public override void HandleInput(InputHelper inputHelper)
        {
            if (inputHelper.MouseLeftButtonPressed()
                && inputHelper.MousePosition.X < position.X + Width
                && inputHelper.MousePosition.X > position.X 
                && inputHelper.MousePosition.Y < position.Y  +Height
                && inputHelper.MousePosition.Y > position.Y )
            {
                GroenePlantSelectorClicked = true;
            }

            if (inputHelper.MouseLeftButtonReleased())
            {
                GroenePlantSelectorClicked = false;
            }



        }
    }
}
