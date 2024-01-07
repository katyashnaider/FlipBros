using FlipBros.Configs;
using FlipBros.Gameplay;
using UnityEngine;

namespace FlipBros
{
    public class Main : MonoBehaviour
    {
        [SerializeField] private MainSettingsConfig _mainSettingsConfig;
        
        private Game _game;

        private void Awake()
        {
            Level level = _mainSettingsConfig.LevelsConfig.DebugLevelPrefab;
        }

        private void Start()
        {
            _game = new Game(_mainSettingsConfig.LevelsConfig);
            
            StartGame();
        }

        public void StartGame()
        {
            _game.StartGame();
        }
    }
}