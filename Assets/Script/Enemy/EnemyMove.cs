using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NkE1.Utilities;

public class EnemyMove : MonoBehaviour
{
    /// <summary>
    /// ���a
    /// </summary>
    private GameObject player;
    private NavMeshAgent agent;

    private EnemyAttribute enemyAttr;
    private bool isColliding;

    /// <summary>
    /// �N�o�ǽT�ɶ�
    /// </summary>
    private float lastAttackTime;

    private void Awake()
    {
        enemyAttr = GetComponent<EnemyAttribute>();
    }

    private void Start()
    {
        isColliding = CheckEnemyTypeIsColliding(enemyAttr.enemyType);

        InitMovement();
    }

    private void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isColliding)
        {

        }
        else
        {
            // ��z������
            transform.Translate(Vector2.right * enemyAttr.movementSpeed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (isColliding) // �I��������
        {
            Utils.RotateDirectionByUnitVector(agent.velocity.normalized, transform);
        }
        else // ��z������
        {
            Utils.RotateDirectionToTarget(player.transform.position, transform);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject != player || Time.time < lastAttackTime + enemyAttr.cooldown) { return; }

        collision.gameObject.GetComponent<PlayerHealth>().GotHit(enemyAttr.damage);

        lastAttackTime = Time.time;
    }

    /// <summary>
    /// �ˬd�Ǫ��O���OColliding�������ഫ��Bool
    /// </summary>
    /// <param name="type">�Ǫ�����</param>
    /// <returns></returns>
    private bool CheckEnemyTypeIsColliding(EnemyScriptObject.EnemyType type)
    {
        if (type == EnemyScriptObject.EnemyType.Colliding)
        {
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// ��l�Ʋ��ʼƾ�
    /// </summary>
    private void InitMovement()
    {
        // ���o���a
        player = GameObject.FindGameObjectWithTag("Player");
        // ���oAgent
        agent = GetComponent<NavMeshAgent>();

        if (isColliding) // �I����
        {
            // �����۰ʱ����۰ʹ��UP�b�V
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            agent.speed = enemyAttr.movementSpeed;
            print(enemyAttr.movementSpeed);

            StartCoroutine(UpdateDestination());
        }
        else // ��z��
        {
            // ����Agent
            agent.enabled = false;
        }
    }



    /// <summary>
    /// ��s���w
    /// </summary>
    /// <returns>���j�ɶ�</returns>
    IEnumerator UpdateDestination()
    {
        if (agent != null && agent.enabled)
        {
            agent.SetDestination(player.transform.position);
        }
        yield return new WaitForSeconds(0.15f);

        StartCoroutine(UpdateDestination());
    }
}
