using UnityEngine;
using System.Collections;

public class SpiderJumper : MonoBehaviour
{

    public float forceY = 300f;

    private Rigidbody2D myBody;
    private Animator anim;

    void Awake()
    {
        myBody = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2,7));
        forceY = Random.Range(350, 550);
        myBody.AddForce(new Vector2(0, forceY));
        anim.SetBool("Attack", true);

        yield return new WaitForSeconds(0.7f);
        StartCoroutine(Attack());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Ground")
        {
            anim.SetBool("Attack", false);
        }

        if(collision.tag == "Player")
        {
            Destroy(collision.gameObject);
        }
    }

}
