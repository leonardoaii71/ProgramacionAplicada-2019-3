using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class Game 
{
    public static Level CurrentLevel;
    
    public static GameOptions options{
        get
        {
            return GameOptions.Instance;
        }
    }

}
