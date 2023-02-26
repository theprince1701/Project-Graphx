using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Player
{
    public static bool HasWon => OrbsCollected >= MaxOrbs;
    public static bool HasLost;
    
    
    public static int MaxOrbs = 8;
    public static int OrbsCollected;
}
