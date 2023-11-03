using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAnimator : MonoBehaviour
{

    [Header("References")]

    [SerializeField] private Animator animator;
    void Start()
    {
        
    }

    public void playHurtAnimation(){
        animator.SetTrigger("Hurt");
    }


}
