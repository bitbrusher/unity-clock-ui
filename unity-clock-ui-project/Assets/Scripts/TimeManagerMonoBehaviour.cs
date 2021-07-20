using UnityEngine;

public class TimeManagerMonoBehaviour : MonoBehaviour
{
    [SerializeField] private TimeManagerConfiguration timeManagerConfiguration;

    private ITimeManager _timeManager;

    public ITimeManager GetTimeManager()
    {
        return _timeManager;
    }
    
    private void Awake()
    {
        _timeManager = new TimeManager(timeManagerConfiguration);
    }

    private void Update()
    {
        _timeManager.Update(Time.deltaTime);
    }
}