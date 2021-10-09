using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/// <summary>
/// This class handles displayig the score
/// </summary>
public class AlphabetDisplay : UIelement
{
    [Header("References")]
    [Tooltip("The text to use when displaying the score")]
    public Text displayText = null;
    List<char> message = new List<char>();

    /// <summary>
    /// Description:
    /// Displays the score onto the display text
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    /// 
    private void Start()
    {
        foreach(int x in KeyAlphabet.AlphabetNeeded.Keys)
        {
            message.Add('_');
        }
    }
    public void DisplayScore()
    {
        if (displayText != null)
        {
            string word = "";
            List<char> collected = KeyAlphabet.CollectedAlphabet;
            int i = 0;
            foreach (KeyValuePair<int, char> x in KeyAlphabet.AlphabetNeeded)
            {
                int index = collected.IndexOf(x.Value);
                if(index >= 0)
                {
                    message[x.Key-1] = x.Value;
                    collected.RemoveAt(index);
                }
                word = word + message[i];
                i++;
            }
            displayText.text = word;
        }
    }

    /// <summary>
    /// Description:
    /// Updates this UI based on this class
    /// Input:
    /// none
    /// Return:
    /// void (no return)
    /// </summary>
    public override void UpdateUI()
    {
        // This calls the base update UI function from the UIelement class
        base.UpdateUI();

        // The remaining code is only called for this sub-class of UIelement and not others
        DisplayScore();
    }
}
