namespace Code.Game
{
    public interface ITimeManager
    {
        TimeManagerConfiguration GetConfiguration();

        void Update(float deltaTime);

        float GetHour();
        float GetMinutes();
        float GetSunsetHour();

        DigitalClockStringBuilderResult Get24HourDigitalClock();
        DigitalClockStringBuilderResult Get12HourDigitalClock();

    }
}
