using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyManager : MonoBehaviour
{
    public GameObject enemyPrefab;
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
                SpawnEnemy(new Vector3(j * 1.3f, -i * 1.3f, 0));
            }
        }
    }

    void FixedUpdate(){
        foreach (var enemy in enemies){
            enemy.Move(x, y, speed);
        }
    }

    void SpawnEnemy(Vector3 positionToSpawn){
        GameObject toSpawn;
        toSpawn = enemyPrefab;

        toSpawn = GameObject.Instantiate(toSpawn, transform);
        toSpawn.transform.localPosition = positionToSpawn;
        enemies.Add(toSpawn.GetComponent<Enemy>());
    }

    public void RemoveEnemy(Enemy enemy){
        enemies.Remove(enemy);
        GameManager.master.AddPoints(enemy.points);
        Destroy(enemy.gameObject);
        speed += 0.1f;
    }
}
