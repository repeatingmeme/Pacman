using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pacman
{
  class Sprite : Game
  {
    public int X;
    public int Y;
    public int PrevX;
    public int PrevY;
    public int Wall;
    public int Angle;
    public int PrevAngle;
    public Image Sprites;
  }
}
