using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class MovimentPlayer : MonoBehaviour
{
    float input_x = 0;
    float input_y = 0;
    float speed = 2.5f;

    public Animator animation;
    Rigidbody2D rb2D;
    Vector2 movement = Vector2.zero;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        animation = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        input_x = Input.GetAxisRaw("Horizontal");
        input_y = Input.GetAxisRaw("Vertical");
        movement = new Vector2(input_x, input_y);

        animation.SetFloat("Horizontal", input_x);
        animation.SetFloat("Vertical", input_y);
        animation.SetFloat("Velocidade", movement.sqrMagnitude);

        if(movement != Vector2.zero)
        {
            animation.SetFloat("HorizontalIdle", input_x);
            animation.SetFloat("VerticalIdle", input_y);
        }

    }

    private void FixedUpdate() 
    {
        rb2D.MovePosition(rb2D.position + movement * speed * Time.fixedDeltaTime);
    }
}
