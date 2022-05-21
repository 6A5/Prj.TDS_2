using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour, IProjectileSpawn
{
    /// <summary>
    /// ��s�l�u��m
    /// </summary>
    abstract protected void UpdateTransform();

    /// <summary>
    /// �R���l�u
    /// </summary>
    abstract protected void DestroyBullet();

    /// <summary>
    /// Ĳ�o
    /// </summary>
    abstract protected void Hit();

    /// <summary>
    /// �]�w�ƭ�
    /// </summary>
    /// <param name="skillIndex">�ݩ�</param>
    abstract public void SetProjectileAttr(int skillIndex);
}
