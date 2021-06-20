
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float speedMove;
    [SerializeField] float maxSpeedMove;
    [SerializeField] float speedRotate;
    [SerializeField] float jumpHeight;
    [SerializeField] UI ui;

    private Rigidbody rb;
    private Animator animator;
    private bool isGround; // true→着地

    void Awake()
    {
        rb = GetComponent<Rigidbody>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        // Animatorにキャラクターや環境のパラメーターを設定する。
        ApplyAnimatorParameter();

        // キャラクターの移動
        Move();
        Rotation();
        Jump();
    }

    // Animatorにキャラクターや環境のパラメーターを設定する。
    void ApplyAnimatorParameter()
    {
        Vector3 movingDirection = new Vector3(rb.velocity.x, 0, rb.velocity.z);
        float speed = Mathf.Abs(movingDirection.magnitude / maxSpeedMove);
        animator.SetFloat("Speed", speed);

        animator.SetBool("IsGround", isGround);
        animator.SetFloat("FallSpeed", rb.velocity.y);
    }

    //前進後退
    void Move()
    {
        if (rb.velocity.z < maxSpeedMove && Mathf.Abs(Input.GetAxis("Vertical")) > 0.1f)
        {
            rb.AddForce(transform.forward * Input.GetAxis("Vertical") * Time.fixedDeltaTime * speedMove);
        }
    }

    // 回転
    void Rotation()
    {
        Vector3 rotate = new Vector3(0, Input.GetAxis("Horizontal"), 0);
        transform.Rotate(rotate * Time.fixedDeltaTime * speedRotate);
    }

    // ジャンプ
    void Jump()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGround)
        {
            rb.AddForce(transform.up * jumpHeight);
            isGround = false;
        }
    }

    void OnCollisionEnter(Collision other)
    {
        // 地面に触れた時
        if (other.gameObject.tag == "Ground")
        {
           isGround = true;
        }

        if(other.gameObject.tag == "Metabagu")
        {
            other.gameObject.SetActive(false);
            ui.MetabaguCount += 1;
        }
    }
}
