using TMPro;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    private ITimeManager _timeManager;
    private TMP_Text _displayText;

    public bool is12HourClock = true;

    private void Start()
    {
        _timeManager = FindObjectOfType<TimeManagerMonoBehaviour>().GetTimeManager();
        
        _displayText = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        var clockFormattedResult = is12HourClock ? _timeManager.Get12HourDigitalClock() : _timeManager.Get24HourDigitalClock();

        if (clockFormattedResult.HasChanged)
        {
            _displayText.SetCharArray(clockFormattedResult.FormattedClockInfo);
        }
    }
}
