using UnityEngine;
using System.Collections;

public class Bouncy : MonoBehaviour
{
    public float force = 500f;

    private Animator anim;

    void Awake()
    {
        anim = GetComponent<Animator>();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    IEnumerator AnimateBouncy()
    {
        anim.Play("BouncerUp");
        yield return new WaitForSeconds(0.5f);

        anim.Play("BouncerDown");

    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerScript>().BouncePlayerWithBouncy(force);
            StartCoroutine(AnimateBouncy());
        }
    }
}
