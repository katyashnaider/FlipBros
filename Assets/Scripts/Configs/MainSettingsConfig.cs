using UnityEngine;

namespace FlipBros.Configs
{
    [CreateAssetMenu(fileName = nameof(MainSettingsConfig), menuName = "Configs/" + nameof(MainSettingsConfig))]
    public class MainSettingsConfig : ScriptableObject
    {
        [SerializeField] private LevelsConfig _levelsConfig;
        [SerializeField] private CharactersConfig _charactersConfig;
        [SerializeField] private CharacterPlayerConfig _characterPlayerConfig;


        public LevelsConfig LevelsConfig => _levelsConfig;
        public CharactersConfig CharactersConfig => _charactersConfig;
        public CharacterPlayerConfig CharacterPlayerConfig => _characterPlayerConfig;
    }
}