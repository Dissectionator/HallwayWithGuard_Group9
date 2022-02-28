using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GuardAnim : MonoBehaviour
{
    Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
        anim.SetInteger("IsWalk", 0);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
