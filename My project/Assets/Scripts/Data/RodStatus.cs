using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class RodStatus : MonoBehaviour
{
    //this .cs will go onto each fish to store their information and can be acessed from anywhere.
    [SerializeField]
    public string rodID;
    [HideInInspector]
    public string rodName;
    [HideInInspector]
    public string rodDescription;
    [HideInInspector]
    public string rodEffect;
    [HideInInspector]
    public float rodLineLength;
    [HideInInspector]
    public float rodHookRange;

    // Start is called before the first frame update
    void Start()
    {
        //this is to automate the process of naming all the fishes by using the name of the sprite renderer/gameobject
        //can uncomment later
        //rodID= this.gameObject.name;

        //these values will only change when there is any rod effect or when fishes are in inventory and affect them
        rodLineLength = 2;
        rodHookRange = 2;
        //caluculation for the effect. (OriginalRodValue + <Fish effects>) * Rod Effect

        switch (rodID) 
        {
            case "R01":
                rodName = "The Basic Rod";
                rodDescription = "The beginner's rod, basic with no add ons";
                rodEffect = "";
                break;
            case "R02":
                rodName = "The Long Rod";
                rodDescription = "The rod's line length can now be increased further for deep sea fishes";
                rodEffect = "rodLineLength *= 1.3f";
                break;
            case "R03":
                rodName = "The Sturdy Rod";
                rodDescription = "It is now easier to catch fishes";
                rodEffect = "rodHookRange *= 1.3f";
                break;
            case "R04":
                rodName = "The Treasuer Rod";
                rodDescription = "An Old Rod once used by a famous fisherman. It has since lost all it's effect. dubbed the meme rod";
                rodEffect = "rodLineLength = 2, rodHookRange = 2";
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
