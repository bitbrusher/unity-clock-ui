using System.Text;
using UnityEngine;

public class DigitalClockStringBuilder
{
    private readonly ITimeManager _timeManager;
    private readonly bool _is12HourClock;

    private readonly StringBuilder _clockStringBuilder;
    private readonly char[] _clockCharArray;

    private int _currentHour;
    private int _currentMinutes;
    private bool _isAfternoon;

    public DigitalClockStringBuilder(ITimeManager timeManager, bool is12HourClock)
    {
        _timeManager = timeManager;
        _is12HourClock = is12HourClock;

        var formattedDisplayText = _is12HourClock ? "00:00 AM" : "00:00";
        _clockStringBuilder = new StringBuilder(formattedDisplayText);
        _clockCharArray = new char[_clockStringBuilder.Length];
    }

    public DigitalClockStringBuilderResult GetDisplayText()
    {
        var changed = false;
        if (UpdateCurrentTimeAndCheckIfChanged())
        {
            UpdateClockTimeInStringBuilder(_clockStringBuilder);
            if (_is12HourClock)
            {
                _clockStringBuilder[6] = _isAfternoon ? 'P' : 'A';
            }

            _clockStringBuilder.CopyTo(0, _clockCharArray, 0, _clockStringBuilder.Length);
            changed = true;
        }

        return new DigitalClockStringBuilderResult()
        {
            FormattedClockInfo = _clockCharArray,
            HasChanged = changed
        };
    }

    private bool UpdateCurrentTimeAndCheckIfChanged()
    {
        var hour = _timeManager.GetHour();
        var integerHour = Mathf.FloorToInt(hour);
        var minutes = _timeManager.GetMinutes();
        var integerMinutes = Mathf.FloorToInt(minutes);

        var isAfternoon = integerHour >= 12;
        if (_is12HourClock && isAfternoon)
        {
            integerHour -= 12;
        }

        var changed = integerHour != _currentHour || integerMinutes != _currentMinutes;
        changed |= _is12HourClock && isAfternoon != _isAfternoon;

        _currentHour = integerHour;
        _currentMinutes = integerMinutes;
        _isAfternoon = isAfternoon;
        return changed;
    }

    private void UpdateClockTimeInStringBuilder(StringBuilder stringBuilder)
    {
        var decimalHour = _currentHour / 10;
        var unitHour = _currentHour % 10;
        var decimalMinutes = _currentMinutes / 10;
        var unitMinutes = _currentMinutes % 10;

        stringBuilder[0] = (char) ('0' + decimalHour);
        stringBuilder[1] = (char) ('0' + unitHour);
        stringBuilder[3] = (char) ('0' + decimalMinutes);
        stringBuilder[4] = (char) ('0' + unitMinutes);
    }
}
