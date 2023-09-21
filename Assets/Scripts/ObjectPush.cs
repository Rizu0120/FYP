using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectPush : MonoBehaviour
{
    [SerializeField]
    private float forceMagnitude; //hardness of push force

    private void Start()
    {
    }

    private void Update()
    {
    }
    
    //when hit object with rigis body, push
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        var rigidBody = hit.collider.attachedRigidbody;

        //make the object move
        if (rigidBody != null)
        {
            var forceDirection = hit.gameObject.transform.position - transform.position;
            forceDirection.y = 0;
            forceDirection.Normalize(); //ensure object move evenly in any direction
            
            rigidBody.AddForceAtPosition(forceDirection * forceMagnitude, transform.position, ForceMode.Impulse);
        }
    }
}
