using TMPro;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    TimeManager tm;
    TMP_Text display;

    public bool _24HourClock = true;

    // Start is called before the first frame update
    void Start()
    {
        tm = FindObjectOfType<TimeManager>();
        display = GetComponentInChildren<TMP_Text>();
    }

    // Update is called once per frame
    void Update()
    {
        if(_24HourClock)
            display.text = tm.Clock24Hour();
        else
            display.text = tm.Clock12Hour();
    }
}
