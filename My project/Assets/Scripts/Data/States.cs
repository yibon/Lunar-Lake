using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class States
{
    public enum GameStates
    {
        // Player is able to move, ready to cast
        Ready,

        // Animation of Casting
        Casting,

        // Lure in water, Press Mouse 1 to reel in
        Reeling,

        // MiniGame
        Catching,

        // Yay
        Caught,

        FailedToCatch
    }
}
