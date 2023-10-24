using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
   Color32 hoverColor=new Color32(19,37,37,255);
   Color32 defoultColor=new Color32(48,67,67,255);
    public bool slotDolumu=false;
    public GameObject slotSecim;
    public bool slotSecilimi=false;
    public void OnPointerEnter(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = hoverColor;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.GetComponent<Image>().color = defoultColor;
    }

public void secimackapa()
    {
        
        slotSecim.SetActive(!slotSecim.activeSelf);
        if (slotSecilimi)
        {
            slotSecilimi = false;
        }
        else
        {
            slotSecilimi = true;
        }
   
    }
}
