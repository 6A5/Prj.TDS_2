using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class BaseBullet : MonoBehaviour, IProjectileSpawn
{
    /// <summary>
    /// 更新子彈位置
    /// </summary>
    abstract protected void UpdateTransform();

    /// <summary>
    /// 刪除子彈
    /// </summary>
    abstract protected void DestroyBullet();

    /// <summary>
    /// 觸發
    /// </summary>
    abstract protected void Hit();

    /// <summary>
    /// 設定數值
    /// </summary>
    /// <param name="skillIndex">屬性</param>
    abstract public void SetProjectileAttr(int skillIndex);
}
