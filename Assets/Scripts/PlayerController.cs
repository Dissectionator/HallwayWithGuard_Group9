using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    //public AudioClip musicClipTwo;

    public float footSteps = 0.6f;
    float footStepsTime;
    public float speed=5f;
    // Start is called before the first frame update
    void Start()
    {
        footStepsTime=footSteps;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move*speed*Time.deltaTime);
         if(x != 0 || z != 0 )
        {
            footSteps-=Time.deltaTime;
            //play footsteps
            if(footSteps <0 )
            {
                musicSource.clip = musicClipOne;
                musicSource.Play();
                footSteps=footStepsTime;
            }
        }
        else
        {
            musicSource.Stop();
        }
        
    }
        private void OnTriggerEnter( Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            SceneManager.LoadScene("WinScreen");
        }
    }
    

    
}
