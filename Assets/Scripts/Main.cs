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
        }

        private void Start()
        {
            _game = new Game(_mainSettingsConfig.LevelsConfig,
                _mainSettingsConfig.CharactersConfig,
                _mainSettingsConfig.CharacterPlayerConfig);

            StartGame();
        }

        private void Update()
        {
            _game.ThisUpdate();
        }

        public void StartGame()
        {
            _game.StartGame();
        }
    }
}