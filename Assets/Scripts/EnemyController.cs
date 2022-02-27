using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class EnemyController : MonoBehaviour
{
    public Transform target;
    public float attackRadius = 20f;

    private NavMeshAgent navMeshAgent;
    
    public Transform [] destinations;

    float timer;

    float maxTime = 3f;

    private int currentPoint;

    bool inRange = false;
    public AudioSource musicSource;
    public AudioClip musicClipOne;

    void Start()
    {
       navMeshAgent=GetComponent<NavMeshAgent>();
       currentPoint = 0;
    }

    // Update is called once per frame
    void FixedUpdate()
    {

        float disTo = Vector3.Distance(transform.position, target.position);

        if (disTo <= attackRadius)
        {
            timer+=Time.deltaTime;

            if(timer > maxTime)
            {
                inRange = true;
                
                musicSource.clip = musicClipOne;
                musicSource.Play();

                navMeshAgent.speed =8;

                transform.LookAt(target);

                Vector3 moveTo = Vector3.MoveTowards(current: transform.position, target.position,maxDistanceDelta:100f);
                navMeshAgent.destination = moveTo;
                
            }

        }
        else
        {
            musicSource.Stop();
            inRange = false;
            BackToPath();
        }

    }

    void BackToPath()
    {
        if(inRange == false && navMeshAgent.remainingDistance <2f)
        {
            navMeshAgent.speed = 3;
            navMeshAgent.destination = destinations [currentPoint].position;
            UpdateCurrentPoint();
        }
    }

    void UpdateCurrentPoint()
    {
        if(currentPoint == destinations.Length-1)
        {
            currentPoint = 0;
        }
        else
        {
            currentPoint ++ ;
        }
    
    }

    //Lose Condition
    private void OnCollisionEnter( Collision other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            SceneManager.LoadScene("LoseScreen");
        }
    }

   
}
