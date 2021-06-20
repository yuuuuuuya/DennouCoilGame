using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class DennouPet : MonoBehaviour
{
    [SerializeField] GameObject player;
    NavMeshAgent navMeshAgent;
    Animator animator;

    void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if(navMeshAgent.pathStatus != NavMeshPathStatus.PathInvalid)
        {
            // playerの右斜め後ろへ移動
            navMeshAgent.SetDestination(player.transform.TransformPoint(new Vector3(1f, 0, -0.3f)));
        }

        // Animatorにキャラの環境やパラメーターを設定する
        ApplyAnimatorParameter();
    }

    void ApplyAnimatorParameter()
    {
        // Animatorにキャラの環境やパラメーターを設定する
        Vector3 xyVector = new Vector3(navMeshAgent.velocity.x, 0, navMeshAgent.velocity.z);
        float speed = Mathf.Abs(xyVector.magnitude);
        animator.SetFloat("Speed", speed);
    }
}
