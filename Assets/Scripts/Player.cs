using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] private float moveForce = 10f;

    [SerializeField] private float ForceJump = 11f;

    private float movementX;

    public Rigidbody2D myBody;

    private SpriteRenderer sr;

    private Animator anim;
    private readonly string WALK_ANIMATION = "Walk";

    private bool grounded = true;

    private readonly string _ground = "Ground";
    private readonly string enem_tag = "Enemy";

    private void Awake()
    {
        myBody.GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();

        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    private void Update()
    {
        MovePlayer();
        AnimatePlayer();
        PlayerJump();
    }

    private void MovePlayer()
    {
        movementX = Input.GetAxisRaw("Horizontal");
        transform.position += moveForce * Time.deltaTime * new Vector3(movementX, 0f, 0f);
    }

    private void AnimatePlayer()
    {
        if (movementX > 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = false;
        }
        else if (movementX < 0)
        {
            anim.SetBool(WALK_ANIMATION, true);
            sr.flipX = true;
        }
        else
            anim.SetBool(WALK_ANIMATION, false);
    }

    private void PlayerJump()
    {
        if (Input.GetButtonDown("Jump") && grounded)
        {
            grounded = false;
            myBody.AddForce(new Vector2(0f, ForceJump), ForceMode2D.Impulse);
        }
    }

    //detects if the player touched the enemy. 
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag(_ground))
            grounded = true;

        if (collision.gameObject.CompareTag(enem_tag))
            Destroy(gameObject);
    }

    private void OnDestroy()
    {
        Invoke(nameof(GameplayUIController.RestartButton), 5f);
    }
}