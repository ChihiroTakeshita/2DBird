using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float JumpV = 10; //ジャンプ力

    Rigidbody2D rb2D;
    Animator anim;

    bool isDead = false;

    // Start is called before the first frame update
    void Start()
    {
        rb2D = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
            TouchManager.Began += (info) =>
            {
                if(!isDead)
                {
                    rb2D.velocity = Vector2.zero; //落下速度をリセット
                    rb2D.AddForce(transform.up * JumpV, ForceMode2D.Impulse); //上方向に力を加える
                }
            };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ChangeAnimation());
    }

    private IEnumerator ChangeAnimation()
    {
        anim.SetBool("isDead", true);
        isDead = true;
        rb2D.simulated = false;

        yield return new WaitForSeconds(1.0f);

        anim.SetBool("isDead", false);
        isDead = false;
        rb2D.simulated = true;
    }
}