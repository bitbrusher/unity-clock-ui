using UnityEngine;

public class TimeManager : MonoBehaviour, ITimeManager
{
    private const int HoursInDay = 24;
    private const int MinutesInHour = 60;

    public float dayDuration = 30f;

    private float _totalTime = 0;
    private float _currentTime = 0;

    public float nightDuration = .4f;
    public float sunriseHour = 6;

    private DigitalClockStringBuilder _12HourDigitalClockStringBuilder;
    private DigitalClockStringBuilder _24HourDigitalClockStringBuilder;

    private void Start()
    {
        _12HourDigitalClockStringBuilder = new DigitalClockStringBuilder(this, true);
        _24HourDigitalClockStringBuilder = new DigitalClockStringBuilder(this, false);
    }

    private void Update()
    {
        _totalTime += Time.deltaTime;
        _currentTime = _totalTime % dayDuration;
    }

    public float GetHour()
    {
        return _currentTime * HoursInDay / dayDuration;
    }

    public float GetMinutes()
    {
        return (_currentTime * HoursInDay * MinutesInHour / dayDuration) % MinutesInHour;
    }

    public DigitalClockStringBuilderResult Get24HourDigitalClock()
    {
        return _24HourDigitalClockStringBuilder.GetDisplayText();
    }

    public DigitalClockStringBuilderResult Get12HourDigitalClock()
    {
        return _12HourDigitalClockStringBuilder.GetDisplayText();
    }

    public float GetSunsetHour()
    {
        return (sunriseHour + (1 - nightDuration) * HoursInDay) % HoursInDay;
    }
}
