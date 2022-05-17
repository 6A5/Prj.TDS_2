using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface IProjectileSpawn
{

    /// <summary>
    /// 設定技能
    /// </summary>
    /// <param name="skillIndex">技能List位置</param>
    void SetProjectileAttr(int skillIndex);
}
