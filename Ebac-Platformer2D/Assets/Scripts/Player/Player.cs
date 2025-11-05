using UnityEngine;
using UnityEngine.Rendering;
using DG.Tweening;

public class Player : MonoBehaviour
{
    [Header("Movement Speed Setup")]

    public Vector2 friction = new Vector2(-0.1f, 0);
    public float speed;
    public float speedRun;
    private float _currentSpeed;

    [Header("Animation Setup")]

    public float jumpScaleY = 1.5f;
    public float jumpScaleX = 0.7f;
    public float landScaleX = 1.5f;
    public float landScaleY = 0.7f;
    public bool _isGround = false;
    public float animationDuration = .3f;
    public Ease ease = Ease.OutBack;

    [Header("Animation ANM")]

    public Animator animator;
    public string runBool = "RunBool";
    public string jumpTrigger = "JumpTrigger";
    public string jumpDownBool = "JumpDownBool";
    public bool _isFlying = false;


    public float forceJump;
    public Rigidbody2D rig;

    void Update()
    {
        Jump();
        Move();
    }

    public void Move()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            _currentSpeed = speedRun;
        }
        else
        {
            _currentSpeed = speed;
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            rig.linearVelocity = new Vector2(-_currentSpeed, rig.linearVelocity.y);
            rig.transform.localScale = new Vector3(-1, 1, 1);
            animator.SetBool(runBool, true);
        }
        else if (Input.GetKey(KeyCode.RightArrow))
        {
            rig.linearVelocity = new Vector2(+_currentSpeed, rig.linearVelocity.y);
            rig.transform.localScale = new Vector3(1, 1, 1);
            animator.SetBool(runBool, true);
        }
        else
        {
            animator.SetBool(runBool, false);
        }

        if (rig.linearVelocity.x > 0)
        {
            rig.linearVelocity += friction;
        }
        else if (rig.linearVelocity.x < 0)
        {
            rig.linearVelocity -= friction;
        }

    }

    public void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            rig.linearVelocity = Vector2.up * forceJump;
            rig.transform.localScale = Vector2.one;
            animator.SetTrigger(jumpTrigger);
            // _isGround = true;
            _isFlying = true;
            if (_isFlying)
            {
                animator.SetBool(jumpDownBool, true);
                _isFlying = false;
            }


           // DOTween.Kill(rig.transform);
            //ScaleJump();
        }


    }

   /* public void ScaleJump()
    {
        rig.transform.DOScaleY(jumpScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
        rig.transform.DOScaleX(jumpScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("_Ground"))
        {
            if (_isGround)
            {
                rig.transform.DOScaleX(landScaleX, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);
                rig.transform.DOScaleY(landScaleY, animationDuration).SetLoops(2, LoopType.Yoyo).SetEase(ease);

                _isGround = false;
            }
        }
    }*/

}
