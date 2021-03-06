using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  public GameObject bullet;
  public Transform shottingOffset;

  public int points = 10;
  public int hp = 1;

    void OnCollisionEnter2D(Collision2D collision)
    {
      hp--;
      if (hp <= 0) EnemyManager.manager.RemoveEnemy(this);
    }


    bool CheckBelow(){
      // raycast

      return true;
    }

    // Called by Manager
    public void Move(int x, int y, float speed){
      transform.position += new Vector3(x, y, 0) * speed * Time.deltaTime;
    }

    void Fire(){
      GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
      shot.GetComponent<Bullet>().speed *= -1;
      Destroy(shot, 3f);
    }
}
