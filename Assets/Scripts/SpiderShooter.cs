using System.Collections;
using UnityEngine;

public class SpiderShooter : MonoBehaviour
{
    [SerializeField] private GameObject bullet;

    void Start()
    {
        StartCoroutine(Attack());
    }

    IEnumerator Attack()
    {
        yield return new WaitForSeconds(Random.Range(2,7));
        Instantiate(bullet, transform.position, Quaternion.identity);
        StartCoroutine(Attack());
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            // destroy the Player
            Destroy(collision.gameObject);
            GameObject.Find("GameplayController").GetComponent<GameplayController>().PlayerDied();
        }
    }
}
