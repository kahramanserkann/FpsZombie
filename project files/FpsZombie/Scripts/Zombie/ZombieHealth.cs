using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ZombieHealth : MonoBehaviour
{
    public int startHealth = 100;
    public int currentHealt;
    public GameObject zombiePrefab;
    //public GameObject zombiePrefab;
    int zombieCounter = 3;
    //public GameObject zombiePrefab;
    //public int zombieCounter;
    int maxZ = 10;
    int maxX = 20;
    int minX = -20;
    int minZ = -30;

    // Start is called before the first frame update
    void Start()
    {
        
        currentHealt = startHealth;
        
    }
    public int GetHealth()
    {
        return currentHealt;
    }
    public void Hit(int damage)
    {
        currentHealt -= damage;
        if (currentHealt <= 0)
        {
            currentHealt = 0;
            GenerateZombie();
            Debug.Log("zombi öldü");    
        }
        Debug.Log("zombi hasar aldı" + currentHealt);
    }
    private void GenerateZombie()
    {
        for (int i = 0; i < zombieCounter; i++)
        {
            GameObject zombie = Instantiate(zombiePrefab, new Vector3(UnityEngine.Random.Range(maxX, minX), 0.22f, UnityEngine.Random.Range(maxZ, minZ)), Quaternion.identity);
        }
    }

}
