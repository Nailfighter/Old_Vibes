using UnityEngine;

public class Paddle_Behaviour : MonoBehaviour
{
    public int Mov_Speed = 10;
    [SerializeField] [Range(1.01f,1.1f)] float Paddle_Push = 1.01f;
    private Rigidbody2D Paddle_RB;

    private void Awake()
    {
        Paddle_RB = GetComponent<Rigidbody2D>();
    }

    public void Move_Direction(Vector3 Dir)
    {
        transform.position += (Dir * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball_Behaviour Sus_Ball = collision.gameObject.GetComponent<Ball_Behaviour>();
        Vector3 Normal = collision.GetContact(0).normal;
        if (Sus_Ball != null)
        {
            Vector2 Deviated_Dir = new Vector3(-Normal.x, Random.Range(-0.5f, 0.5f));
            float Mag = Sus_Ball.GetComponent<Rigidbody2D>().velocity.magnitude;
            Sus_Ball.GetComponent<Rigidbody2D>().velocity = Deviated_Dir.normalized * Mag * Paddle_Push  ;
        }
    }
    

}
