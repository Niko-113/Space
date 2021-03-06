using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
  public GameObject bullet;

  public Transform shottingOffset;

  public int speed = 1;
    // Update is called once per frame
    void Update()
    {
      if (Input.GetKeyDown(KeyCode.Space))
      {
        GameObject shot = Instantiate(bullet, shottingOffset.position, Quaternion.identity);
        Debug.Log("Bang!");

        Destroy(shot, 3f);

      }

      float horizontal = Input.GetAxis("Horizontal");

      transform.position += new Vector3(horizontal, 0, 0) * speed * Time.deltaTime;

    }

    void OnCollisionEnter2D (Collision2D collision){
      Destroy(this.gameObject);
      
    }
}
