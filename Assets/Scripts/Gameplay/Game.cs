using FlipBros.Configs;
using FlipBros.Player;
using UnityEngine;

namespace FlipBros.Gameplay
{
    public class Game
    {
        private readonly LevelsConfig _levelsConfig;
        private readonly CharactersConfig _charactersConfig;
        
        private Level _level;

        public Game(LevelsConfig levelsConfig, CharactersConfig charactersConfig)
        {
            _levelsConfig = levelsConfig;
            _charactersConfig = charactersConfig;
        }
        
        public void StartGame()
        {
            Level levelPrefab = _levelsConfig.DebugLevelPrefab;
            _level = Object.Instantiate(levelPrefab);

            Vector3 spawnPosition = _level.CharacterSpawnPoint;

            PlayerCharacter playerCharacter = Object.Instantiate(_charactersConfig.PlayerCharacterPrefab, spawnPosition,
                Quaternion.identity, _level.transform);
        }
    }
}