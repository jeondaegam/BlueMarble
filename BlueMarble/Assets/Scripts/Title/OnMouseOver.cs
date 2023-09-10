using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class OnMouseOver : MonoBehaviour,
    IPointerEnterHandler, IPointerDownHandler, IPointerUpHandler, IPointerExitHandler
{
    private Outline Outline;
    private Text Text;


    // Start is called before the first frame update
    void Start()
    {
        Outline = GetComponent<Outline>();
        Text = GetComponentInChildren<Text>();
    }

    // Update is called once per frame
    void Update()
    {
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        Debug.Log("OnPointer Up");
    }


    void IPointerDownHandler.OnPointerDown(PointerEventData eventData)
    {
        Debug.Log("OnPointer Down");
        Debug.Log(Text.text);
    }


    public void OnPointerEnter(PointerEventData eventData)
    {
        Debug.Log("OnPointer Enter");
        Outline.gameObject.SetActive(true);
        Outline.enabled = enabled;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        Debug.Log("OnPointer Exit");
        Outline.enabled = !enabled;
    }

}
