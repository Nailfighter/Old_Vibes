using UnityEngine;

public class Ball_Behaviour : MonoBehaviour
{
    [SerializeField] int Start_Force = 200;
    [System.Serializable]
    public struct Color_Lists
    {
        public Color Primary_Color;
        public Gradient Primary_Gradient;
    }
    public Color_Lists Player_Colors; 
    public Color_Lists AI_Colors;
    public Color_Lists No_Touch;
    [SerializeField] TrailRenderer Trail;
    private Rigidbody2D Ball_RB;
    private Vector2 Random_Dir = Vector2.zero;
    private SpriteRenderer Renderer;
    private void Awake()
    {
        Ball_RB = GetComponent<Rigidbody2D>();
        Renderer = GetComponent<SpriteRenderer>();
    }

    private void Start()
    {
        Apply_Start_Force();
    }

    public void Reset_Ball_To_Center()
    {
        Renderer.color = No_Touch.Primary_Color;
        Trail.colorGradient = No_Touch.Primary_Gradient;
        Set_Position_Center();
        Apply_Start_Force();
    }
    private void Apply_Start_Force()
    {
        int X = Random.Range(0f, 1f) > 0.5 ? -1 : 1;
        float Y = Random.Range(0f, 1f) > 0.5 ? Random.Range(0f, 0.5f) : Random.Range(-0.5f, 0);
        Random_Dir = new Vector2(X,Y);
        Ball_RB.AddForce(Random_Dir * Start_Force);
    }

    private void Set_Position_Center()
    {
        Trail.emitting = false;
        transform.position = Vector2.zero;
        Ball_RB.velocity = Vector2.zero;
        Trail.emitting = true;
    }

    public void OnCollisionEnter2D(Collision2D collision)
    {

        string Name = collision.gameObject.name;
        if (Name.Equals("Player Paddle"))
        {
            Renderer.color = Player_Colors.Primary_Color;
            Trail.colorGradient = Player_Colors.Primary_Gradient;
        }
        else if(Name.Equals("AI Paddle"))
        {
            Renderer.color = AI_Colors.Primary_Color;
            Trail.colorGradient = AI_Colors.Primary_Gradient;
        }
        else
        {
            Renderer.color = No_Touch.Primary_Color;
            Trail.colorGradient = No_Touch.Primary_Gradient;
        }
    }

    public void Set_Ball(bool State)
    {
        gameObject.SetActive(State);
    }
}
