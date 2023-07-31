using UnityEngine;

public class Chunk : MonoBehaviour
{
    [SerializeField] private Transform _nextChunkPos;
    [SerializeField] private Transform _robotSpawnPos;

    public Vector3 GetSpawnPos()
    {
        return _nextChunkPos.position;
    }

    public Transform GetRobotSpawnPos()
    {
        return _robotSpawnPos;
    }
}
