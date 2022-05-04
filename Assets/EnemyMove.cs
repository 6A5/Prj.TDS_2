using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NkE1.Utilities;

public class EnemyMove : MonoBehaviour
{
    /// <summary>
    /// ª±®a
    /// </summary>
    [SerializeField] GameObject player;
    NavMeshAgent agent;

    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);
    }

    private void LateUpdate()
    {
        Utils.RotateDirectionToTarget(player.transform.position, transform);
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        //if (collision.gameObject != player) { return; }

        print("hit");
    }
}
