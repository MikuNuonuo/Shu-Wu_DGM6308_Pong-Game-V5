using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour{
	public float MovementSpeed = 1;
	public float JumpForce = 1;
	private Rigidbody2D rb2d;
	public static AudioClip ballHitSound, CoinDestroySound;
		static AudioSource audioSrc;
	void GoBall(){
		float rand = Random.Range(0,2);
		if (rand <1){
			rb2d.AddForce(new Vector2(20,-15));
		}else{
			rb2d.AddForce(new Vector2(-20,-15));
		}
	}
    // Start is called before the first frame update
    void Start(){
		CoinDestroySound = Resources.Load<AudioClip>("coin");
		audioSrc = GetComponent<AudioSource>();
		
		rb2d = GetComponent<Rigidbody2D>();
		Invoke("GoBall",2);
        
    }
	
	void ResetBall(){
		rb2d.velocity = new Vector2(0,1.5f);
		transform.position = new Vector2(0,1.5f);
		
		
	}
	
	void RestartGame(){
		ResetBall();
		Invoke("GoBall",1);
	}
	
	void OnCollisionEnter2D(Collision2D coll){
		if (coll.collider.CompareTag ("Player")){
			Vector2 vel;
			vel.y = rb2d.velocity.y;
			vel.x = (rb2d.velocity.x /2.0f) + (coll.collider.attachedRigidbody.velocity.x/3.0f);
			rb2d.velocity = vel;
		}
			
		
	}
	   private void OnTriggerEnter2D(Collider2D other){
	   
        if (other.gameObject.CompareTag("Coins"))
        {
            // pick up coin
            Destroy(other.gameObject);
			SoundManagerScript.BallSound("coin");
        }
    }
		void Update(){
		if (Input.GetKeyUp(KeyCode.Z))
        {
			  ResetBall();
        }
		}

}
