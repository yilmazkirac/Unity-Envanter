using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(fileName = "Item", menuName = "Item/Yeni Item Olustur")]
public class Item : ScriptableObject
{

    public string itemAdi;
    public Sprite itemResmi;
    public string itemAciklama;
    public int Miktar=1;

}
