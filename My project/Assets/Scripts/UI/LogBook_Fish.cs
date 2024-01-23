using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.Rendering;
using UnityEngine.UI;

public class LogBook_Fish : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    Transform tags;
    public string LB_fishClicked;
    public GameObject fishPopup;
    Image _img;

    private void Start()
    {
        tags = transform.Find("Tag");
        _img = GetComponent<Image>();
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        tags.gameObject.SetActive(true);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        tags.gameObject.SetActive(false);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (fishPopup.activeInHierarchy)
        {
            if (EventSystem.current.IsPointerOverGameObject())
            {
                return;
            }
        }

        if (_img.color == Color.white)
        {
            LB_fishClicked = eventData.pointerClick.name;
            Debug.Log("Fish Clicked: " + LB_fishClicked);
            fishPopup.SetActive(true);
            fishPopup.transform.Find(LB_fishClicked).gameObject.SetActive(true);
            //LB_fishClicked = string.Empty;
        }

    }
}
 