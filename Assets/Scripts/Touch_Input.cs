using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Touch_Input : MonoBehaviour
{
    
    Vector3 Cur_Pos = Vector3.zero;
    private void Start()
    {
        Screen.SetResolution(1280, 720,false);
    }
    void Update()
    {
        if(Input.touchCount == 1)
        {
            Vector3 Touch_Pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
            Touch_Pos.z = 0;
            Cur_Pos = Vector3.MoveTowards(Cur_Pos, Touch_Pos, 0.1f);
            transform.position = Cur_Pos;
        }
        else
        {
            
        }
    }

    private void Draw_Line()
    {
        foreach(Touch touch in Input.touches)
        {
            Vector3 Touch_Pos = Camera.main.ScreenToWorldPoint(touch.position);
            Debug.DrawLine(Vector3.zero,Touch_Pos );
        }
    }
}
