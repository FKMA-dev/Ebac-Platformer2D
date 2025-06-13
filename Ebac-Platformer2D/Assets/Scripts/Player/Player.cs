using System.Numerics;
using UnityEngine;

public class Player : MonoBehaviour
{

    public Rigidbody2D rig;
    public float speed;

    void Update()
    {
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

    }
}
