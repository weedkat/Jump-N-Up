using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlphabetPickup : Pickup
{
    [Header("Alphabet Settings")]
    [Tooltip("What is the value of the item")]
    public char Alphabet;

    /// <summary>
    /// Description:
    /// When picked up, adds the key id to the key ring
    /// Input: 
    /// Collider2D collision
    /// Return: 
    /// void (no return)
    /// </summary>
    /// <param name="collision">The collider that picked up this key</param>
    public override void DoOnPickup(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Health>() != null)
        {
            KeyAlphabet.AddAlphabet(Alphabet);
        }
        base.DoOnPickup(collision);
    }
}
