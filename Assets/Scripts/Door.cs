using UnityEngine;
using System.Collections;
//using Unity.VisualScripting;

public class Door : MonoBehaviour
{
    public static Door instance;

    private Animator anim;
    private BoxCollider2D box;

    [HideInInspector]
    public int collectablesCount;

    void Awake()
    {
        MakeInstance();
        anim = GetComponent<Animator>();
        box = GetComponent<BoxCollider2D>();
    }
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void MakeInstance()
    {
        if(instance == null)
        {
            instance = this;
        }
    }

    IEnumerator OpenDoor()
    {
        anim.Play("Door_Open");
        yield return new WaitForSeconds(0.7f);
        box.isTrigger = true;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            Debug.Log("Game Finished");
        }
    }

    public void DecrementCollectables()
    {
        collectablesCount--;
        if (collectablesCount == 0)
        {
            StartCoroutine(OpenDoor());
        }
    }
}
