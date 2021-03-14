using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{

    public static GameManager master;
    public EnemyManager enemyManager;

    public GameObject player;
    public GameObject barricade;

    public Text scoreText;
    public Text highText;
    public Text scoreTable;
    public Text lifeText;

    private int score = 0;
    private int highscore = 0;
    private int lives = 3;

    private bool hasStarted = false;


    // Start is called before the first frame update
    void Start()
    {
        master = this;
    }

    void Update(){
        if(Input.GetKeyDown(KeyCode.LeftShift) && !hasStarted) GameStart();
    }

    void GameStart(){
        SceneManager.LoadScene("DemoScene");

        hasStarted = true;
        scoreTable.gameObject.SetActive(false);

        InstantiatePlayer();
        InstantiateBarricade();

        enemyManager.Instantiate();
        StartCoroutine("SpawnUFO");

        lives = 3;
        score = 0;
        lifeText.text = "LIVES: " + lives;
        scoreText.text = ("SCORE\n  " + score.ToString("D4"));

        


    }


    public void AddPoints(int points){
        score += points;
        scoreText.text = ("SCORE\n  " + score.ToString("D4"));
    }

    public void PlayerHit(){
        lives--;
        lifeText.text = "LIVES: " + lives;
        if (lives == 0) GameOver();
        else InstantiatePlayer();

    }

    public void GameOver(){
        

        enemyManager.Clear();
        var items = GameObject.FindGameObjectsWithTag("Barricade");
        foreach (var item in items){
            Destroy(item);
        }

        
        StopCoroutine("SpawnUFO");
        scoreTable.gameObject.SetActive(true);
        

        DontDestroyOnLoad(this.gameObject);
        DontDestroyOnLoad(scoreText);
        DontDestroyOnLoad(highText);
        DontDestroyOnLoad(enemyManager);

        SceneManager.LoadScene("CreditScene");

        StartCoroutine("EndCredits");

        



        

    }

    private void InstantiatePlayer(){
        GameObject newPlayer = GameObject.Instantiate(player, transform);
        newPlayer.transform.localPosition = new Vector3(10, -1, 0);
    }

    private void InstantiateBarricade(){
        for (int i = 0; i < 4; i++){
            GameObject newBarricade = GameObject.Instantiate(barricade, transform);
            newBarricade.transform.localPosition = new Vector3(i * 5, 3, 0);
        }
    }

    IEnumerator SpawnUFO(){
        while(true){
            //enemyManager.SpawnEnemy(3, new Vector3(-10, 8, 0));
            enemyManager.SpawnUFO();
            yield return new WaitForSeconds(30f);
        }
    }

    IEnumerator EndCredits(){
        yield return new WaitForSeconds(5);
        SceneManager.LoadScene("MenuScene");

        if (score > highscore) highscore = score;
        highText.text = ("HI-SCORE\n   " + highscore.ToString("D4"));
        hasStarted = false;
    }
}
