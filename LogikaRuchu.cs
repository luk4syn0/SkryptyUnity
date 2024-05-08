using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogikaRuchu : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Wartość prędkości gracza")]
    [Range(0.0f,4.0f)]
    public float predkoscRuchu = 3.0f;
    [SerializeField]
    Vector2 ruch = new Vector2();

    Animator animator;

    string stanyAnimacji = "StanyAnimacji";
    Rigidbody2D rb2D;

    enum Stany
    {
        wLewo = 1,
        wDol = 2,
        wPrawo = 3,
        wGore = 4,
        postoj = 5
    }

    private void Start()
    {
        animator = GetComponent<Animator>();
        rb2D = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        UpdateState();
    }

    void FixedUpdate()
    {
        RuchPostaci();
    }

    private void RuchPostaci()
    {
        ruch.x = Input.GetAxisRaw("Horizontal");
        ruch.y = Input.GetAxisRaw("Vertical");
        ruch.Normalize();
        rb2D.velocity = ruch * predkoscRuchu;
    }

    private void UpdateState()
    {
        if (ruch.x > 0)
        {
            animator.SetInteger(stanyAnimacji, (int)Stany.wPrawo);
        }
        else if (ruch.x < 0)
        {
            animator.SetInteger(stanyAnimacji, (int)Stany.wLewo);
        }
        else if (ruch.y > 0)
        {
            animator.SetInteger(stanyAnimacji, (int)Stany.wGore);
        }
        else if (ruch.y < 0)
        {
            animator.SetInteger(stanyAnimacji, (int)Stany.wDol);
        }
        else
        {
            animator.SetInteger(stanyAnimacji, (int)Stany.postoj);
        }
    }
}
