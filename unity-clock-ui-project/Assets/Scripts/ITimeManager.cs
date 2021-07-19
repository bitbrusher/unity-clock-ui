public interface ITimeManager
{
    float GetHour();
    float GetMinutes();

    DigitalClockStringBuilderResult Get24HourDigitalClock();
    DigitalClockStringBuilderResult Get12HourDigitalClock();
}
