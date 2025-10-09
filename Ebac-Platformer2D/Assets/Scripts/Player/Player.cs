using System.Numerics;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{

    public Rigidbody2D rig;
    public float speed;
    public float forceJump;
    public UnityEngine.Vector2 friction = new UnityEngine.Vector2(-0.1f, 0);

    void Update()
    {
        Jump();
        Move();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rig.linearVelocity = new UnityEngine.Vector2(-speed, rig.linearVelocity.y);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rig.linearVelocity = new UnityEngine.Vector2(+speed, rig.linearVelocity.y);
        }

        if (rig.linearVelocity.x > 0)
        {
            rig.linearVelocity += friction;
        }
        else if(rig.linearVelocity.x < 0)
        {
            rig.linearVelocity -= friction;
        }

    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.linearVelocity = UnityEngine.Vector2.up * forceJump;  
        }   

    }
}
