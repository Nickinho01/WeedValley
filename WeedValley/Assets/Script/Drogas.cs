using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Drogas : MonoBehaviour
{
    BoxCollider2D bc;
    public int value_Drug;
    public bool drugSelect;
    // Start is called before the first frame update
    void Start()
    {
        bc = GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("e") && drugSelect){
                HUD_Control.droga_Select = value_Drug;
            }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            GetComponent<Animator>().SetBool("Select", true);
            drugSelect = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            GetComponent<Animator>().SetBool("Select", false);
            drugSelect = false;
        }
    }
}
