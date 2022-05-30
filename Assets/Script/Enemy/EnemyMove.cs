using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using NkE1.Utilities;

public class EnemyMove : MonoBehaviour
{
    /// <summary>
    /// 玩家
    /// </summary>
    private GameObject player;
    private NavMeshAgent agent;

    private EnemyAttribute enemyAttr;
    private bool isColliding;

    /// <summary>
    /// 冷卻準確時間
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
            // 穿透型移動
            transform.Translate(Vector2.right * enemyAttr.movementSpeed * Time.deltaTime);
        }
    }

    private void LateUpdate()
    {
        if (isColliding) // 碰撞型旋轉
        {
            Utils.RotateDirectionByUnitVector(agent.velocity.normalized, transform);
        }
        else // 穿透型旋轉
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
    /// 檢查怪物是不是Colliding類型並轉換成Bool
    /// </summary>
    /// <param name="type">怪物類型</param>
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
    /// 初始化移動數據
    /// </summary>
    private void InitMovement()
    {
        // 取得玩家
        player = GameObject.FindGameObjectWithTag("Player");
        // 取得Agent
        agent = GetComponent<NavMeshAgent>();

        if (isColliding) // 碰撞型
        {
            // 關閉自動旋轉跟自動對齊UP軸向
            agent.updateRotation = false;
            agent.updateUpAxis = false;

            agent.speed = enemyAttr.movementSpeed;
            print(enemyAttr.movementSpeed);

            StartCoroutine(UpdateDestination());
        }
        else // 穿透型
        {
            // 關閉Agent
            agent.enabled = false;
        }
    }



    /// <summary>
    /// 更新路逕
    /// </summary>
    /// <returns>間隔時間</returns>
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
