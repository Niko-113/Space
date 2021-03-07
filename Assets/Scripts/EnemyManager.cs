using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemy1;
    public GameObject enemy2;
    public GameObject enemy3;
    private List<Enemy> enemies = new List<Enemy>();
    public float speed = 1;
    private int x = 1;
    private int y = 0;

    public static EnemyManager manager;

    // Start is called before the first frame update
    void Start()
    {
        //Instantiate();
        manager = this;
    }

    public void Instantiate(){
        for (int i = 0; i < 3; i++){
            for (int j = 0; j < 5; j++){
                SpawnEnemy(i, new Vector3(j * 1.5f, -i * 1.5f, 0));
            }
        }
        StartCoroutine("TryFire");
    }

    void FixedUpdate(){
        foreach (var enemy in enemies){
            
            enemy.Move(x, y, speed);
            if (enemy.transform.position.x > 10){
                x = -1;
                SwitchDirection();
            }
            if (enemy.transform.position.x < -10){
                x = 1;
                SwitchDirection();
            }
        }

        

    }

    IEnumerator TryFire(){
        while(enemies.Count > 0){
            int index = Random.Range(0, enemies.Count - 1);
            enemies[index].Fire();

            yield return new WaitForSeconds(0.5f);
        }
    }



    void SwitchDirection(){
        transform.position += new Vector3(0, -1, 0);
    }

    void SpawnEnemy(int type, Vector3 positionToSpawn){
        GameObject toSpawn;
        switch (type){
            case 0: toSpawn = enemy3; break;
            case 1: toSpawn = enemy2; break;
            case 2: toSpawn = enemy1; break;
            default: return;
        }

        toSpawn = GameObject.Instantiate(toSpawn, transform);
        toSpawn.transform.localPosition = positionToSpawn;
        enemies.Add(toSpawn.GetComponent<Enemy>());
    }

    public void RemoveEnemy(Enemy enemy){
        enemies.Remove(enemy);
        GameManager.master.AddPoints(enemy.points);
        Destroy(enemy.gameObject);
        speed += 0.1f;
        
        if (enemies.Count == 0){
            //GameManager.master.GameOver();
            // Restart stuff but don't end game
        }
    }
}
