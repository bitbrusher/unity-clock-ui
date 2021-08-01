using TMPro;

namespace Code.Game
{
    public class DigitalClock : IClock
    {
        private readonly ITimeManager _timeManager;
        private readonly TMP_Text _displayText;
        private readonly bool _is12HourClock;

        public DigitalClock(ITimeManager timeManager, TMP_Text displayText, bool is12HourClock)
        {
            _timeManager = timeManager;
            _displayText = displayText;
            _is12HourClock = is12HourClock;
        }

        public void Update()
        {
            var clockFormattedResult = _is12HourClock ? _timeManager.Get12HourDigitalClock() : _timeManager.Get24HourDigitalClock();

            if (clockFormattedResult.HasChanged)
            {
                _displayText.SetCharArray(clockFormattedResult.FormattedClockInfo);
            }
        }
    }
}
