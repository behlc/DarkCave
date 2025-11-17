using UnityEngine;

public class SpiderBullet : MonoBehaviour
{

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // destroy the Player
            Destroy(collision.gameObject);
            Destroy(gameObject); // bullet
        }

        if(collision.tag == "Ground")
        {
            Destroy(gameObject); // bullet
        }
    }
}
