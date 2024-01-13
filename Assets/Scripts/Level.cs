using UnityEngine;

namespace FlipBros
{
    public class Level : MonoBehaviour
    {
        [SerializeField] private Transform _characterSpawnPoint;

        public Vector3 CharacterSpawnPoint => _characterSpawnPoint.position;
    }
}