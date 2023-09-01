using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectible : MonoBehaviour
{
    public DoubleJumpAbility doubleJumpAbility;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Debug.Log("Player collided with collectible.");
        
            if (doubleJumpAbility != null)
            {
                Debug.Log("DoubleJumpAbility reference is valid.");
            
                doubleJumpAbility.hasDoubleJump = true;
                Debug.Log("Double jump ability granted.");
            
                Destroy(gameObject);
            }
            else
            {
                Debug.LogWarning("DoubleJumpAbility reference is null.");
            }
        }
    }

}



