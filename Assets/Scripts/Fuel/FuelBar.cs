using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FuelBar : UIelement
{

	public Slider slider;
	public Gradient gradient;
	public Image fill;

    private void Start()
    {
        if (GameManager.instance != null && GameManager.instance.player != null)
        {
            Fuel playerFuel = GameManager.instance.player.GetComponent<Fuel>();
            slider.maxValue = playerFuel.maximumFuel;
            slider.value = (int)playerFuel.currentFuel;
            fill.color = gradient.Evaluate(1f);
        }
    }
    /// <summary>
    /// Description:
    /// Upadates this UI element
    /// Input: 
    /// none
    /// Return: 
    /// void (no return)
    /// </summary>
    public override void UpdateUI()
    {
        if (GameManager.instance != null && GameManager.instance.player != null)
        {
            Fuel playerFuel = GameManager.instance.player.GetComponent<Fuel>();
            slider.value = (int)playerFuel.currentFuel;
            fill.color = gradient.Evaluate(slider.normalizedValue);
        }
    }
}
