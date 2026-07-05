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
    public string Desc;
    //Slot//
    [SerializeField]
    private TMP_Text amountText;
    [SerializeField]
    private Image itemImage;
    //Description//
    public Image ItemImage;
    public TMP_Text ItemName;
    public TMP_Text ItemDesc;
    public Sprite EmptyS;
    private Inventory InvManager;
    public GameObject Selected;
    public bool isSelected;
    private void Start()
    {
        InvManager = GameObject.Find("UI").GetComponent<Inventory>();
    }
    public void AddItem(string name, int amount,int maxAmount, Sprite image, bool HB, string ItemDesc)
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
        this.Desc = ItemDesc;
        this.image = image;
        this.maxAmount = maxAmount;
        this.max = (this.amount >= maxAmount);
        amountText.text = this.amount.ToString();
        amountText.enabled = true;
        itemImage.sprite = image;
        empty = false;
    }
    public void emptyout(bool HB)
    {
        amountText.enabled = false;
        itemImage.sprite = EmptyS;
        if (!HB)
        {
            ItemImage.sprite = EmptyS;
            ItemName.text = " ";
            ItemDesc.text = " ";
        } 
    }
    public void OnPointerClick(PointerEventData eventData)
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            OnAction();
        }
        if (eventData.button == PointerEventData.InputButton.Right)
        {

        }
    }
    public void OnAction()
    {
        if (isSelected)
        {
            InvManager.UseItem(name);
            this.amount -= 1;
            amountText.text = this.amount.ToString();
            if (this.amount <= 0)
            {
                if (InvManager.actmenu)
                {
                    emptyout(false);
                }
                else
                {
                    emptyout(true);
                }
            }
            if (InvManager.actmenu)
            {
                InvManager.updatehotbar();
            }
            else
            {
                InvManager.updateStorage();
            }
        }
        else
        {
            InvManager.deselect();
            Selected.SetActive(true);
            isSelected = true;
            if (InvManager.actmenu)
            {
                ItemImage.sprite = image;
                ItemName.text = name;
                ItemDesc.text = Desc;
            }
        }
        
    }
}
