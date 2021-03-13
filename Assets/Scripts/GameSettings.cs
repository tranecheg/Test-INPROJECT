using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameSettings : MonoBehaviour
{
    public static float playerDamage = 10f, playerHealth = 100f;
    public static float enemyDamage = 5f, enemyHealth = 100f, enemySpeed = 5f;
    public static float spawnDelay = 2f;
    public InputField[] fields;
    
    void Start()
    {
        fields[0].text = playerDamage.ToString();
        fields[1].text = playerHealth.ToString();
        fields[2].text = spawnDelay.ToString();
        fields[3].text = enemyDamage.ToString();
        fields[4].text = enemyHealth.ToString();
        fields[5].text = enemySpeed.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        playerDamage = float.Parse(fields[0].text);
        playerHealth = float.Parse(fields[1].text);
        spawnDelay = float.Parse(fields[2].text);
        enemyDamage = float.Parse(fields[3].text);
        enemyHealth = float.Parse(fields[4].text);
        enemySpeed = float.Parse(fields[5].text);
    }

    public void Menu()
    {
        SceneManager.LoadScene("Menu");
    }
}
