using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Topic_4___Star_Class
{ 
    public class Star
    {
        private Rectangle _location;
        private Vector2 _speed;
        private Texture2D _texture;
        private Random _generator;
        private Color _color;



        public Star(Texture2D texture, Rectangle location, Vector2 speed)
        {
            _location = location;
            _speed = new Vector2(-location.Width, 0);
            _texture = texture;
            _generator = new Random();
            int colorChoice = _generator.Next(0, 2);
            if (colorChoice == 0)
            {
                _color = Color.Cyan;
            }
            else
            {
                _color = Color.Orange;
            }

        }

        public void Update()
        {
            _location.Offset(_speed);
        }


        public void Draw(SpriteBatch spriteBatch)
        {
            spriteBatch.Draw(_texture, _location, _color);
        }

        public Rectangle Location
        {
            get { return _location; }
            set { _location = value; }
        }

        public int Y
        {
            get { return _location.Y; }
            set { _location.Y = value; }
        }
        public int X
        {
            get { return _location.X; }
            set { _location.X = value; }
        }

    }
}
