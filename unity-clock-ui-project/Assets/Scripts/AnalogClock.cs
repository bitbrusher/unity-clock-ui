using UnityEngine;

public class AnalogClock : MonoBehaviour
{
    private ITimeManager _timeManager;

    public RectTransform minuteHand;
    public RectTransform hourHand;

    private const float HoursToDegrees = 360f / 12f;
    private const float MinutesToDegrees = 360f / 60f;

    private void Start()
    {
        _timeManager = FindObjectOfType<TimeManagerMonoBehaviour>().GetTimeManager();
    }

    private void Update()
    {
        hourHand.rotation = Quaternion.Euler(0, 0, -_timeManager.GetHour() * HoursToDegrees);
        minuteHand.rotation = Quaternion.Euler(0, 0, -_timeManager.GetMinutes() * MinutesToDegrees);
    }
}
