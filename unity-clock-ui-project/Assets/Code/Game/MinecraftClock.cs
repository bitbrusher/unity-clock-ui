using Code.Game;
using UnityEngine;

public class MinecraftClock : IClock
{
    private readonly ITimeManager _timeManager;
    private readonly MinecraftClockReferences _references;
    private readonly float _nightHoursToDegrees;
    private readonly float _dayHoursToDegrees;
    private readonly TimeManagerConfiguration _timeManagerConfiguration;

    public MinecraftClock(ITimeManager timeManager, MinecraftClockReferences references)
    {
        _timeManager = timeManager;
        _references = references;

        _timeManagerConfiguration = _timeManager.GetConfiguration();
        _nightHoursToDegrees = 180 / (TimeManager.HoursInDay * _timeManagerConfiguration.nightDuration);
        _dayHoursToDegrees = 180 / (TimeManager.HoursInDay * (1 - _timeManagerConfiguration.nightDuration));

        _references.skyDome.rotation = Quaternion.Euler(0, 0, 90 + _timeManagerConfiguration.sunriseHour * _nightHoursToDegrees);
    }

    public void Update()
    {
        if (((_timeManager.GetHour() < _timeManagerConfiguration.sunriseHour || _timeManager.GetHour() > _timeManager.GetSunsetHour()) &&
             _timeManagerConfiguration.sunriseHour < _timeManager.GetSunsetHour()) ||
            ((_timeManager.GetHour() < _timeManagerConfiguration.sunriseHour && _timeManager.GetHour() > _timeManager.GetSunsetHour()) &&
             _timeManagerConfiguration.sunriseHour > _timeManager.GetSunsetHour()))
        {
            _references.skyDome.Rotate(0, 0,
                -Time.deltaTime * TimeManager.HoursInDay * _nightHoursToDegrees / _timeManagerConfiguration.dayDuration);
        }
        else
        {
            _references.skyDome.Rotate(0, 0,
                -Time.deltaTime * TimeManager.HoursInDay * _dayHoursToDegrees / _timeManagerConfiguration.dayDuration);
        }
    }
}