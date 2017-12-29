using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadBOx : MonoBehaviour {

    
    public int currentHealth = 3;

    public void Damage(int damageAmount)
    {
        currentHealth -= damageAmount;
        Debug.Log("Shot the box!!!!");
        if (currentHealth <= 0)
        {
           gameObject.SetActive(false);
        }
    }
}
