using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using plants_vs_zombies.GameManagement;
using Plants_vs_Zombies.GameManagement;

namespace plants_vs_zombies.Objects
{
    class Groene_plant : SpriteGameObject
    {
        public bool GroenePlantClicked  = false;
        public int groeneplantenlives = 3;
        public int groeneplantenlivestimer = 100;
        public bool OnField = false;
        public int MouseCollisionOffsetX = 25;
        public int MouseCollisionOffsetY = 45;
        public Groene_plant(Vector2 StartPosition) : base("plant_nog_kleine")
        {

          
            origin = Center;
            position = StartPosition;


        }

        public override void Update(GameTime gametime)
        {

         
            groeneplantenlivestimer--;
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
               GroenePlantClicked = true;
            }

            
            if (inputHelper.MouseLeftButtonPressed()
                && inputHelper.MousePosition.X < position.X + Width / 2
                && inputHelper.MousePosition.X > position.X - MouseCollisionOffsetX
                && inputHelper.MousePosition.Y < position.Y + Height / 2
                && inputHelper.MousePosition.Y > position.Y - MouseCollisionOffsetY
                && OnField)
            {
                GroenePlantClicked = false;
            }

            if (inputHelper.MouseLeftButtonReleased())
            {
               GroenePlantClicked = false;
            }

            if (GroenePlantClicked)
            {
                position = inputHelper.MousePosition;
            }

        }
    }
}



