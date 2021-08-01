using TMPro;

namespace Code.Game
{
    public interface IInUnitySceneReferences
    {
        TimeManagerConfiguration GetTimeManagerConfiguration();
        AnalogClockHands GetAnalogClockHands();
        TMP_Text GetDigitalClock24Text();
        TMP_Text GetDigitalClock12Text();
        DontStarveClockReferences GetDontStarveClockReferences();
        MinecraftClockReferences GetMinecraftClockReferences();
        StardewClockReferences GetStardewClockReferences();
    }
}