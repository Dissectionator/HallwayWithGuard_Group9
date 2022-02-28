using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnim : MonoBehaviour
{
    Animator anim;
    int IsWalkHash;
    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        IsWalkHash = Animator.StringToHash("IsWalk");
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

    if(x != 0 || z != 0 )
    {
        anim.SetBool(IsWalkHash, true);
    }
        else
        {
            anim.SetBool(IsWalkHash, false);
        }


    }
}
