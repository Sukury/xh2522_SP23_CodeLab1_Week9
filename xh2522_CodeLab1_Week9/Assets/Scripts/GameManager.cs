using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Unity.VisualScripting;
using UnityEngine.UI;


public class GameManager : MonoBehaviour
{
    public TextMeshProUGUI Name;
    public TextMeshProUGUI Description;
    public CanvasGroup canvasGroup;
    public CanvasGroup buyItemGroup;

    public W9ObjectDes currentItem;
    public Button Love;
    public Button Heal;
    public Button Energy;
    public Button Poison;
    public Button Mana;
    public GameObject BuyMana;
    public GameObject BuyLove;
    public GameObject BuyEnergy;
    public GameObject BuyHeal;
    public GameObject BuyPoison;

    
 
    // Start is called before the first frame update
    void Start()
    {
        
        UpdateObject();

    }

   
    void UpdateObject()
    {
        Name.text = currentItem.ItemName;
        Description.text = currentItem.ItemDescription;
        
        if (currentItem.Love == null)
        {
            Love.gameObject.SetActive(true);
        }

        if (currentItem.Energy == null)
        {
            Energy.gameObject.SetActive(true);
        }

        if (currentItem.Mana == null)
        {
            Mana.gameObject.SetActive(true);
        }

        if (currentItem.Poison==null)
        {
            Poison.gameObject.SetActive(true);
        }
        
        if (currentItem.Heal==null)
        {
            Heal.gameObject.SetActive(true);
        }
        
        
    }

    public void OnButtomClick(int dir)
    {
        
        switch (dir)
        {
            case 0:
                DestroyObjectIfHasChild();
                currentItem = currentItem.Love;
                Instantiate(currentItem.currentPic, canvasGroup.transform);
                BuyLove.SetActive(true);
                break;
            case 1:
                DestroyObjectIfHasChild();
                currentItem = currentItem.Heal;
                Instantiate(currentItem.currentPic, canvasGroup.transform);
                BuyHeal.SetActive(true);
                break;
            case 2:
                DestroyObjectIfHasChild();
                currentItem = currentItem.Mana;
                Instantiate(currentItem.currentPic, canvasGroup.transform);
                BuyMana.SetActive(true);
                break;
            case 3:
                DestroyObjectIfHasChild();
                currentItem = currentItem.Energy;
                Instantiate(currentItem.currentPic, canvasGroup.transform);
                BuyEnergy.SetActive(true);
                break;
            case 4:
                DestroyObjectIfHasChild();
                currentItem = currentItem.Poison;
                Instantiate(currentItem.currentPic, canvasGroup.transform);
                BuyPoison.SetActive(true);
                break;
        }
        
        UpdateObject();
    }
    
    public void DestroyObjectIfHasChild()
    {
        if (canvasGroup.transform.childCount > 0)
        {
            foreach (Transform child in canvasGroup.transform)
            {
                Destroy(child.gameObject);
            }
        }
        
        if (buyItemGroup.transform.childCount > 0)
        {
            foreach (Transform child in buyItemGroup.transform)
            {
                child.gameObject.SetActive(false);
            }
        }
    }
    
}
