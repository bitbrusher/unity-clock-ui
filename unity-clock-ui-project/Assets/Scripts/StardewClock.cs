using UnityEngine;
using UnityEngine.UI;

public class StardewClock : MonoBehaviour
{
    private ITimeManager _timeManager;

    public Image nightBackground;
    public RectTransform hand;

    private const float HoursToDegrees = 180f / 24f;

    private void Start()
    {
        _timeManager = FindObjectOfType<TimeManagerMonoBehaviour>().GetTimeManager();
        nightBackground.fillAmount = _timeManager.GetConfiguration().nightDuration / 2;
    }

    private void Update()
    {
        hand.localRotation = Quaternion.Euler(0, 0,
            90 - HoursToDegrees * ((_timeManager.GetHour() + TimeManager.HoursInDay - _timeManager.GetConfiguration().sunriseHour) %
                                   TimeManager.HoursInDay));
    }
}