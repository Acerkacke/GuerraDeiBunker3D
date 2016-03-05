using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.EventSystems;


public class MovementController : MonoBehaviour
{
    public float fastSpeedMultiplier = 2;
    public float keyScrollSpeed = 2;

    void Start()
    {
        
    }

    void Update()
    {
        UpdateKeyboardScroll();
    }

    private void UpdateKeyboardScroll()
    {
        float translationX = Input.GetAxis("Horizontal");
        float translationY = Input.GetAxis("Vertical");

        if (Input.GetKey(KeyCode.LeftShift))
            Camera.main.transform.Translate(translationX * fastSpeedMultiplier * keyScrollSpeed,0, translationY * fastSpeedMultiplier * keyScrollSpeed,Space.World);
        else
            Camera.main.transform.Translate(translationX * keyScrollSpeed,0, translationY * keyScrollSpeed, Space.World);
    }

}