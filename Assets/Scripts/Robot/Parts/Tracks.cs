using UnityEngine;

public class Tracks : MonoBehaviour
{
    public virtual void LayDownTracks(Vector3 pos)
    {
        transform.position = pos;
    }
}
