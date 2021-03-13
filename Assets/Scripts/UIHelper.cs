using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class UIHelper : MonoBehaviour
{
    public GameObject victoryBtn, loseBtn, player;
    private float needScore = 1000f;
    public static float score;
    public Text scoreText;
    void Start()
    {
        score = 0f;
    }

    void Update()
    {
        scoreText.text = "Score: " + score + "/" + needScore;

        if (score == needScore)
            StartCoroutine(VictoryShow());
        if(player==null)
            StartCoroutine(LoseShow());
    }
    IEnumerator VictoryShow()
    {
        victoryBtn.SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
    IEnumerator LoseShow()
    {
        loseBtn .SetActive(true);
        yield return new WaitForSeconds(2f);
        SceneManager.LoadScene("Menu");
    }
}
