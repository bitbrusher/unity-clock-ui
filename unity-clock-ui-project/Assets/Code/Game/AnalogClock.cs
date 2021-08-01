using Code.Game;
using UnityEngine;

public class AnalogClock : IClock
{
    private readonly ITimeManager _timeManager;
    private readonly AnalogClockHands _hands;

    private const float HoursToDegrees = 360f / 12f;
    private const float MinutesToDegrees = 360f / 60f;

    public AnalogClock(ITimeManager timeManager, AnalogClockHands hands)
    {
        _timeManager = timeManager;
        _hands = hands;
    }

    public void Update()
    {
        _hands.hourHand.rotation = Quaternion.Euler(0, 0, -_timeManager.GetHour() * HoursToDegrees);
        _hands.minuteHand.rotation = Quaternion.Euler(0, 0, -_timeManager.GetMinutes() * MinutesToDegrees);
    }
}
