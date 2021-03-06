using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int points;
    // Start is called before the first frame update
    void OnCollisionEnter2D(Collision2D collision)
    {
      //Debug.Log("Ouch!");
    }

    void OnDestroy(){
      Debug.Log("Ouch but for real this time");
      // Add points to manager
    }
}
