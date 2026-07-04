using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Inventory : MonoBehaviour
{
    public GameObject Menu;
    public GameObject hotbar;
    private bool actmenu = false;
    public bool full;
    public ItemSlot[] IS;
    public ItemSlot[] HB;
    
    void Start()
    {

}
    void Update()
    {
        if (Input.GetButtonDown("Submit") && actmenu)
        {
            Time.timeScale = 1;
            Menu.SetActive(false);
            hotbar.SetActive(true);
            actmenu = false;
           


        }
        else if (Input.GetButtonDown("Submit") && !actmenu)
        {
            Time.timeScale = 0;
            Menu.SetActive(true);
            hotbar.SetActive(false);
            actmenu = true;
            

        }
    }
    public void updatehotbar()
    {
        for (int i = 0; i < HB.Length; i++)
        {
            ItemSlot Origin = IS[i];
            if (Origin.empty == false)
            {
                HB[i].AddItem(Origin.name, Origin.amount, Origin.maxAmount, Origin.image, true);
            }
            else
            {
                HB[i].empty = true;
                HB[i].name = "";
                HB[i].amount = 0;
            }
        }
    }
    public void AddItem(string name, int amount, int maxAmount, Sprite image)
    {
        int i = 0;
        bool repetido = false;
        bool extra = false;
        for (int j = 0; j < IS.Length; j++)
        {
            if (IS[j].name == name)
            {
                if (IS[j].amount != maxAmount)
                {
                    repetido = true;
                }

                if (repetido)
                {
                    if ((IS[j].amount + amount) > maxAmount)
                    {
                        int newAmount = (IS[j].amount + amount) - maxAmount;
                        int fill = maxAmount - IS[j].amount;
                        IS[j].AddItem(name, fill, maxAmount, image, false);
                        repetido = false;
                        extra = true;
                        AddItem(name, newAmount, maxAmount, image);
                        break;
                    }
                    else
                    {
                        IS[j].AddItem(name, amount, maxAmount, image, false);
                        break;
                    }
                }
            }
        }
        if (!extra)
        {
            if (!repetido)
            {
                while (i < IS.Length)
                {
                    if (IS[i].empty == true || IS[i].name == name)
                    {
                        if (IS[i].max == false)
                        {
                            if ((IS[i].amount + amount) > maxAmount)
                            {
                                int newAmount = (IS[i].amount + amount) - maxAmount;
                                int fill = maxAmount - IS[i].amount;
                                IS[i].AddItem(name, fill, maxAmount, image, false);
                                AddItem(name, newAmount, maxAmount, image);
                                break;
                            }
                            else
                            {
                                IS[i].AddItem(name, amount, maxAmount, image, false);
                                break;
                            }

                        }
                    }
                    i++;
                }
            }
        }
        updatehotbar();
    }

    public void Isfull(string name, int maxAmount)
    {
        for (int i = 0; i < IS.Length; i++)
        {
            if (IS[i].empty == true)
            {
                full = false;
                return;
            }
            if (IS[i].name == name)
            {
                if (IS[i].amount != maxAmount)
                {
                    full = false;
                    return;
                }
            }
            if ((i + 1) == IS.Length)
            {
                full = true;
                return;
            }
            
        }
    }
    public void deselect()
    {
        if (actmenu)
        {
            for (int i = 0; i < IS.Length; i++)
            {
                IS[i].Selected.SetActive(false);
                IS[i].isSelected = false;
            }
        }
        else
        {
            for (int i = 0; i < HB.Length; i++)
            {
                HB[i].Selected.SetActive(false);
                HB[i].isSelected = false;
            }
        }
    }
}
