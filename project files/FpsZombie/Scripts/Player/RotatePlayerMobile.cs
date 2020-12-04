using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotatePlayerMobile : MonoBehaviour
{
    public float sensitivityX = 5.0f;
    public float sensitivityY = 5.0f;

    public bool invertX = false;
    public bool invertY = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        foreach (Touch touch in Input.touches)
        {
            if (touch.position.x < Screen.width / 2)
            {
                //Movement();
            }
            else if (touch.position.x > Screen.width / 2)
            {
                if (Input.touches.Length > 0)
                {
                    if (Input.touches[0].phase == TouchPhase.Moved)
                    {
                        Vector2 delta = Input.touches[0].deltaPosition;
                        float rotationZ = delta.x * sensitivityX * Time.deltaTime;
                        rotationZ = invertX ? rotationZ : rotationZ * -1;
                        float rotationX = delta.y * sensitivityY * Time.deltaTime;
                        rotationX = invertY ? rotationX : rotationX * -1;
                        transform.localEulerAngles += new Vector3(rotationX, rotationZ, 0);
                    }
                }
            }
        }

    }
}
