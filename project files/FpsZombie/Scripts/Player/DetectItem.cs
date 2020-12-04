using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectItem : MonoBehaviour
{
    int max = 20;
    int min = -20;
    public GameObject applePrefab;
    PlayerHealth playerHealth;

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("HealthItem"))
        {
            playerHealth.AddHealth(10);
            Debug.Log("10 can eklendi" + playerHealth.GetHealth());
            Destroy(other.gameObject);
            GenerateApple();
        }
        
    }
    // Start is called before the first frame update
    void Start()
    {
        playerHealth = GetComponent<PlayerHealth>();

    }
    private void GenerateApple()
    {
        GameObject apple = Instantiate(applePrefab, new Vector3(UnityEngine.Random.Range(max,min),0.22f,UnityEngine.Random.Range(max, min)),Quaternion.identity);
    }
    private void GenerateAmmo()
    {
        GameObject ammo = Instantiate(applePrefab, new Vector3(UnityEngine.Random.Range(max, min), 0.22f, UnityEngine.Random.Range(max, min)), Quaternion.identity);
    }
    // Update is called once per frame
    void Update()
    {

    }
}
