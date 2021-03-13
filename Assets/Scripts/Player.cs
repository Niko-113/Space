﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;

  public Animator animator;

  public int speed = 1;

    void Start(){
      animator = this.gameObject.GetComponent<Animator>();
    }


    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Destroy(shot, 3f);
        animator.SetTrigger("Shoot");
      }

      float horizontal = Input.GetAxis("Horizontal");
      transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

    }

    void OnCollisionEnter2D (Collision2D collision){
      GameManager.master.PlayerHit();
      Destroy(this.gameObject);

    }
}
