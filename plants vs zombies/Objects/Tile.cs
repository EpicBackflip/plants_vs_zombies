using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace plants_vs_zombies.Objects
{
    class Tile : SpriteGameObject
    {
       public Tile(Vector2 StartPosition) : base ("Square_kleiner")
       {
           origin = Center;
           position = StartPosition;

       }
    }
}
