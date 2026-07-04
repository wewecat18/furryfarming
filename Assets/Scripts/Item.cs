using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item : MonoBehaviour
{
  
    [SerializeField]
    private string ItemName;
    [SerializeField]
    private int amount;
    [SerializeField]
    private Sprite image;
    [SerializeField]
    private int maxAmount;

    private Inventory InvManager;
    void Start()
    {
        InvManager = GameObject.Find("UI").GetComponent<Inventory>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            InvManager.Isfull(name, maxAmount);
            if (InvManager.full == false)
            {
                InvManager.AddItem(ItemName, amount, maxAmount, image);
                Destroy(gameObject);
            }
        }
    }
}
