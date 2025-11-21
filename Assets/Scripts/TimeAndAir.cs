using UnityEngine;

public class TimeAndAir : MonoBehaviour
{
    [SerializeField] float addAir = 15f;
    [SerializeField] float addTime = 10f;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Player")
        {
            if(gameObject.name == "Air")
            {
                GameObject.Find("GameplayController").GetComponent<AirTimer>().air += addAir;
            } else
            {
                GameObject.Find("GameplayController").GetComponent<LevelTimer>().time += addTime;
            }
            Destroy(gameObject);
        }
    }
}
