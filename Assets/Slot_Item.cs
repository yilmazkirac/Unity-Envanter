using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class Slot_Item : MonoBehaviour, IPointerExitHandler, IPointerMoveHandler,IDragHandler,IBeginDragHandler,IEndDragHandler,IPointerClickHandler
{
    [SerializeField] private Item gelenItem;
    public GameObject aciklamaCanvas;
    public Image image;
    public Text aciklamaText;
    public string itemadi;
    public GameObject olusacakItem;

    public int Miktar;
    public Text miktarText;


    public GameObject silmeButton;
    public GameObject miktarImage;

    GraphicRaycaster m_raycast;

    Transform Slotum;

    bool suruklenme=false;
    private void Awake()
    {

        Miktar = gelenItem.Miktar;
        miktarText.text=Miktar.ToString();
    }
    void Start()
    {
       
        aciklamaCanvas.SetActive(false);
        image.sprite = gelenItem.itemResmi;
        aciklamaText.text = gelenItem.itemAciklama;
        m_raycast= GameObject.Find("Canvas").GetComponent<GraphicRaycaster>();
    }



    public void item_kullan(Vector3 pozisyon) 
    {
        if (Miktar>1)
        {
           
            Miktar--;
            miktarText.text = Miktar.ToString();
            Instantiate(olusacakItem, pozisyon, Quaternion.identity);
        }
        else
        {
            secimdurumu();
            Instantiate(olusacakItem, pozisyon, Quaternion.identity);
            GetComponentInParent<Slot>().slotDolumu = false;
            Destroy(gameObject);
        }
       
    }
    public void item_sil()
    {
        GetComponentInParent<Slot>().slotDolumu = false;
        Destroy(gameObject);
    }

    public void miktarArttýr()
    {
        Miktar++;
        miktarText.text = Miktar.ToString();
    }

 

    public void OnPointerExit(PointerEventData eventData)
    {
        aciklamaCanvas.SetActive(false);
    }
    public void OnPointerMove(PointerEventData eventData)
    {
        if (!suruklenme)
        {
            aciklamaCanvas.SetActive(true);
            aciklamaCanvas.transform.position = Input.mousePosition;
        }
       
    }

    public void OnBeginDrag(PointerEventData eventData)
    {


        Slotum = transform.parent;

        suruklenme = true;
        aciklamaCanvas.SetActive(false);
        silmeButton.SetActive(false);
        miktarImage.SetActive(false);
        gameObject.transform.SetParent(GetComponentInParent<Slot_Paneli>().transform);
    }

    public void OnDrag(PointerEventData eventData)
    {
     transform.position = Input.mousePosition;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
         eventData.position = Input.mousePosition;
        List<RaycastResult> results = new List<RaycastResult>();
         m_raycast.Raycast(eventData, results);

        // Debug.Log( results[1].gameObject.name);
        if (results.Count == 3 && !results[1].gameObject.GetComponent<Slot>().slotDolumu && !Slotum.GetComponent<Slot>().slotSecilimi)
        {
            transform.parent = results[1].gameObject.transform;
            transform.localPosition = new Vector3(0f, 0f, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(50f, 50f);
            results[1].gameObject.GetComponent<Slot>().slotDolumu = true;
            Slotum.GetComponent<Slot>().slotDolumu = false;
        }
        else
        {
            transform.parent = Slotum.transform;
            transform.localPosition = new Vector3(0f, 0f, 0f);
            transform.localScale = new Vector3(1f, 1f, 1f);
            transform.GetComponent<RectTransform>().sizeDelta = new Vector2(50f, 50f);
        }

  



        suruklenme = false;
        silmeButton.SetActive(true);
        miktarImage.SetActive(true);
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button==PointerEventData.InputButton.Right)
        {
            secimdurumu();
            GetComponentInParent<Slot_Paneli>().secim(gameObject);
        }
      
    }
    public void secimdurumu()
    {
        GetComponentInParent<Slot>().secimackapa();
    }
}
