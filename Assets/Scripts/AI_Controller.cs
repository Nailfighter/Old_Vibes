using UnityEngine;

public class AI_Controller : Paddle_Behaviour
{
    [SerializeField] Rigidbody2D Ball_RB;
    [SerializeField] float Offset = 0.5f;
    public void FixedUpdate()
    {
        if (Ball_RB.velocity.x < 0)
        {
            Move_Direction(Vector2.up * -transform.position.y);
            return;
        }

        if(Ball_RB.position.y - transform.position.y > Offset)
        {
            Move_Direction(Vector2.up * Mov_Speed);
        }
        else if (transform.position.y - Ball_RB.position.y > Offset)
        {
            Move_Direction(Vector2.down * Mov_Speed);
        }
    }
}
