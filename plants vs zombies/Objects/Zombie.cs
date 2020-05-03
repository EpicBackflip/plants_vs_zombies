using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace plants_vs_zombies.GameManagement
{
    class Zombie : SpriteGameObject
    {
        public bool househit = false;
        public int Lives = 3;
        public int livesTimer = 100;
        public Zombie(Vector2 Startposition) : base("spr_zombie_okemaarnuechtdelaatstekeer")
        {
            //hoi

            position = Startposition;
         
            velocity.X = 0.5f;
            origin = Center;

        }

        public override void Update(GameTime gametime)
        {
            if(Lives <= 0)
            {

                Reset();
                Lives = 3;
            }
            if (position.X < 180)
            {
                househit = true;
                velocity.X = 0;

            }
            position.X -= velocity.X;
            base.Update(gametime);

        }

        public override void Reset()
        {

            position.X = GameEnvironment.Screen.X + GameEnvironment.Random.Next(10, 1000);

        }


    }
}
