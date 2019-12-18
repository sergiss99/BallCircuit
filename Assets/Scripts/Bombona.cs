using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bombona : MonoBehaviour
{
    public GameObject explosion;
    private AudioSource audio;


    // Start is called before the first frame update
    void Start()
    {
	    audio = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }

	void OnCollisionEnter(Collision collision)
	{
		if (collision.gameObject.tag == "Player")
		{
			Explosion.PlayExplosion();
			Instantiate(explosion, transform.position, Quaternion.identity);
        	Destroy(gameObject);
			
		}
	}
}
