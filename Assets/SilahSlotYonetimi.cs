using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class SilahSlotYonetimi : MonoBehaviour
{
    public List<GameObject> slots = new List<GameObject>();
    public GameObject secilenSlot;
    void Update()
    {
        if (!EventSystem.current.IsPointerOverGameObject())
        {
            if (Input.GetMouseButtonDown(0) && secilenSlot != null)
            {
                RaycastHit hit;
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (Physics.Raycast(ray, out hit, 100f))
                {
                    if (hit.transform.gameObject.name == "Zemin")
                    {
                        secilenSlot.GetComponent<Slot_Item>().item_kullan(hit.point);
                    }
                }
            }
        }
    }
    public void secim(GameObject gelenSlot)
    {
        if (secilenSlot != null && secilenSlot != gelenSlot)
        {
            secilenSlot.GetComponentInParent<Slot>().secimackapa();
            secilenSlot = null;
            secilenSlot = gelenSlot;
        }
        else if (secilenSlot == gelenSlot)
        {
            secilenSlot = null;
        }
        else
        {
            secilenSlot = gelenSlot;


        }
    }
    public void Slot_Item_ekle(Transform Item)
    {
        bool itemVarmi = false;
        foreach (var i in slots)
        {
            if (i.GetComponent<Slot>().slotDolumu)
            {
                if (i.GetComponentInChildren<Slot_Item>().itemadi == Item.GetComponent<Slot_Item>().itemadi)
                {
                    i.GetComponentInChildren<Slot_Item>().miktarArttýr();
                    itemVarmi = true;

                }
            }


        }


        if (!itemVarmi)
        {
            Transform gelenobjeyiOlustur = Instantiate(Item, Vector3.zero, Quaternion.identity);
            foreach (var i in slots)
            {
                if (!i.GetComponent<Slot>().slotDolumu)
                {

                    gelenobjeyiOlustur.transform.SetParent(i.transform);
                    gelenobjeyiOlustur.transform.localPosition = new Vector3(0f, 0f, 0f);
                    gelenobjeyiOlustur.transform.localScale = new Vector3(1f, 1f, 1f);
                    gelenobjeyiOlustur.GetComponent<RectTransform>().sizeDelta = new Vector2(50f, 50f);
                    i.GetComponent<Slot>().slotDolumu = true;
                    break;
                }
                else
                {
                    continue;
                }
            }
        }
    }
}

