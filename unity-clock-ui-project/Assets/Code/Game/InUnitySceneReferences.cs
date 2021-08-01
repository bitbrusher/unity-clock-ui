using System;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Code.Game
{
    public class InUnitySceneReferences : MonoBehaviour, IInUnitySceneReferences
    {
        [SerializeField] private TimeManagerConfiguration timeManagerConfiguration;
        [SerializeField] private AnalogClockHands analogClockHands;
        [SerializeField] private TMP_Text digitalClock24Text;
        [SerializeField] private TMP_Text digitalClock12Text;
        [SerializeField] private DontStarveClockReferences dontStarveClockReferences;
        [SerializeField] private MinecraftClockReferences minecraftClockReferences;
        [SerializeField] private StardewClockReferences stardewClockReferences;

        public TimeManagerConfiguration GetTimeManagerConfiguration()
        {
            return timeManagerConfiguration;
        }

        public AnalogClockHands GetAnalogClockHands()
        {
            return analogClockHands;
        }

        public TMP_Text GetDigitalClock24Text()
        {
            return digitalClock24Text;
        }

        public TMP_Text GetDigitalClock12Text()
        {
            return digitalClock12Text;
        }

        public DontStarveClockReferences GetDontStarveClockReferences()
        {
            return dontStarveClockReferences;
        }

        public MinecraftClockReferences GetMinecraftClockReferences()
        {
            return minecraftClockReferences;
        }

        public StardewClockReferences GetStardewClockReferences()
        {
            return stardewClockReferences;
        }
    }
    
    [Serializable]
    public class AnalogClockHands
    {
        public RectTransform minuteHand;
        public RectTransform hourHand;
    }

    [Serializable]
    public class DontStarveClockReferences
    {
        public RectTransform hand;
        public Image nightBackground;
    }

    [Serializable]
    public class MinecraftClockReferences
    {
        public RectTransform skyDome;
    }

    [Serializable]
    public class StardewClockReferences
    {
        public Image nightBackground;
        public RectTransform hand;
    }
}