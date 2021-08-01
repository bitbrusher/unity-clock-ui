using Code.Game;
using UnityEngine;

public class DontStarveClock : IClock
{
    private const float HoursToDegrees = 360f / 24f;

    private readonly float _startRotation;
    private readonly ITimeManager _timeManager;
    private readonly DontStarveClockReferences _references;

    public DontStarveClock(ITimeManager timeManager, DontStarveClockReferences references)
    {
        _timeManager = timeManager;
        _references = references;
        _references.nightBackground.fillAmount = _timeManager.GetConfiguration().nightDuration;
        _startRotation = _timeManager.GetConfiguration().sunriseHour * HoursToDegrees;
    }

    public void Update()
    {
        _references.hand.rotation = Quaternion.Euler(0, 0, _startRotation - _timeManager.GetHour() * HoursToDegrees);
    }
}