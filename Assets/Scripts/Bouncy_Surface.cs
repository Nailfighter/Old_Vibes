using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bouncy_Surface : MonoBehaviour
{
    private void OnCollisionEnter(Collision collision)
    {
        Ball_Behaviour Sus_Ball = GetComponent<Ball_Behaviour>();
        Vector3 Normal = collision.GetContact(0).normal;
        print("Hit");
        if (Sus_Ball != null)
        {
            print("Ball");
            Vector2 Deviated_Dir = new Vector3(Normal.x, Random.Range(-0.5f, 0.5f));
            Sus_Ball.GetComponent<Rigidbody2D>().AddForce(Deviated_Dir);
        }
    }
}
