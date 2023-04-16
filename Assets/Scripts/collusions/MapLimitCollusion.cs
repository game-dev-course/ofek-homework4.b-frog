using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLimitCollusion : MonoBehaviour
{
    [Tooltip("Every object tagged with this tag will trigger the destruction of this object")]
    [SerializeField] string triggeringTag;

    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag(triggeringTag) && enabled)
        {
            // Stops player by setting his velocity to 0
            InputMover inputMover = this.gameObject.GetComponent<InputMover>();
            // inputMover.SetSpeed(0f);
        }
    }


}
