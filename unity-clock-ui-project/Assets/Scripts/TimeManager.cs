public class TimeManager : ITimeManager
{
    private const int HoursInDay = 24;
    private const int MinutesInHour = 60;

    private float _totalTime = 0;
    private float _currentTime = 0;

    private readonly TimeManagerConfiguration _timeManagerConfiguration;
    private readonly DigitalClockStringBuilder _12HourDigitalClockStringBuilder;
    private readonly DigitalClockStringBuilder _24HourDigitalClockStringBuilder;

    public TimeManager(TimeManagerConfiguration timeManagerConfiguration)
    {
        _timeManagerConfiguration = timeManagerConfiguration;

        _12HourDigitalClockStringBuilder = new DigitalClockStringBuilder(this, true);
        _24HourDigitalClockStringBuilder = new DigitalClockStringBuilder(this, false);
    }

    public TimeManagerConfiguration GetConfiguration()
    {
        return _timeManagerConfiguration;
    }
    
    public void Update(float deltaTime)
    {
        _totalTime += deltaTime;
        _currentTime = _totalTime % _timeManagerConfiguration.dayDuration;
    }

    public float GetHour()
    {
        return _currentTime * HoursInDay / _timeManagerConfiguration.dayDuration;
    }

    public float GetMinutes()
    {
        return (_currentTime * HoursInDay * MinutesInHour / _timeManagerConfiguration.dayDuration) % MinutesInHour;
    }

    public float GetSunsetHour()
    {
        return (_timeManagerConfiguration.sunriseHour + (1 - _timeManagerConfiguration.nightDuration) * HoursInDay) % HoursInDay;
    }

    public DigitalClockStringBuilderResult Get24HourDigitalClock()
    {
        return _24HourDigitalClockStringBuilder.GetDisplayText();
    }

    public DigitalClockStringBuilderResult Get12HourDigitalClock()
    {
        return _12HourDigitalClockStringBuilder.GetDisplayText();
    }
}
