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
}
