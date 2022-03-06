using System;
using UnityEngine;

[RequireComponent(typeof(Collider))]
public class BlockTrigger : MonoBehaviour
{

    public Action<Rigidbody> OnTriggered;

    private void OnCollisionEnter(Collision collision)
    {
        Rigidbody rigidbodyComponent;

        if (collision.gameObject.TryGetComponent<Rigidbody>(out rigidbodyComponent))
        {
            //Remove weak collision
            //TODO maybe remove if to other place
            if (collision.impulse.magnitude > 1)
            {
                OnTriggered?.Invoke(rigidbodyComponent);
            }
            
        }
    }
}
