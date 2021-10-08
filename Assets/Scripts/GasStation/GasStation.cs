using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasStation : MonoBehaviour
{
    private bool fuelling = true;
    public Animator gasAnimator = null;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        Fuel fuel = collision.GetComponent<Fuel>();
        if(fuel != null)
        {
            gasAnimator.SetBool("isActive", true);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {   
        Fuel fuel = collision.GetComponent<Fuel>();
        
        if (fuel.currentFuel < fuel.maximumFuel)
        {
            fuelling = true;
        }
        if (collision.tag == "Player"  && fuelling && fuel != null)
        {
            Debug.Log("masuk collide");
            gasAnimator.SetBool("isActive", true);
            if (fuel.currentFuel < fuel.maximumFuel)
                {
                    // StartCoroutine(increase(fuel.currentFuel));
                    // GameManager.UpdateUIElements();
                    fuel.currentFuel += 0.1f;
                }
            else
                {
                fuelling = false;
                }
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
}
