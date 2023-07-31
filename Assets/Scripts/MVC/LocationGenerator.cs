using System.Collections.Generic;
using UnityEngine;

public class LocationGenerator : MonoBehaviour
{
    [SerializeField] private Chunk[] _chunks;
    private List<Chunk> _location = new List<Chunk>();

    public void GenerateMap()
    {
        Vector3 spawnPos = transform.position;
        for (int i = 0; i < 5; i++)
        {
            Chunk chunk = Instantiate(_chunks[Random.Range(0, _chunks.Length)],
                spawnPos,
                Quaternion.Euler(0, 0, 0));
            _location.Add(chunk);
            spawnPos = chunk.GetSpawnPos();
        }
    }

    public Transform GetRobotPos()
    {
        return _location[0].GetRobotSpawnPos();
    }
}
