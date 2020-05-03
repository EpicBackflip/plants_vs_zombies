using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.Xna.Framework;

namespace plants_vs_zombies.Objects
{
    class Grasmaaier : SpriteGameObject
    {
        public Grasmaaier(Vector2 StartPosition) : base("grasmaaier")
        {


            position = StartPosition;
          
        }
    }
}
