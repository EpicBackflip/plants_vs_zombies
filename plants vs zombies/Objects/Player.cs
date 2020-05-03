using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Plants_vs_Zombies.GameManagement
{
    class Player : SpriteGameObject
    {
        public Player() : base("CursorGrijs_kleiner")
        {
            Mouse.SetPosition(235, 500);
            origin = Center;


        }
        public override void HandleInput(InputHelper inputHelper)
        {

            position = inputHelper.MousePosition;
            //base.HandleInput(inputHelper);
        }

    }
        
}
