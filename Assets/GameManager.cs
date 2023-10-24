using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject slotPanel;
    bool envanterAcikmi;
    void Start()
    {

    }


    void Update()
    {
       
        if (Input.GetKeyDown(KeyCode.I))
        {
            envanterAcikmi = !envanterAcikmi;
            slotPanel.SetActive(envanterAcikmi);
        }

        if (Input.GetKeyDown(KeyCode.E))
        {
            RaycastHit hit;
      
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, 100f))
            {
                if (hit.transform.gameObject.GetComponent<Sahne_item>() != null)
                {
                  
                    slotPanel.GetComponent<Slot_Paneli>().Slot_Item_ekle(hit.transform.gameObject.GetComponent<Sahne_item>().item);
                }
            }
        }

    }
}
