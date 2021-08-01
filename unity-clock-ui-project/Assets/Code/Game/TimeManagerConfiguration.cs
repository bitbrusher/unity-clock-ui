using UnityEngine;

[CreateAssetMenu(menuName = "TimeManager Configuration")]
public class TimeManagerConfiguration : ScriptableObject
{
    public float dayDuration = 30f;
    public float nightDuration = .4f;
    public float sunriseHour = 6;
}