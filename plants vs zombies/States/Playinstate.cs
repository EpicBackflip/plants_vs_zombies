using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using plants_vs_zombies.GameManagement;
using plants_vs_zombies.Objects;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using plants_vs_zombies.States;



namespace Plants_vs_Zombies.GameManagement
{
    class PlayingState : GameObjectList
    {
        public GameObjectList Tiles;
      
        public GameObjectList zombies;
        public GameObjectList GroenePlanten;
        public GameObjectList zonnebloemen;
        public GameObjectList bullets;
        public GameObjectList grasmaaiers;
        public GameObjectList zonneEnergy;

        public Player player;
        public WoodPanel woodpanel;
        public GroenePlantSelector groenePlantSelector;
        public ZonneBloemSelector zonnebloemselector;
        
        public int timer = 0;
        public int bulletYOffset = 65;
        public int Energy = 100;
        public int PlantSelectorTimer = 0;
        public bool PlantIsDead = false;
        public bool plantOnField = false;
        public bool groeneplantAdd = false;
        public bool gameOver = false;

        public PlayingState()
        {
            Tiles = new GameObjectList();
            Add(Tiles);

            Add(new SpriteGameObject("spr_background"));

            woodpanel = new WoodPanel();
            Add(woodpanel);

            groenePlantSelector = new GroenePlantSelector();
            Add(groenePlantSelector);

            zonnebloemselector = new ZonneBloemSelector();
            Add(zonnebloemselector);

            zombies = new GameObjectList();
            Add(zombies);

            bullets = new GameObjectList();
            Add(bullets);

            GroenePlanten = new GameObjectList();
            Add(GroenePlanten);
            zonnebloemen = new GameObjectList();
            Add(zonnebloemen);

            grasmaaiers = new GameObjectList();
            Add(grasmaaiers);

            player = new Player();
            Add(player);

            zonneEnergy = new GameObjectList();
            Add(zonneEnergy);





            for (int TilesCounterX = 0; TilesCounterX < 9; TilesCounterX++)
            {
                for (int TilesCounterY = 0; TilesCounterY < 5; TilesCounterY++)
                {
                    Tiles.Add(new Tile(new Vector2(290 + 82 * TilesCounterX, 110 + 100 * TilesCounterY)));
                }
            

            }

            for (int zombiecounter = 0; zombiecounter < 5; zombiecounter++)
            {
                zombies.Add(new Zombie(new Vector2(GameEnvironment.Screen.X + GameEnvironment.Random.Next(10, 1000), 80 + 100 * zombiecounter)));
            }


            for (int grasmaaiercounter = 0; grasmaaiercounter < 5; grasmaaiercounter++)
            {
                grasmaaiers.Add(new Grasmaaier(new Vector2(180, 100 + 100 * grasmaaiercounter)));
            }
        }


        public override void Update(GameTime gametime)
        {
            Console.WriteLine(Energy);
            timer++;
            PlantSelectorTimer++;
            

            if (groenePlantSelector.GroenePlantSelectorClicked && Energy >= 50 && PlantSelectorTimer >= 50)
            {
                PlantSelectorTimer = 0;
                Energy -= 50;
                GroenePlanten.Add(new Groene_plant(new Vector2(100, 100)));

            }
            if (zonnebloemselector.ZonneBloemSelectorClicked && Energy >= 50 && PlantSelectorTimer >= 50)
            {
                PlantSelectorTimer = 0;
                Energy -= 50;
                zonnebloemen.Add(new ZonneBloem(new Vector2(200, 100)));

            }

            if (gameOver)
            {
                GameEnvironment.GameStateManager.SwitchTo("GameOverState");

            }
            /*
            if(groeneplantAdd && Energy >= 50)
            {

                Energy = 0;
                GroenePlanten.Add(new Groene_plant());

            }
            */

            foreach (ZonneEnergy zonneEnergy in zonneEnergy.Children )
            {

                if (zonneEnergy.zonClicked && PlantSelectorTimer >= 50)
                {
                    PlantSelectorTimer = 0;
                    Energy += 50;
                    zonneEnergy.position = new Vector2(1000,1000);

                }


            }

            foreach (Tile tiles  in Tiles.Children)
            {
                foreach (Groene_plant groeneplant in GroenePlanten.Children)
                {
                   
                
                    if (groeneplant.CollidesWith(tiles) && !groeneplant.GroenePlantClicked)
                    {
                        Console.WriteLine(tiles.position);
                        plantOnField = true;
                        groeneplant.OnField = true;
                        groeneplant.position = tiles.position;

                    }
                    
                }
            }

            foreach (Tile tiles in Tiles.Children)
            {
                foreach (ZonneBloem zonnebloem in zonnebloemen.Children)
                {


                    if (zonnebloem.Overlaps(tiles) && !zonnebloem.ZonneBloemClicked)
                    {
                        plantOnField = true;
                        zonnebloem.OnField = true;
                        zonnebloem.position = tiles.position;

                    }

                }
            }


            foreach (Bullet bullet in bullets.Children)
            {
                foreach (Zombie zombie in zombies.Children)
                {
                    if (zombie.househit)
                    {
                        gameOver = true;

                    }
                 
                    if (bullet.Overlaps(zombie))
                    {
                        zombie.Lives--;
                        bullet.position.X = 5000f;
                        bullet.velocity.X = 0;
                    }
                    foreach (Groene_plant groenePlant in GroenePlanten.Children)
                    {
                        if (zombie.Overlaps(groenePlant) && groenePlant.groeneplantenlivestimer <= 0)
                        {
                            zombie.velocity.X = 0;
                            groenePlant.groeneplantenlives--;
                            groenePlant.groeneplantenlivestimer = 100;
                        }
                        if (groenePlant.groeneplantenlives <= 0)
                        {
                            PlantIsDead = true;
                            zombie.velocity.X = 0.5f;
                            GroenePlanten.position = new Vector2(5000, 100);
                        }
                   
                    }
                }     
            }

            foreach (Zombie zombie in zombies.Children)
            {
                foreach (Grasmaaier grasmaaier in grasmaaiers.Children)
                {
                    if (grasmaaier.Overlaps(zombie))
                    {
                        zombie.position.X = GameEnvironment.Screen.X + GameEnvironment.Random.Next(10, 1000);
                       grasmaaier.velocity.X = 1000;

                    }

                }
            }

            foreach (Groene_plant groenePlant in GroenePlanten.Children)
            {
                if (timer >= 300 && !PlantIsDead && plantOnField)
                {
                    bullets.Add(new Bullet(new Vector2(groenePlant.position.X, groenePlant.position.Y - bulletYOffset)));
                    timer = 0;
                }
                /*
                if (groenePlant.GroenePlantClicked)
                {
                    groeneplantAdd = true;

                }
                */

            }
            foreach (ZonneBloem zonnebloem in zonnebloemen.Children)
            {
                if (timer >= 300 && !PlantIsDead && plantOnField)
                {
                    zonneEnergy.Add(new ZonneEnergy(new Vector2(zonnebloem.position.X, zonnebloem.position.Y)));
                    timer = 0;
                }
                /*
                if (groenePlant.GroenePlantClicked)
                {
                    groeneplantAdd = true;

                }
                */

            }

           
         
            base.Update(gametime);
        }
         
    }
}
