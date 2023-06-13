using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//velocity.x = Input.GetAxisRaw("Horizontal") * MoveSpeed;
//if (Input.GetKeyDown(KeyCode.Space))
//{
//    velocity.y = Vector2.up.y * JumpSpeed;
//    //PlayerRb.AddForce(new Vector2(0f, JumpSpeed), ForceMode2D.Impulse);
//    //print(new Vector2(0f, JumpSpeed));
//}
//if (Input.GetKeyUp(KeyCode.Space))
//{
//    velocity.y = 0;
//}
////MoveDir.y = Input.GetAxisRaw("Vertical");
////PlayerRb.AddForce(MoveDir,ForceMode2D.Impulse);
//MoveDir = velocity.normalized;
//PlayerRb.velocity = velocity;
public class Move : MonoBehaviour
{
    [SerializeField]
    Rigidbody2D PlayerRb;
    [HideInInspector]
    public Vector2 MoveDir;

    float moveX;
    float moveY;
    bool IsJump;
    public bool IsTwoJump;
    int JumpCount;
    bool StartJump;
    [SerializeField] float SetJumpTime;
    float JumpTime;
    [SerializeField] float MoveSpeed;
    [SerializeField] float JumpSpeed;
    [SerializeField] ConstantForce2D Cons2D;
    // Start is called before the first frame update

    //public Vector2 velocity;
    // Update is called once per frame
    private void Awake()
    {
        Cons2D.force = Vector2.up * -10f;
        Cons2D.relativeForce = Vector2.up * -20f;
        StartJump = true;
        JumpTime = SetJumpTime;
        IsTwoJump = true;
    }
    void Update()
    {
        Movement();
        Jump();
        if (Input.GetKey(KeyCode.Q))
        {
            ChangeGravityDir(Vector2.up * -10f);
        }
        if (Input.GetKey(KeyCode.E))
        {
            ChangeGravityDir(Vector2.up * 10f);
        }
    }
    void Movement()
    {
        moveX = Input.GetAxis("Horizontal");
        moveY = Input.GetAxisRaw("Vertical");
        PlayerRb.velocity = new Vector2(moveX * MoveSpeed, PlayerRb.velocity.y);
    }
    
    void Jump()
    {
        print(JumpTime);
        print(JumpCount);
        if(Input.GetKeyDown(KeyCode.Space))
        {
            //PlayerRb.AddForce(-Cons2D.force*JumpSpeed, ForceMode2D.Force);
            StartJump = true;
            if(IsTwoJump)
            JumpCount++;
        }
        if(Input.GetKey(KeyCode.Space))
        {
            if (StartJump && IsJump)
            {
                JumpTime -= Time.deltaTime; 
            }   
            if (JumpTime >= 0 && IsJump)
            {
                PlayerRb.AddForce(-Cons2D.force * JumpSpeed, ForceMode2D.Force);
            }            
        }
        if (Input.GetKeyUp(KeyCode.Space))
        {
            JumpTime = SetJumpTime;
            StartJump = false;
            //print(JumpCount.ToString()+IsJump);

            if (IsTwoJump && JumpCount >= 1)
            {
                IsJump = false;
            }
            if (!IsTwoJump)
            {
                IsJump = false;
            }
            
        }
    }
    void ChangeGravityDir(Vector2 dir)
    {
        Cons2D.force = dir;
        Cons2D.relativeForce = dir * 2f;
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.CompareTag("Terrain"))
        {
            //print("55555");
            IsJump = true;
            if(IsTwoJump)
            JumpCount = 0;
        }
       // print("Terrain");
    }
    //private void OnTriggerExit2D(Collider2D collision)
    //{
    //    if (collision.CompareTag("Terrain"))
    //    {
    //        IsJump = false;
    //    }
    //}
    //void Grouding(Collider2D col, bool exitState)
    //{
    //    if (exitState)
    //    {
    //        if (col.gameObject.layer == LayerMask.NameToLayer("Terrain"))
    //        {
    //            isOnGround = false;
    //        }
    //    }
    //    else
    //    {
    //        if (col.gameObject.layer == LayerMask.NameToLayer("Terrain") && !isOnGround)
    //        {

    //        }
    //    }
    //}

}
