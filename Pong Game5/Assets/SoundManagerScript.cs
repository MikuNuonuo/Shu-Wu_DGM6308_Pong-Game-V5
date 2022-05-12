using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManagerScript : MonoBehaviour
{
		public static AudioClip ballHitSound, CoinDestroySound;
		static AudioSource audioSrc;
		
    // Start is called before the first frame update
    void Start()
    {
		ballHitSound = Resources.Load<AudioClip>("ball");
		CoinDestroySound = Resources.Load<AudioClip>("coin");
		//return Resources.Load<AudioClip>("ball");
		//return Resources.Load<AudioClip>("coin");
		audioSrc = GetComponent<AudioSource>();
        
    }

	
	public static void BallSound(string clip){
		switch (clip){
			case "ball":
			audioSrc.PlayOneShot(ballHitSound); 
			break;
			case "coin":
			audioSrc.PlayOneShot(CoinDestroySound); 
			break;
		}
	}
}
