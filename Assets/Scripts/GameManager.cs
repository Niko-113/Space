using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public static GameManager master;
    public EnemyManager enemyManager;
    public GameObject player;
    public GameObject barricade;
    public Text scoreText;
    public Text highText;
    private int score = 0;
    private int lives = 3;


    // Start is called before the first frame update
    void Start()
    {
        master = this;
        // GameStart();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.LeftShift)){
            GameStart();
        }
    }

    void GameStart(){
        InstantiatePlayer();
        enemyManager.Instantiate();

    }

    public void AddPoints(int points){
        score += points;
        scoreText.text = ("SCORE\n  " + score.ToString("D4"));
    }

    public void PlayerHit(){
        lives--;
        if (lives == 0) EndGame();
        else InstantiatePlayer();

    }

    private void EndGame(){

    }

    private void InstantiatePlayer(){
        player = GameObject.Instantiate(player, transform);
        player.transform.localPosition = new Vector3(0, -3, 0);
    }

    private void InstantiateBarricade(){

    }
}
