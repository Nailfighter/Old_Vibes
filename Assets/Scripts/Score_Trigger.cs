using UnityEngine;
using UnityEngine.Events;

public class Score_Trigger : MonoBehaviour
{
    public UnityEvent On_Score_Event;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        Ball_Behaviour Sus_Ball = collision.gameObject.GetComponent<Ball_Behaviour>();
        if (Sus_Ball != null)
        {
            On_Score_Event.Invoke();
        }
    }
}
