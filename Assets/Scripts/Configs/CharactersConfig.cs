using FlipBros.Player;
using UnityEngine;

namespace FlipBros.Configs
{
    [CreateAssetMenu(fileName = nameof(CharactersConfig), menuName = "Configs/" + nameof(CharactersConfig), order = 0)]
    public class CharactersConfig : ScriptableObject
    {
        [SerializeField] private PlayerCharacter _playerCharacterPrefab;

        public PlayerCharacter PlayerCharacterPrefab => _playerCharacterPrefab;
    }
}