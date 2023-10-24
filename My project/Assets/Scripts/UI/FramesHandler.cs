using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class FramesHandler : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public static string currFrame;

    public void OnPointerEnter(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Top Frame":
                currFrame = "Top";
                break;  
                
            case "Middle Frame":
                currFrame = "Mid";
                break;           
                
            case "Bottom Frame":
                currFrame = "Bot";
                break;
        }    
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        switch (gameObject.name)
        {
            case "Top Frame":
            case "Middle Frame":
            case "Bottom Frame":
                currFrame = "None";
                break;
        }

    }
}

