using UnityEngine;

namespace FlipBros.Configs
{
    [CreateAssetMenu(fileName = nameof(LevelsConfig), menuName = "Configs/" + nameof(LevelsConfig), order = 0)]
    public class LevelsConfig : ScriptableObject
    {
        [SerializeField] private Level _debugLevel;

        public Level DebugLevelPrefab => _debugLevel;
    }
}