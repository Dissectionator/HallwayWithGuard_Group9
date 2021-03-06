using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    public CharacterController controller;
    public AudioSource musicSource;
    public AudioClip musicClipOne;
    public AudioClip musicClipTwo;
    
    public float footSteps = 0.6f;
    float footStepsTime;
    public float speed=7f;
    // Start is called before the first frame update
    Animator anim;
    int IsWalkHash;
    void Start()
    {
        footStepsTime=footSteps;

                anim = GetComponent<Animator>();
                IsWalkHash = Animator.StringToHash("IsWalk");
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        //player movement
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

        if (Input.GetKeyDown(KeyCode.Escape))
        {
             Application.Quit();
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            SceneManager.LoadScene("MainMenu");
        }

        bool IsWalk = anim.GetBool(IsWalkHash);
        bool PressW = Input.GetKey("w");
        if (!IsWalk && PressW)
        {
            anim.SetBool(IsWalkHash, true);
        }

        if (IsWalk && !PressW)
        {
            anim.SetBool(IsWalkHash, false);
        }

        
    }

    // Win condition
        private void OnTriggerEnter( Collider other)
    {
        if(other.gameObject.CompareTag("Pickup"))
        {
            musicSource.clip = musicClipTwo;
            musicSource.Play();
            SceneManager.LoadScene("WinScreen");
        }
        if(other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
    private void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.CompareTag("Enemy"))
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }
    
    

    
}
