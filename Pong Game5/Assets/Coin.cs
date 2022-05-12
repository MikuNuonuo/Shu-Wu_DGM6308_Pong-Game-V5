using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
  public GameManager ui;
  public Transform explosion;
  AudioSource Audio;
  public int coinValue = 1;

  void Start()
    {
        Audio = GetComponent<AudioSource>();
        ui = GameObject.FindWithTag("ui").GetComponent<GameManager>();
    }

  private void OnTriggerEnter2D(Collider2D other)
  {
	  if (other.gameObject.CompareTag("Ball"))
	  {
          ui.IncrementScore();
          Destroy(gameObject);
	  }
  }

}
   
