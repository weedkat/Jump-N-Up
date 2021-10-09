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
    Dictionary<char, int> timeChange = new Dictionary<char, int>();

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
        timeChange.Add('a', 0);
        timeChange.Add('b', 0);
        timeChange.Add('c', 0);
        timeChange.Add('d', 0);
        timeChange.Add('e', 0);
        timeChange.Add('f', 0);
        timeChange.Add('g', 0);
        timeChange.Add('h', 0);
        timeChange.Add('i', 0);
        timeChange.Add('j', 0);
        timeChange.Add('k', 0);
        timeChange.Add('l', 0);
        timeChange.Add('m', 0);
        timeChange.Add('n', 0);
        timeChange.Add('o', 0);
        timeChange.Add('p', 0);
        timeChange.Add('q', 0);
        timeChange.Add('r', 0);
        timeChange.Add('s', 0);
        timeChange.Add('t', 0);
        timeChange.Add('u', 0);
        timeChange.Add('v', 0);
        timeChange.Add('w', 0);
        timeChange.Add('x', 0);
        timeChange.Add('y', 0);
        timeChange.Add('z', 0);
    }
    public void DisplayScore()
    {
        if (displayText != null)
        {
            string word = "";
            List<char> collected = KeyAlphabet.CollectedAlphabet;
            int i = 0;
            Dictionary<char, int> timeChangeLocal = timeChange;
            foreach (KeyValuePair<int, char> x in KeyAlphabet.AlphabetNeeded)
            {
                int index = collected.IndexOf(x.Value);
                int key = x.Key - 1;
                if(index >= 0)
                {
                    int dif = timeChange[x.Value] - timeChangeLocal[x.Value];
                    if (timeChangeLocal[x.Value] == 0)
                    {
                        message[key] = x.Value;
                        collected.RemoveAt(index);
                        timeChange[x.Value]++;
                    }
                    else
                    {
                        timeChangeLocal[x.Value]--;
                    }
                }
                word = word + message[i];
                i++;
            }
            displayText.text = word;
        }
    }

    public void canFinish()
    {
        foreach(char x in message)
        {
            if(x == '_')
            {
                KeyAlphabet.finish = false;
                return;
            }
        }
        KeyAlphabet.finish = true;
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

        canFinish();

        // The remaining code is only called for this sub-class of UIelement and not others
        DisplayScore();
    }
}
