using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Fuel : MonoBehaviour
{
    [Header("Fuel Settings")]
    [Tooltip("The default fuel value")]
    public int defaultFuel = 50;
    [Tooltip("The maximum fuel value")]
    public int maximumFuel = 100;
    [Tooltip("The current in game fuel value")]
    public float currentFuel = 50;
    // Whether or not the health is invincible
    public bool isUnlimited = false;

    public float time = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void consumeFuel(float fuelNeeded)
    {
            if (isUnlimited)
            {
                return;
            }
            else
            {
                if (currentFuel >= fuelNeeded)
                {
                    currentFuel -= fuelNeeded * 0.1f;
                }
                GameManager.UpdateUIElements();
            }
    }

}
