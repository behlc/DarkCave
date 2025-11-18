using UnityEditor.ShaderGraph.Internal;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public float moveForce = 20f, jumpForce = 700f, maxVelocity = 4f;
    private bool grounded;

    private Rigidbody2D myBody;
    private Animator anim;

    void Awake()
    {
        InitializeVariables();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        PlayerWalkKeyBoard();
    }

    void InitializeVariables()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    void PlayerWalkKeyBoard()
    {
        float forceX = 0f;
        float forceY = 0f;

        float vel = Mathf.Abs(myBody.linearVelocity.x);

        float h = Input.GetAxisRaw("Horizontal");

        // moving to the right
        if(h > 0)
        {
            if(vel < maxVelocity)
            {
                if(grounded)
                {
                    forceX = moveForce;
                } else
                {
                    forceX = moveForce * 1.1f;
                }
            }

            // face the player in the right direction
            Vector3 scale = transform.localScale;
            scale.x = 1f;
            transform.localScale = scale;
            anim.SetBool("Walk", true);

        } else if(h < 0) // moving to the left
        {
            if(vel < maxVelocity)
            {
                if(grounded)
                {
                    forceX = -moveForce;
                } else
                {
                    forceX = -moveForce * 1.1f;
                }               
            }

            // face the player in the right direction
            Vector3 scale = transform.localScale;
            scale.x = -1f;
            transform.localScale = scale;
            anim.SetBool("Walk", true);
            
        } else if(h == 0)
        {
            anim.SetBool("Walk", false);
        }

        if(Input.GetKey(KeyCode.Space))
        {
            if(grounded)
            {
                grounded = false;
                forceY = jumpForce;
            }
        }

        myBody.AddForce (new Vector2(forceX, forceY));
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Ground")
        {
            grounded = true;
        }
    }

    public void BouncePlayerWithBouncy(float force)
    {
        if (grounded)
        {
            grounded = false;
            myBody.AddForce (new Vector2(0, force));
        }
    }
}
