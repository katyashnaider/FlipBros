using UnityEngine;

namespace FlipBros.Configs
{
    [CreateAssetMenu(fileName = nameof(CharacterPlayerConfig), menuName = "Configs/" + nameof(CharacterPlayerConfig))]
    public class CharacterPlayerConfig : ScriptableObject
    {
        [SerializeField] private float _durationToMaxPower;

        public float DurationToMaxPower => _durationToMaxPower;
    }
}