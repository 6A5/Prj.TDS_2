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
            float angle = GetAnglePointTargetPosition(target, self.position);
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        /// <summary>
        /// 旋轉往滑鼠方向
        /// </summary>
        /// <param name="self">旋轉的物體</param>
        public static void RotateDirectionToMouse(Transform self)
        {
            Vector3 mouse = GetMouseWorldPosition();
            float angle = GetAnglePointTargetPosition(mouse, self.position);
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        /// <summary>
        /// 依照單位向量進行旋轉
        /// </summary>
        /// <param name="vector">單位向量</param>
        /// <param name="self">旋轉的物體</param>
        public static void RotateDirectionByUnitVector(Vector3 vector, Transform self)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        
        /// <summary>
        /// 取得旋轉角度
        /// </summary>
        /// <param name="targetPos">目標物</param>
        /// <param name="playerPos">旋轉的物體</param>
        /// <returns>角度</returns>
        public static float GetAnglePointTargetPosition(Vector3 targetPos, Vector3 jointPos)
        {
            Vector3 dir = (targetPos - jointPos).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return angle;
        }
        /// <summary>
        /// 取得旋轉到滑鼠的角度
        /// </summary>
        /// <param name="jointPos">旋轉物體</param>
        /// <returns></returns>
        public static float GetAnglePointMousePosition(Vector3 jointPos)
        {
            Vector3 mouse = GetMouseWorldPosition();
            Vector3 dir = (mouse - jointPos).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return angle;
        }
        /// <summary>
        /// 取得旋轉物轉向至滑鼠方位的單位向量
        /// </summary>
        /// <param name="jointPos">旋轉物體</param>
        /// <returns>轉向滑鼠的單位向量</returns>
        public static Vector3 GetJointPointMouseUnit(Vector3 jointPos)
        {
            Vector3 mouse = GetMouseWorldPosition();
            Vector3 dir = (mouse - jointPos).normalized;
            return dir;
        }

        /// <summary>
        /// 取得旋轉物轉向至目標方位的單位向量
        /// </summary>
        /// <param name="targetPos">目標</param>
        /// <param name="jointPos">旋轉物</param>
        /// <returns></returns>
        public static Vector3 GetJointPointTargetUnit(Vector3 targetPos, Vector3 jointPos)
        {
            Vector3 dir = (targetPos - jointPos).normalized;
            return dir;
        }
        /// <summary>
        /// 取得滑鼠在世界座標的位置
        /// </summary>
        /// <returns>滑鼠位置</returns>
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            return vec;
        }


        #endregion

        #region 數學
        public static float RoundToDecimalPlaces(float origin, int decimalPlaces)
        {
            var a = (float)Mathf.Round(origin * Mathf.Pow(10, decimalPlaces)) / Mathf.Pow(10, decimalPlaces);
            return a;
        }
        #endregion
    }
}


