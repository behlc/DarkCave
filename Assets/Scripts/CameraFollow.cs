using Unity.VisualScripting;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    private Transform player;
    [SerializeField] float playerPosY; // for camera adjustment for blank image at the bottom
    public float minX, maxX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        player = GameObject.Find("Player").transform;
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            Vector3 temp = transform.position; // camera position
            temp.x = player.position.x;

            if(temp.x < minX)
                temp.x = minX;

            if(temp.x > maxX)
                temp.x = maxX;

            temp.y = player.position.y + playerPosY;
            transform.position = temp;
        }
    }
}
