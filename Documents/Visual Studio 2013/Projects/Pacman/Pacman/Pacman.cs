using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;

namespace Pacman
{
  class Pacman : Sprite
  {
    public Image pacmanUp = Image.FromFile("../../images/pacmanUp.gif");
    public Image pacmanDown = Image.FromFile("../../images/pacmanDown.gif");
    public Image pacmanRight = Image.FromFile("../../images/pacmanRight.gif");
    public Image pacmanLeft = Image.FromFile("../../images/pacmanLeft.gif");
  }
}
