using UnityEngine;

namespace FlipBros.Configs
{
    [CreateAssetMenu(fileName = nameof(MainSettingsConfig), menuName = "Configs/" + nameof(MainSettingsConfig),
        order = 0)]
    public class MainSettingsConfig : ScriptableObject
    {
        [SerializeField] private LevelsConfig _levelsConfig;

        public LevelsConfig LevelsConfig => _levelsConfig;
    }
}