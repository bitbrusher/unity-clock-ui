using Code.Game;
using UnityEngine;

public class StardewClock : IClock
{
    private const float HoursToDegrees = 180f / 24f;

    private readonly ITimeManager _timeManager;
    private readonly StardewClockReferences _references;

    public StardewClock(ITimeManager timeManager, StardewClockReferences references)
    {
        _timeManager = timeManager;
        _references = references;
        _references.nightBackground.fillAmount = _timeManager.GetConfiguration().nightDuration / 2;
    }

    public void Update()
    {
        _references.hand.localRotation = Quaternion.Euler(0, 0,
            90 - HoursToDegrees * ((_timeManager.GetHour() + TimeManager.HoursInDay - _timeManager.GetConfiguration().sunriseHour) %
                                   TimeManager.HoursInDay));
    }
}