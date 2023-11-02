using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class BuffIndicators : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField ]GameObject hrContainer;
    [SerializeField ]GameObject llContainer;

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.gameObject.name == "LR")
        {
            llContainer.SetActive(true);
        }

        if (this.gameObject.name == "HR")
        {
            hrContainer.SetActive(true);
        }
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (this.gameObject.name == "LR")
        {
            llContainer.SetActive(false);
        }

        if (this.gameObject.name == "HR")
        {
            hrContainer.SetActive(false);
        }
    }

    // Start is called before the first frame update
} 