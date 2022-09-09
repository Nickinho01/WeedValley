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
    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
        myTransform = GetComponent<Transform>();
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
            break;
        case 1:
            directionVector = Vector2.up;
            break;
        case 3:
            directionVector = Vector2.left;
            break;
        case 4:
            directionVector = Vector2.down;
            break;
        default:
            break;
    }
}
}