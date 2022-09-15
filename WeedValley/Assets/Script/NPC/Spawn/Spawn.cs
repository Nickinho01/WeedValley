using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public static bool NpcInRoom;
    public GameObject NPC;
    // Start is called before the first frame update
    void Start()
    {
        Instantiate(NPC, transform.position, Quaternion.identity);
        NpcInRoom = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(NpcInRoom == false) {
            Instantiate(NPC, transform.position, Quaternion.identity);
            NpcInRoom = true;
        }        
    }
}
