using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartBottun : MonoBehaviour
{
    GameObject Bird;
    Animator anim;

    private void Start()
    {
        Bird = GameObject.Find("Eagle Normal_0");
        anim = Bird.GetComponent<Animator>();
    }

    public void OnClickStartBottun()
    {
        anim.SetBool("gameStarted", true);
        SceneManager.LoadScene("Game");
    }
}
