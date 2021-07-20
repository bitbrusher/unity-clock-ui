public interface ITimeManager
{
    void Update(float deltaTime);

    float GetHour();
    float GetMinutes();

    DigitalClockStringBuilderResult Get24HourDigitalClock();
    DigitalClockStringBuilderResult Get12HourDigitalClock();
}
