using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class PlayerHealth : MonoBehaviour
{
    //public Menu menu;
    public int maxHealth=100;
    private int currentHealth;
    public HealthBar healthBar;
    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
        healthBar.SetMaxHealth(maxHealth);
    }

    public int GetHealth()
    {
        return currentHealth;
    }
    public void DeductHealth(int damage)
    {
        currentHealth = currentHealth - damage;
        Debug.Log("playerın canı azaldı" + currentHealth);
        if (currentHealth<=0)
        {
            KillPlayer();
        }
        healthBar.SetHealth(currentHealth);
    }

    private void KillPlayer()
    {
        print("player öldü");
        SceneManager.LoadScene(2);
    }

    public void AddHealth(int value)
    {
        currentHealth = currentHealth + value;
        if(currentHealth>maxHealth)
        {
            currentHealth = maxHealth;
        }
        healthBar.SetHealth(currentHealth);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
