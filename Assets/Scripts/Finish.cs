using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Finish : MonoBehaviour
{
    private AudioSource audio;
    public Text finish;


    // Start is called before the first frame update
    void Start()
    {
        audio = GetComponent<AudioSource>();
        finish.text = "";

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    
    void OnTriggerEnter(Collider other)
    {
    	if (other.gameObject.tag == "Player")
        {
	        Music.stopAudio();
			audio.Play();
			finish.text = "ENHORABUENA! Lanzate al vacio para comenzar de nuevo";
		}
    }

    
}
