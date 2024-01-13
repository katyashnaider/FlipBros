using UnityEngine;

namespace FlipBros.Configs
{
    [CreateAssetMenu(fileName = nameof(MainSettingsConfig), menuName = "Configs/" + nameof(MainSettingsConfig),
        order = 0)]
    public class MainSettingsConfig : ScriptableObject
    {
        [SerializeField] private LevelsConfig _levelsConfig;
        [SerializeField] private CharactersConfig _charactersConfig;
        
        public LevelsConfig LevelsConfig => _levelsConfig;
        public CharactersConfig CharactersConfig => _charactersConfig;
    }
}