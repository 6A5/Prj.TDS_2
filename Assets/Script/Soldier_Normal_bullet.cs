using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Soldier_Normal_bullet : MonoBehaviour
{
    //�l�u�ƭ�
    float b_speed = 0;
    float b_distance = 99;
    float b_damage = 0;

    /// <summary>
    /// �X���I
    /// </summary>
    Vector3 spawnPoint;

    [SerializeField] float colliderRange = 1f;

    private void Start()
    {
        spawnPoint = transform.position;
    }

    private void Update()
    {
        transform.Translate(Vector2.up * b_speed * Time.deltaTime);
        Hit();
        DestroyBullet();
    }

    void DestroyBullet()
    {
        if ((spawnPoint - transform.position).magnitude < b_distance) { return; }
        Destroy(this.gameObject);
    }

    void Hit()
    {
        if (!Physics2D.OverlapCircle(transform.position, colliderRange)) { return; }

        Collider2D target = Physics2D.OverlapCircle(transform.position, colliderRange);
        if (target.gameObject.CompareTag("Enemy"))
        {
            target.GetComponent<EnemyHealth>().GotHit(b_damage);
            Destroy(this.gameObject);
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, colliderRange);
    }

    /// <summary>
    /// �]�w�l�u�ƭ�
    /// </summary>
    /// <param name="speed">�t��</param>
    /// <param name="distance">�Z��</param>
    /// <param name="damage">�ˮ`</param>
    public void SetBulletState(float speed, float distance, float damage)
    {
        b_speed = speed;
        b_distance = distance;
        b_damage = damage;
    }
}
