using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class SafeZone : MonoBehaviour
{
    //
    //[SerializeField] private 

    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out SafeZoneTrigger safeZoneTrigger))
        {

        }
    }

    private void OnTriggerStay(Collider other)
    {
        
    }
}
