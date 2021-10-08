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
    public int currentFuel = 50;
    // Whether or not the health is invincible
    public bool isUnlimited = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public bool isCanFly(int fuelAmount)
    {
        if (isUnlimited)
        {
            return true;
        }
        else
        {
            if (currentFuel >= fuelAmount)
            {
                currentFuel -= fuelAmount;
                return true;
            }
            else
            {
                return false;
            }
            GameManager.UpdateUIElements();
        }
        
    }
}
