using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;

public class SpriteGameObject : GameObject
{
    protected SpriteSheet sprite;
    public Vector2 origin;
    public bool PerPixelCollisionDetection = true;


    public SpriteGameObject(string assetName, int layer = 0, string id = "", int sheetIndex = 0)
        : base(layer, id)
    {
        if (assetName != "")
        {
            sprite = new SpriteSheet(assetName, sheetIndex);
        }
        else
        {
            sprite = null;
        }
    }    

    public override void Draw(GameTime gameTime, SpriteBatch spriteBatch)
    {
        if (!visible || sprite == null)
        {
            return;
        }
        sprite.Draw(spriteBatch, this.GlobalPosition, origin);
    }

    public SpriteSheet Sprite
    {
        get { return sprite; }
    }

    public Vector2 Center
    {
        get { return new Vector2(Width, Height) / 2; }
    }

    public int Width
    {
        get
        {
            return sprite.Width;
        }
    }

    public int Height
    {
        get
        {
            return sprite.Height;
        }
    }

    public bool Mirror
    {
        get { return sprite.Mirror; }
        set { sprite.Mirror = value; }
    }

    public Vector2 Origin
    {
        get { return origin; }
        set { origin = value; }
    }

    public override Rectangle BoundingBox
    {
        get
        {
            int left = (int)(base.GlobalPosition.X - origin.X);
            int top = (int)(base.GlobalPosition.Y - origin.Y);
            return new Rectangle(left, top, Width, Height);
        }
    }

    public bool CollidesWith(SpriteGameObject obj)
    {
        if (!visible || !obj.visible || !BoundingBox.Intersects(obj.BoundingBox))
        {
            return false;
        }
        if (!PerPixelCollisionDetection)
        {
            return true;
        }
        Rectangle b = Collision.Intersection(BoundingBox, obj.BoundingBox);
        for (int x = 0; x < b.Width; x++)
        {
            for (int y = 0; y < b.Height; y++)
            {
                int thisx = b.X - (int)(base.GlobalPosition.X - origin.X) + x;
                int thisy = b.Y - (int)(base.GlobalPosition.Y - origin.Y) + y;
                int objx = b.X - (int)(obj.origin.X - obj.origin.X) + x;
                int objy = b.Y - (int)(obj.origin.Y - obj.origin.Y) + y;
                if (sprite.IsTranslucent(thisx, thisy) && obj.sprite.IsTranslucent(objx, objy))
                {
                    return true;
                }
            }
        }
        return false;
    }
    public Boolean Overlaps(SpriteGameObject other)
    {
        if (visible)
        {
            float w0 = this.Width,
                h0 = this.Height,
                w1 = other.Width,
                h1 = other.Height,
                x0 = this.position.X,
                y0 = this.position.Y,
                x1 = other.position.X,
                y1 = other.position.Y;

            return !(x0 > x1 + w1 || x0 + w0 < x1 ||
              y0 > y1 + h1 || y0 + h0 < y1);
        }

        return false;

    }
}

