using UnityEngine;
using UnityEngine.EventSystems;

public class Joystick : MonoBehaviour, IPointerUpHandler, IPointerDownHandler
{
    private PlayerScript player;

    void Awake()
    {
        player = GameObject.Find("Player").GetComponent<PlayerScript>();
    }

    public void OnPointerDown(PointerEventData data)
    {
        //touch a button
        if(gameObject.name == "Left")
        {
            player.SetMoveLeft(true);
        } else
        {
            player.SetMoveLeft(false);
        }
    }

    public void OnPointerUp(PointerEventData data)
    {
        //release a button
        player.StopMoving();
    }
}
