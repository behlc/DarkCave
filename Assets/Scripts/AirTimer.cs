using UnityEngine;
using UnityEngine.UI;

public class AirTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    [SerializeField] private float airBurn = 1f;
    public float air = 10f;

    void Awake()
    {
        GetReferences();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(!player)
            return;

        if(air > 0)
        {
            air -= airBurn * Time.deltaTime;
            slider.value = air;
        } else
        {
            Destroy(player);
        }
    }

    void GetReferences()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("AirSlider").GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = air;
        slider.value = slider.maxValue;
    }
}
