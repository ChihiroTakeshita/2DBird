using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Score : MonoBehaviour
{
    [SerializeField] int scorePerSecond;

    int currentScore = 0;
    Text scoreText;

    // Start is called before the first frame update
    void Start()
    {
        scoreText = this.GetComponent<Text>();
        StartCoroutine(AddScore());
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = "Score : " + currentScore.ToString();
    }

    private IEnumerator AddScore()
    {
        while(true)
        {
            currentScore += scorePerSecond;

            yield return new WaitForSeconds(1.0f);
        }
    }
}
