using UnityEngine;
using System.Collections;

public class EnumDirections {
    private direction moveDirection;
    public enum direction
    {
        UP, DOWN, LEFT, RIGHT
    }
   public  direction getDirection()
    {
        return moveDirection;
    }
   public  void setDirection(direction dir)
    {
        moveDirection = dir;
    }

}
