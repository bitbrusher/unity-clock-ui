using UnityEngine;

public class MinecraftClock : MonoBehaviour
{
    public RectTransform skyDome;

    private ITimeManager _timeManager;
    private float _nightHoursToDegrees;
    private float _dayHoursToDegrees;
    private TimeManagerConfiguration _timeManagerConfiguration;

    private void Start()
    {
        _timeManager = FindObjectOfType<TimeManagerMonoBehaviour>().GetTimeManager();

        _timeManagerConfiguration = _timeManager.GetConfiguration();
        _nightHoursToDegrees = 180 / (TimeManager.HoursInDay * _timeManagerConfiguration.nightDuration);
        _dayHoursToDegrees = 180 / (TimeManager.HoursInDay * (1 - _timeManagerConfiguration.nightDuration));

        skyDome.rotation = Quaternion.Euler(0, 0, 90 + _timeManagerConfiguration.sunriseHour * _nightHoursToDegrees);
    }

    private void Update()
    {
        if (((_timeManager.GetHour() < _timeManagerConfiguration.sunriseHour || _timeManager.GetHour() > _timeManager.GetSunsetHour()) &&
             _timeManagerConfiguration.sunriseHour < _timeManager.GetSunsetHour()) ||
            ((_timeManager.GetHour() < _timeManagerConfiguration.sunriseHour && _timeManager.GetHour() > _timeManager.GetSunsetHour()) &&
             _timeManagerConfiguration.sunriseHour > _timeManager.GetSunsetHour()))
        {
            skyDome.Rotate(0, 0, -Time.deltaTime * TimeManager.HoursInDay * _nightHoursToDegrees / _timeManagerConfiguration.dayDuration);
        }
        else
        {
            skyDome.Rotate(0, 0, -Time.deltaTime * TimeManager.HoursInDay * _dayHoursToDegrees / _timeManagerConfiguration.dayDuration);
        }
    }
}