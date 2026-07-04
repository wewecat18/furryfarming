using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ItemSlot : MonoBehaviour, IPointerClickHandler
{
    //Data//
    public new string name;
    public int amount;
    public Sprite image;
    public bool max;
    public bool empty = true;
    public int maxAmount;

    //Slot//
    [SerializeField]
    private TMP_Text amountText;
    [SerializeField]
    private Image itemImage;

    private Inventory InvManager;
    public GameObject Selected;
    public bool isSelected;

    private void Start()
    {
        InvManager = GameObject.Find("UI").GetComponent<Inventory>();
    }
    public void AddItem(string name, int amount,int maxAmount, Sprite image, bool HB)
    {
        this.name = name;
        if(HB)
        {
            this.amount = amount;
        }
        else
        {
            this.amount = this.amount + amount;
        }
            
        this.image = image;
        this.maxAmount = maxAmount;

        this.max = (this.amount >= maxAmount);
        
        amountText.text = this.amount.ToString();
        amountText.enabled = true;
        itemImage.sprite = image;
        empty = false;
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            Onleftclick();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
    public void Onleftclick()
    {
        InvManager.deselect();
        Selected.SetActive(true);
        isSelected = true;
    }
}
