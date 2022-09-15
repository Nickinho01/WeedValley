using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Order : MonoBehaviour
{
    public SpriteRenderer order;
    public Sprite[] orderImages = new Sprite[3];
    int drug;

    // Start is called before the first frame update
    void Start()
    {
        order = GetComponent<SpriteRenderer>();                
    }

    // Update is called once per frame
    void Update()
    {
        Verifica();
        switch (drug)
            {
                case 1:
                    order.sprite = orderImages[0];
                    break;
                case 2:
                    order.sprite = orderImages[1];
                    break;
                case 3:
                    order.sprite = orderImages[2];
                    break;
            }
    }

    void Verifica()
    {
        if(NPCIa.order != 0)
        {
            drug = NPCIa.order;
        }
    }
}
