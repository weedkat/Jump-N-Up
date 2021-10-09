using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public static class KeyAlphabet
{
    // The IDs of the keys held by the player
    public static List<char> CollectedAlphabet = new List<char>() {};
    public static Dictionary<int, char> AlphabetNeeded = new Dictionary<int, char>(){};
    public static bool finish = false;

    /// <summary>
    /// Description:
    /// Adds a key to the player's key ring
    /// Input: 
    /// int keyID
    /// Return: 
    /// void (no return)
    /// </summary>
    /// <param name="keyID">The key id to add</param>
    public static void AddAlphabet(char Collected)
    {
        CollectedAlphabet.Add(Collected);
    }

    /// <summary>
    /// Description:
    /// Adds a key to the player's key ring
    /// Input: 
    /// int keyID
    /// Return: 
    /// void (no return)
    /// </summary>
    /// <param name="keyID">The key id to add</param>
    public static void AddSentence(string sentence)
    {
        int loop = 0;
        foreach (char c in sentence)
        {
            loop++;
            AlphabetNeeded.Add(loop, c);
        }
    }

    /// <summary>
    /// Description:
    /// Tests whether the player has the key they need to open a door
    /// Input: 
    /// Door door
    /// Return: 
    /// bool
    /// </summary>
    /// <param name="door">The door being opened</param>
    /// <returns>bool: Whether or not the plyer has the door's key</returns>
    public static bool CanFinish()
    {
        if(CollectedAlphabet.Count() == AlphabetNeeded.Count())
        {
            List<char> collected = CollectedAlphabet;
            foreach(KeyValuePair<int, char> x in AlphabetNeeded)
            {
                int index = collected.IndexOf(x.Value);
                if (index >= 0)
                {
                    collected.RemoveAt(index);
                }
                else
                {
                    return false;
                }
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Description:
    /// Removes all keys from the keyring
    /// Input:
    /// none
    /// Return:
    /// void
    /// </summary>
    public static void ClearKeyAlphabet()
    {
        CollectedAlphabet.Clear();
    }
}