using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{

    private Animator anim;
    private bool onLeft, onRight;
    private bool jumped;

    [SerializeField]
    private AudioSource audioKill, audioJump;

    [SerializeField]
    private AudioClip deadSound;

    private bool isAlive = true;
    private Rigidbody2D rb;

    [SerializeField]
    private float jumpForce = 5f;

    void Awake()
    {
        GameObject.Find("JumpBtn").GetComponent<Button>().onClick.AddListener(Jump);
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

        onRight = true;
        onLeft = false;
    }

    void Update()
    {
        if (isAlive)
        {
            if (!jumped)
            {
                anim.Play("Run"); // ����� ������� ���� �����
                GetComponent<SpriteRenderer>().flipX = !onRight;
            }
        }
    }

    public void Jump()
    {
        if (isAlive && !jumped)
        {
            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            jumped = true;
            audioJump.Play();

            anim.Play("Jump"); // ������� ������� ���� �����
            GetComponent<SpriteRenderer>().flipX = !onRight;
        }
    }

    void OnWall()
    {
        if (isAlive)
        {
            anim.Play("WallRun"); // ������� ������� ���� ����� ��� ������
            GetComponent<SpriteRenderer>().flipX = !onRight;
            jumped = false; // ������ ������ ��� ���� ��� ������ ��� ������
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            jumped = false;
        }
    }

    void PlayerDied()
    {
        audioKill.clip = deadSound;
        audioKill.Play();

        isAlive = false;

        anim.Play("PlayerDied");
        GetComponent<SpriteRenderer>().flipX = !onRight;

      //  GameplayController.instance.GameOver();
        Time.timeScale = 0f;
    }

    void OnTriggerEnter2D(Collider2D target)
    {
        if (target.CompareTag("Enemy"))
        {
            if (jumped)
            {
                target.gameObject.SetActive(false);
                audioKill.Play();
            }
            else
            {
                PlayerDied();
            }
        }

        if (target.CompareTag("EnemyTree"))
        {
            PlayerDied();
        }
    }
}
