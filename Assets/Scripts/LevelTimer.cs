using UnityEngine;
using UnityEngine.UI;

public class LevelTimer : MonoBehaviour
{
    private Slider slider;
    private GameObject player;
    [SerializeField] private float timeBurn = 1f;
    public float time = 10f;

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

        if(time > 0)
        {
            time -= timeBurn * Time.deltaTime;
            slider.value = time;
        } else
        {
            Destroy(player);
        }
    }

    void GetReferences()
    {
        player = GameObject.Find("Player");
        slider = GameObject.Find("TimeSlider").GetComponent<Slider>();
        slider.minValue = 0f;
        slider.maxValue = time;
        slider.value = slider.maxValue;
    }

}
