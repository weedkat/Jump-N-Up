using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStation : MonoBehaviour
{
    private bool fuelling = true;
    public float addSpeed = 1.0f;
    public Animator gasAnimator = null;
    private Fuel fuel = null;
    public static GameManager instance = null;

    private void Awake()
    {
        if (instance == null)
        {
            instance = FindObjectOfType<GameManager>();
        }
        fuel = FindObjectOfType<Fuel>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(fuel != null)
        {
            gasAnimator.SetBool("isActive", true);
        }
        else
        {
            fuel = collision.gameObject.GetComponent<Fuel>();
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        if (fuel.currentFuel < fuel.maximumFuel)
        {
            fuelling = true;
        }
        if (collision.tag == "Player"  && fuelling && fuel != null)
        {
            gasAnimator.SetBool("isActive", true);
            fuel.addFuel(addSpeed);
            UpdateUIElements();
        }
        else
        {
            fuelling = false;
        }
        if(!fuelling)
        {
            gasAnimator.SetBool("isActive", false);
        }
    }
    
    private IEnumerator increase()
    {
        yield return new WaitForSeconds(1);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        Fuel fuel = collision.GetComponent<Fuel>();
        if(fuel != null)
        {
            gasAnimator.SetBool("isActive", false);
        }
    }
    public static void UpdateUIElements()
    {
        if (instance != null && instance.uiManager != null)
        {
            instance.uiManager.UpdateUI();
        }
    }
}
