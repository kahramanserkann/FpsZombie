using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.Events;
public class FireHolding : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    public Shoot shoot;
    private bool pointerDown;
    private float pointerDownTimer;
    public UnityEvent onLongClick;
    public void OnPointerDown(PointerEventData eventData)
    {
        pointerDown = true;
    }


    public void OnPointerUp(PointerEventData eventData)
    {
        pointerDown = false;
    }

    // Start is called before the first frame update
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        if (pointerDown)
        {
            if (shoot.CanFire())
            {
                shoot.Fire();
            }
        }
    }
}