using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class LogBookButton : MonoBehaviour, IPointerClickHandler, IPointerExitHandler, IPointerEnterHandler, IPointerUpHandler
{
    [SerializeField] Sprite imageDefault;
    [SerializeField] Sprite imageHover;
    [SerializeField] GameObject exclaimation;
    [SerializeField] GameObject logBook;

    AudioManager _am;
    Image _image;
    public bool playOnce;

    private void Start()
    {
        _am = FindObjectOfType<AudioManager>();
        playOnce = false;
        _image = this.GetComponent<Image>();
    }

    private void Update()
    {
        //Debug.Log("BookOpen: " + playOnce);
    }


    public void OnPointerClick(PointerEventData eventData)
    {
        logBook.SetActive(true);
        exclaimation.SetActive(false);

        // vv doesnt work
        if (!playOnce)
        {
            Debug.Log("LLLLLLLLLLLLLLLLll");
            _am.Play("Book Open");
            playOnce = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _image.sprite = imageHover;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _image.sprite = imageDefault;
        //playOnce = false;
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("FFFFFFFFFFFFFFFFF");
        //playOnce = false;
        _am.Stop("Book Open");
    }

    public void SetPlayOnce()
    {
       this.playOnce = false;
    }
}
