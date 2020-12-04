using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class MagBar : MonoBehaviour
{
    public Slider slider;
    // Start is called before the first frame update
    public void SetMaxAmmo(int ammo)
    {
        slider.maxValue = ammo;
        slider.value = ammo;
    }
    public void SetAmmo(int ammo)
    {
        slider.value = ammo;
    }
}
