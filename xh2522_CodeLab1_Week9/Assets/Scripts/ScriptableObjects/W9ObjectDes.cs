using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

[CreateAssetMenu(
    fileName = "New Item Information", menuName = "ScriptableObjects/NewItem", order = 1)]



public class W9ObjectDes : ScriptableObject
{
    
    public string ItemName;
    public string ItemDescription;
    public W9ObjectDes Love;
    public W9ObjectDes Heal;
    public W9ObjectDes Energy;
    public W9ObjectDes Mana;
    public W9ObjectDes Poison;
    public GameObject currentPic;
    
}
