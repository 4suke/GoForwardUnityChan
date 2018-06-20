using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleGenerator : MonoBehaviour
{

	// Use this for initialization
	void Start ()
    {
        
    }
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    public void Particle()
    {
        //パーティクルを再生
        GetComponent<ParticleSystem>().Play();
    }
}
