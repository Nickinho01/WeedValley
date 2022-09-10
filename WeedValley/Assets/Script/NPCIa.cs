using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NPCIa : MonoBehaviour
{
    private Vector2 directionVector;
    private Transform myTransform;
    public float speed;
    private Rigidbody2D myRigidbody;
    public float frequency = 1f;
    public BoxCollider2D bc;
    public Animator animation;

    
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
        bc = GetComponent<BoxCollider2D>();
        animation = GetComponent<Animator>();
        InvokeRepeating("ChangeDiretion", 0, frequency);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
        
    }

    private void Move()
    {

            myRigidbody.MovePosition(myRigidbody.position+ directionVector * speed * Time.deltaTime); 
        
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
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Parede")
        {
            ChangeDiretion();
            
        }
    }
}
