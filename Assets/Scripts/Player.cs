using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player {

    public static int lifes = 3;
    public static int score = 0;
    public static int maxLifes = 3;
    public static bool[] enabledImages = { true, true, true };
    public void AddPlayerScore(int s)
    {
        score += s;
    }
    
}
