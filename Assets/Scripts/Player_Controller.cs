using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player_Controller : Paddle_Behaviour
{
    private InputMap Input_Map;
    private InputAction Movement;
    private InputAction Reset;
    private float Axis_Value = 0;
    private Game_Manager Main_GM;
    private bool Mov_Allowed = true;
    private void Awake()
    {
        Main_GM = FindObjectOfType<Game_Manager>();
        Input_Map = new InputMap();
        Movement = Input_Map.Player.Movement;
        Movement.Enable();

        Reset = Input_Map.Player.ResetScene;
        Reset.Enable();

        Reset.performed += ctx => Main_GM.Reset_Scene();
        
    }
    private void FixedUpdate()
    {
        if (!Mov_Allowed) { return; }

        if (Input.touchCount > 0)
        {
            Check_Touch();
            return;
        }

        Axis_Value = Movement.ReadValue<float>();
        Mov_Inputs();

    }

    private void Check_Touch()
    {
        Vector2 World_Pos = Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position);
        Vector2 Touch_Pos = new Vector2(World_Pos.x, Mathf.Clamp(World_Pos.y, -6.5f, 6.5f));
        Move_Direction(Vector2.up * (Touch_Pos.y - transform.position.y) * Mov_Speed / 2);
    }

    public void Mov_Inputs()
    {
        if (Axis_Value > 0f)
        {
            Move_Direction(Vector2.up * Mov_Speed);
        }
        else if (Axis_Value < 0f)
        {
            Move_Direction(Vector2.down * Mov_Speed);
        }
    }

    public void Disable_Movement()
    {
        Mov_Allowed = false;
    }
    
}
