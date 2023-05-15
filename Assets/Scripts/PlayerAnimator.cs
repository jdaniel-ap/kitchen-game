using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimator : MonoBehaviour
{
    private string IS_WALKING = "IsWalking";

    private bool isWalking;
    private Animator animator;
    [SerializeField] Player player;
    // Start is called before the first frame update
    private void Awake()
    {
        animator = GetComponent<Animator>();  
    }

    private void Update()
    {
        animator.SetBool(IS_WALKING, player.IsWalking());

    }
}
