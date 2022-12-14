using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetFanAnimation : MonoBehaviour
{
    Animator animator;
    protected const string Flex = "Flex";

    private void OnEnable()
    {
        animator = GetComponent<Animator>();

        animator.CrossFade(Flex, 0.2f);
    }
}
