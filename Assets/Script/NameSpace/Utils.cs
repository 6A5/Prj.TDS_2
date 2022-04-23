using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NkE1.Utilities
{
    public class Utils : MonoBehaviour
    {
        #region 旋轉方向到指定目標
        /// <summary>
        /// 旋轉往目標方向
        /// </summary>
        /// <param name="target">目標物</param>
        /// <param name="self">旋轉的物體</param>
        public static void RotateDirectionToTarget(Vector3 target, Transform self)
        {
            float angle = GetAnglePointMousePosition(target, self.position);
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        /// <summary>
        /// 旋轉往滑鼠方向
        /// </summary>
        /// <param name="self">旋轉的物體</param>
        public static void RotateDirectionToMouse(Transform self)
        {
            Vector3 mouse = GetMouseWorldPosition();
            float angle = GetAnglePointMousePosition(mouse, self.position);
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        /// <summary>
        /// 取得旋轉角度
        /// </summary>
        /// <param name="targetPos">目標物</param>
        /// <param name="playerPos">旋轉的物體</param>
        /// <returns>角度</returns>
        public static float GetAnglePointMousePosition(Vector3 targetPos, Vector3 jointPos)
        {
            Vector3 dir = (targetPos - jointPos).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return angle;
        }
        /// <summary>
        /// 滑鼠位置轉換
        /// </summary>
        /// <returns>滑鼠位置</returns>
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            return vec;
        }
        #endregion


    }
}
