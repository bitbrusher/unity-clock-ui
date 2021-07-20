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

        _isAfternoon = integerHour >= 12;

        TryToAdjustHourFor12HourClock(ref integerHour);

        var changed = integerHour != _currentHour || integerMinutes != _currentMinutes;

        _currentHour = integerHour;
        _currentMinutes = integerMinutes;
        return changed;
    }

    private void TryToAdjustHourFor12HourClock(ref int integerHour)
    {
        if (!_is12HourClock)
        {
            return;
        }

        if (_isAfternoon)
        {
            integerHour -= 12;
        }

        if (integerHour == 0)
        {
            integerHour = 12;
        }
    }

    private void UpdateClockTimeInStringBuilder(StringBuilder stringBuilder)
    {
        var tenthsHour = _currentHour / 10;
        var onesHour = _currentHour % 10;
        var tenthsMinutes = _currentMinutes / 10;
        var onesMinutes = _currentMinutes % 10;

        stringBuilder[0] = (char) ('0' + tenthsHour);
        stringBuilder[1] = (char) ('0' + onesHour);
        stringBuilder[3] = (char) ('0' + tenthsMinutes);
        stringBuilder[4] = (char) ('0' + onesMinutes);
    }
}