using UnityEngine;
using System.Collections;

public class SpiderWalker : MonoBehaviour
{
    [SerializeField] private Transform startPos, endPos;
    private bool collision;

    public float speed = 1f;
    private Rigidbody2D myBody;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    void FixedUpdate()
    {
        Move();
        ChangeDirection();
    }

    void ChangeDirection()
    {
        collision = Physics2D.Linecast(startPos.position, endPos.position, 1 << LayerMask.NameToLayer("Ground"));
        if(!collision)
        {
            Vector3 temp = transform.localScale;
            temp.x = -1 * temp.x;
            //if (temp.x == 4f)
            //{
            //    temp.x = -4f;
            //} else
            //{
            //     temp.x = 4f;
            //}
            transform.localScale = temp;
        }
    }

    void Move()
    {
        myBody.linearVelocity = new Vector2(transform.localScale.x, 0) * speed;
    }

    void CollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }
}
