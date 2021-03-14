using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;

  public Animator animator;
  public AudioClip fire;
  public AudioClip explode;

  public int speed = 1;

    void Awake(){
      animator = this.gameObject.GetComponent<Animator>();
    }


    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        SoundManager.speaker.PlaySound(fire);
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Destroy(shot, 3f);
        animator.SetTrigger("Shoot");
      }

      float horizontal = Input.GetAxis("Horizontal");
      transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;
    }

    public void Goodbye(){
      Destroy(this.gameObject);
    }

    void OnCollisionEnter2D (Collision2D collision){
      SoundManager.speaker.PlaySound(explode);
      this.gameObject.GetComponent<BoxCollider2D>().enabled = false;
      animator.SetTrigger("Die");
      GameManager.master.PlayerHit();
      Destroy(this.gameObject, 0.7f);
    }
}
