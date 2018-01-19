using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class Rocket : MonoBehaviour
{
    Rigidbody rigidBody;
    AudioSource audioSource;

	// Use this for initialization
	void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        bool thrust = CrossPlatformInputManager.GetButton("Thrust");
        if (thrust)
        {
            rigidBody.AddRelativeForce(Vector3.up);
            if (!audioSource.isPlaying)
            {
                audioSource.Play();
            }
            

            print("Thrust = " + thrust);
        }
        else
        {
            audioSource.Stop();
            return;
        }
        
    }

    private void ProcessRotation()
    {
        float xThrow = CrossPlatformInputManager.GetAxis("Horizontal");
        if (xThrow < 0)
        {
            print(" Rotating Left, " + xThrow);
        }
        else if(xThrow > 0)
        {
            print("Rotating Right, " + xThrow);
        }
        
    }
}
