using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barricade : MonoBehaviour
{
    public AudioClip hit;
    void OnCollisionEnter2D(Collision2D collision){
        // Destroy(collision.gameObject);
        SoundManager.speaker.PlaySound(hit);
        Destroy(this.gameObject);
    }
}
