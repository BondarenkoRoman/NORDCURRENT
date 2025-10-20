using UnityEngine;

namespace ScriptableObjects
{
    [CreateAssetMenu(fileName = nameof(GameConfig), menuName = "ScriptableObjects/GameConfig")]
    public class GameConfig : ScriptableObject
    {
        public float RespawnDelay = 1;
        public int EnemyCount = 4;
    }
}
