using FlipBros.Configs;
using FlipBros.Gameplay.Inputs;
using FlipBros.Player;
using UnityEngine;

namespace FlipBros.Gameplay
{
    public class Game
    {
        private readonly LevelsConfig _levelsConfig;
        private readonly CharactersConfig _charactersConfig;
        private readonly DesktopAndMobileInput _input;

        private Level _level;
        private CharacterPlayerConfig _characterPlayerConfig;

        public Game(LevelsConfig levelsConfig, CharactersConfig charactersConfig,
            CharacterPlayerConfig characterPlayerConfig)
        {
            _characterPlayerConfig = characterPlayerConfig;
            _levelsConfig = levelsConfig;
            _charactersConfig = charactersConfig;
            _input = new DesktopAndMobileInput();
        }

        public void ThisUpdate()
        {
            _input.ThisUpdate();
        }

        public void StartGame()
        {
            Level levelPrefab = _levelsConfig.DebugLevelPrefab;
            _level = Object.Instantiate(levelPrefab);

            Vector3 spawnPosition = _level.CharacterSpawnPoint;


            PlayerCharacter playerCharacter = Object.Instantiate(_charactersConfig.PlayerCharacterPrefab, spawnPosition,
                Quaternion.identity, _level.transform);

            playerCharacter.Construct(_input, _characterPlayerConfig);
        }

        public void DestroyGame()
        {
            _input.Dispose();
        }
    }
}