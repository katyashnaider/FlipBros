using FlipBros.Configs;
using UnityEngine;

namespace FlipBros.Gameplay
{
    public class Game
    {
        private readonly LevelsConfig _levelsConfig;
        
        private Level _level;

        public Game(LevelsConfig levelsConfig)
        {
            _levelsConfig = levelsConfig;
        }
        
        public void StartGame()
        {
            Level levelPrefab = _levelsConfig.DebugLevelPrefab;
            _level = Object.Instantiate(levelPrefab);
        }
    }
}