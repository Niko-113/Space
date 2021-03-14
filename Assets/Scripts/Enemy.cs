using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

  public GameObject bullet;
  public Transform shottingOffset;

  public AudioClip explode;
  public AudioClip fire;


  public Animator animator;

  public int points = 10;
  public int hp = 1;

    void Awake(){
      animator = this.gameObject.GetComponent<Animator>();
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
      if (collision.gameObject.tag.Equals("Bullet")) hp--;

      if (hp == 0){
        this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
        animator.SetTrigger("Die");
        SoundManager.speaker.PlaySound(explode);
        EnemyManager.manager.RemoveEnemy(this);
      } 
    }

    bool CheckBelow(){
      RaycastHit2D hit = Physics2D.Raycast(shottingOffset.position, Vector2.down);
      
      if (hit){
        if (hit.collider.gameObject.tag.Equals("Enemy")) return true;
      }

      return false;
    }

    // Called by Manager
    public void Move(int x, int y, float speed){
      if (this.gameObject.name.Equals("EnemyRare")) x = 1;
      transform.position += new Vector3(x, y, 0) * speed * Time.deltaTime;
    }

    public void Fire(){
      if (CheckBelow() || !this.gameObject.tag.Equals("CanFire")){
        return;
      } 

      GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
      shot.GetComponent<Bullet>().speed *= -1;
      animator.SetTrigger("Shoot");
      SoundManager.speaker.PlaySound(fire);
      Destroy(shot, 3f);
    }
}
