using UnityEngine;
using System.Collections;

public class DiamondScript : MonoBehaviour
{

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if(Door.instance != null)
        {
            Door.instance.collectablesCount++;
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Destroy(gameObject);
            if(Door.instance != null)
            {
                Door.instance.DecrementCollectables();
            }
        }
    }
}
