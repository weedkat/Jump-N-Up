using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class for pickups which end the level
/// </summary>
public class GoalPickup : Pickup
{
    [SerializeField] private string sentence = null;
    /// <summary>
    /// Description:
    /// Function called when this pickup is picked up
    /// Tells the game manager that the level was cleared
    /// Input: 
    /// Collider2D collision
    /// Return: 
    /// void (no return)
    /// </summary>
    /// <param name="collision">The collider that is picking up this pickup</param>

    private void Start()
    {
        KeyAlphabet.AddSentence(sentence);
    }

    public override void DoOnPickup(Collider2D collision)
    {
        if (collision.tag == "Player" && collision.gameObject.GetComponent<Health>() != null)
        {
            if (KeyAlphabet.CanFinish() && GameManager.instance != null)
            {
                GameManager.instance.LevelCleared();
                KeyAlphabet.ClearKeyAlphabet();
                base.DoOnPickup(collision);
            }
        }
    }
}
