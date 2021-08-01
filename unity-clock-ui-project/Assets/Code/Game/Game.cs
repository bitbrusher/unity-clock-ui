namespace Code.Game
{
    public class Game : IGame
    {
        private readonly ITimeManager _timeManager;
        private readonly IClock _analogClock;
        private readonly IClock _digitalClock24;
        private readonly IClock _digitalClock12;
        private readonly IClock _dontStarveClock;
        private readonly IClock _minecraftClock;
        private readonly IClock _stardewClock;

        public Game(IInUnitySceneReferences unitySceneReferences)
        {
            _timeManager = new TimeManager(unitySceneReferences.GetTimeManagerConfiguration());
            _analogClock = new AnalogClock(_timeManager, unitySceneReferences.GetAnalogClockHands());
            _digitalClock24 = new DigitalClock(_timeManager, unitySceneReferences.GetDigitalClock24Text(), false);
            _digitalClock12 = new DigitalClock(_timeManager, unitySceneReferences.GetDigitalClock12Text(), true);
            _dontStarveClock = new DontStarveClock(_timeManager, unitySceneReferences.GetDontStarveClockReferences());
            _minecraftClock = new MinecraftClock(_timeManager, unitySceneReferences.GetMinecraftClockReferences());
            _stardewClock = new StardewClock(_timeManager, unitySceneReferences.GetStardewClockReferences());
        }

        public void Update(float deltaTimeInSeconds)
        {
            _timeManager.Update(deltaTimeInSeconds);
            _analogClock.Update();
            _digitalClock24.Update();
            _digitalClock12.Update();
            _dontStarveClock.Update();
            _minecraftClock.Update();
            _stardewClock.Update();
        }
    }
}