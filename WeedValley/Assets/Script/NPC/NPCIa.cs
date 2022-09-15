using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIa : MonoBehaviour
{
    private Vector2 directionVector;
    public float speed;
    private Rigidbody2D myRigidbody;
    public BoxCollider2D bc;
    public Animator animation;
    public static int order;
    bool Walking = true;
    public GameObject exit;
    public GameObject NPC;
    bool isDrug = false;

    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        bc = GetComponent<BoxCollider2D>();
        animation = GetComponent<Animator>();
        if(Walking){
            InvokeRepeating("ChangeDiretion", 0, 1f);
        }
        order = Order();
    }

    // Update is called once per frame
    void Update()
    {
        if(Walking){
            Move();
        } else{
            Exit();
        }
        
    }
    void FixedUpdate(){
        
    }

    public static int Order()
    {
        int drug = Random.Range(1, 4);
        print(drug);
        return drug;
    }

    private void Move()
    {
        if(Walking){
            myRigidbody.MovePosition(myRigidbody.position + directionVector * speed * Time.deltaTime); 
        }
    }

    private void Exit()
    {
        transform.position = Vector2.MoveTowards(transform.position, exit.transform.position, speed * Time.deltaTime); 
    }

    void ChangeDiretion()
{
    int direction = Random.Range(0, 5);
    switch (direction)
    {
        case 0:
            directionVector =  Vector2.right;
            animation.SetFloat("Horizontal", 1);
            animation.SetFloat("Vertical", 0);
            break;
        case 1:
            directionVector = Vector2.up;
            animation.SetFloat("Vertical", 1);
            animation.SetFloat("Horizontal", 0);
            break;
        case 3:
            directionVector = Vector2.left;
            animation.SetFloat("Horizontal", -1);
            animation.SetFloat("Vertical", 0);
            break;
        case 4:
            directionVector = Vector2.down;
            animation.SetFloat("Vertical", -1);
            animation.SetFloat("Horizontal", 0);
            break;
        default:
            break;
    }
}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Parede")
        {
            ChangeDiretion();
        }
        if(collision.gameObject.tag == "Exit"){
            if(isDrug)
            {
                Destroy(gameObject);
                Spawn.NpcInRoom = false;
                print("foi");
            }
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player"){
            if(HUD_Control.droga_Select == order)
            {
                isDrug = true;
                Walking = false;
            }
        }

        if(collision.gameObject.tag == "Exit"){
            if(isDrug)
            {
                Destroy(gameObject);
                Spawn.NpcInRoom = false;
                print("foi");
            }
        }
    }
}

