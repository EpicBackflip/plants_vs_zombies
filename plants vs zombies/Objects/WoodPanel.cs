using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace plants_vs_zombies.Objects
{
    class WoodPanel : SpriteGameObject
    {

       public WoodPanel() : base("Panel_Vertical")
        {

            position = Center;
            position = new Vector2(-50,100);

        }
    }
}
