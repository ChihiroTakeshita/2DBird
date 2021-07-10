using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    [SerializeField] float JumpV = 10; //ジャンプ力

    Rigidbody2D rb2D;
    SpriteRenderer rend;
    Animator anim;

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
            rb2D.velocity = Vector2.zero; //落下速度をリセット
            rb2D.AddForce(transform.up * JumpV, ForceMode2D.Impulse); //上方向に力を加える
        };
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        StartCoroutine(ChangeSprite());
    }

    private IEnumerator ChangeSprite()
    {
        anim.SetBool("isDead", true);

        yield return new WaitForSeconds(1.0f);

        anim.SetBool("isDead", false);
    }
}