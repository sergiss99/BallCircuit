using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Moves : MonoBehaviour {

public float forceValue;
public float jumpValue;
private Rigidbody rigidbody;
private AudioSource audio;
private int vida = 100;
public Text live;



	// Use this for initialization
	void Start () {
		rigidbody=GetComponent<Rigidbody>();
		audio = GetComponent<AudioSource>();
		live.text = "Nivel de vida: "+vida;

	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetButtonDown("Jump")&&Mathf.Abs(rigidbody.velocity.y)<0.01f){
			rigidbody.AddForce(Vector3.up*jumpValue,ForceMode.Impulse);
			audio.Play();
		}
		
		if(Input.touchCount==1){
			if(Input.touches[0].phase==TouchPhase.Began && Mathf.Abs(rigidbody.velocity.y)<0.01f){ 
				rigidbody.AddForce(Vector3.up*jumpValue,ForceMode.Impulse); 
				audio.Play(); 
			}
		}
		if (transform.position.y < 0.0f)
		{
			Application.LoadLevel(0);
		}
	}

	void FixedUpdate() {
		rigidbody.AddForce(new Vector3(Input.GetAxis("Horizontal"),0,Input.GetAxis("Vertical"))*forceValue);
		rigidbody.AddForce(new Vector3(Input.acceleration.x,0,Input.acceleration.y)*(forceValue*2));

	}

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Muro")
		{
			vida = vida - 10;
			live.text = "Nivel de vida: "+vida;

			if (vida<=0)
			{
				Application.LoadLevel(0);
				
				print("La esfera ha muerto");
			}
			
		}else if (collision.gameObject.tag == "Desaparece")
		{
			Destroy(collision.gameObject);
		}else if (collision.gameObject.tag == "Contaminacion")
		{
			vida = vida - 30;
			live.text = "Nivel de vida: "+vida;

			if (vida<=0)
			{
				Application.LoadLevel(0);
				
				print("La esfera ha muerto");
			}
			
		}
	}
}
