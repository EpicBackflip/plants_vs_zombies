using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using plants_vs_zombies.GameManagement;
using plants_vs_zombies.Objects;
    

namespace plants_vs_zombies.GameManagement
{
   
    class Bullet : SpriteGameObject
         
    {
       
        // public Groene_plant groeneplant = new Groene_plant(new Vector2(100, 100));


        public bool isClicked = false;

        public Bullet(Vector2 Startposition) : base("laser_kleiner")
        {
            position = Startposition;
            velocity.X = 10f;

        }

        public override void Update(GameTime gametime)
        {
           
            position.X += velocity.X;

        }

 
        


    }
}
