using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField]
    float moveForce = 10f;

    [SerializeField]
    float ForceJump = 11f;

    float movementX;

    public Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private string WALK_ANIMATION = "Walk";

    private bool grounded = true;

    private string _ground = "Ground";
    string enem_tag = "Enemy";

    private void Awake()
    {
        myBody.GetComponent<Rigidbody2D>();
        anim= GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMoveKeeb();
        AnimatePlayer();
        PlayerJump();
    }

    void PlayerMoveKeeb()
    {
        movementX = Input.GetAxisRaw("Horizontal"); //gets input from the keyboard I assume

        transform.position += new Vector3(movementX, 0f, 0f) * Time.deltaTime * moveForce; //the line for moving the character
    }

    void AnimatePlayer()
    {
        if (movementX > 0) //we're going to the left side
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false; //facing during animation
        }
        else if (movementX < 0) //we're going to the right side.
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
        {
            anim.SetBool(WALK_ANIMATION, false);
        }
    }

    void PlayerJump()
    {
        if(Input.GetButtonDown("Jump") && grounded) //only press down the button
        {
            grounded = false;
            myBody.AddForce(new Vector2(0f, ForceJump), ForceMode2D.Impulse);
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_ground))
        {
            grounded = true;
        }

        if (collision.gameObject.CompareTag(enem_tag))
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag(enem_tag))
            Destroy(gameObject);
    }
}