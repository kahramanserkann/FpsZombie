using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shoot : MonoBehaviour
{
    public float coolDown = 0.05f;
    float lastFireTime = 0;
    public int defaultAmmo = 120;
    public int magSize = 30;
    public int currentAmmo;
    public int currentMagAmmo;
    public Camera camera;
    public int range;
    [Header("Gun Damage On Hit")]
    public int damage;
    public GameObject bloodPrefab;
    public GameObject decalPrefab;
    int minAngle = -5;
    int maxAngle = 5;
    public AmmoBar ammoBar;
    public MagBar magBar;
    // Start is called before the first frame update
    
    void Start()
    {

        currentAmmo = defaultAmmo - magSize;
        currentMagAmmo = magSize;
        ammoBar.SetMaxAmmo(magSize);
        magBar.SetMaxAmmo(defaultAmmo);
        

}

    // Update is called once per frame
    void Update()
    {
        //for pc ------
        if (Input.GetKeyDown(KeyCode.R))
        {
            Reload();

        }
        if (Input.GetMouseButton(0))
        {
            if (CanFire())
            {
                Fire();
            }
        }
        //------------- for pc end

        ammoBar.SetAmmo(currentMagAmmo);
    }

    public void Reload()
    {
        if (currentAmmo==0 || currentMagAmmo==magSize)
        {
            return;
        }
        if (currentAmmo<magSize)
        {
            currentMagAmmo = currentMagAmmo + currentAmmo;
            currentAmmo = 0;
            magBar.SetAmmo(currentAmmo);
        }
        else
        {
            currentAmmo -= magSize - currentMagAmmo;
            currentMagAmmo = magSize;
            magBar.SetAmmo(currentAmmo);
        }
        


    }

    public bool CanFire()
    {

        if (currentMagAmmo > 0 && lastFireTime +coolDown<Time.time)
        {
            lastFireTime = Time.time+coolDown;
            
            return true;
        }

        return false;
            
    }

    public void Fire() 
    {       
            currentMagAmmo -= 1;
            Debug.Log("Kalan mermim:" + currentMagAmmo);
            RaycastHit hit;
            if (Physics.Raycast(camera.transform.position, camera.transform.forward, out hit, 20))
            {
                if (hit.transform.tag == "Zombie")
                {
                    hit.transform.GetComponent<ZombieHealth>().Hit(damage);
                    GenerateBloodEffect(hit);
                }
                else
                {
                    GenerateHitEffect(hit);
                }
            }
            transform.localEulerAngles = new Vector3(UnityEngine.Random.Range(minAngle, maxAngle), UnityEngine.Random.Range(minAngle, maxAngle), UnityEngine.Random.Range(minAngle, maxAngle));
    }
    private void GenerateHitEffect(RaycastHit hit)
    {
        GameObject hitObject = Instantiate(decalPrefab, hit.point,Quaternion.identity);
        hitObject.transform.rotation = Quaternion.FromToRotation(decalPrefab.transform.forward *-1 , hit.normal);


    }

    private void GenerateBloodEffect(RaycastHit hit)
    {
        GameObject bloodObject = Instantiate(bloodPrefab, hit.point, hit.transform.rotation);
    }
}
