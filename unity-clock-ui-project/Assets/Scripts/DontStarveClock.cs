using UnityEngine;
using UnityEngine.UI;

public class DontStarveClock : MonoBehaviour
{
    public RectTransform hand;
    public Image nightBackground;

    private const float HoursToDegrees = 360f / 24f;

    private float _startRotation;

    private ITimeManager _timeManager;

    private void Start()
    {
        _timeManager = FindObjectOfType<TimeManagerMonoBehaviour>().GetTimeManager();
        nightBackground.fillAmount = _timeManager.GetConfiguration().nightDuration;
        _startRotation = _timeManager.GetConfiguration().sunriseHour * HoursToDegrees;
    }

    private void Update()
    {
        hand.rotation = Quaternion.Euler(0, 0, _startRotation - _timeManager.GetHour() * HoursToDegrees);
    }
}