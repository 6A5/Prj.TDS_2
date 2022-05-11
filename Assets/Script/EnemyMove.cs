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

    [SerializeField] Transform latePos;
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        agent = GetComponent<NavMeshAgent>();
        agent.updateRotation = false;
        agent.updateUpAxis = false;

        latePos = transform;
    }

    private void Update()
    {
        agent.SetDestination(player.transform.position);

    }

    private void LateUpdate()
    {
        // print(agent.velocity.normalized);
        Utils.RotateDirectionByUnitVector(agent.velocity.normalized,transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject != player) { return; }
        print("hit");
    }
}
