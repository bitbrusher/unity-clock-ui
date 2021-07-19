using TMPro;
using UnityEngine;

public class DigitalClock : MonoBehaviour
{
    private TimeManager _timeManager;
    private TMP_Text _displayText;

    public bool _24HourClock = true;

    private void Start()
    {
        _timeManager = FindObjectOfType<TimeManager>();
        _displayText = GetComponentInChildren<TMP_Text>();
    }

    private void Update()
    {
        var clockFormattedResult = _24HourClock ? _timeManager.Get24HourDigitalClock() : _timeManager.Get12HourDigitalClock();

        if (clockFormattedResult.HasChanged)
        {
            _displayText.SetCharArray(clockFormattedResult.FormattedClockInfo);
        }
    }
}
