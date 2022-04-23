using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace NkE1.Utilities
{
    public class Utils : MonoBehaviour
    {
        #region �����V����w�ؼ�
        /// <summary>
        /// ���੹�ؼФ�V
        /// </summary>
        /// <param name="target">�ؼЪ�</param>
        /// <param name="self">���઺����</param>
        public static void RotateDirectionToTarget(Vector3 target, Transform self)
        {
            float angle = GetAnglePointMousePosition(target, self.position);
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        /// <summary>
        /// ���੹�ƹ���V
        /// </summary>
        /// <param name="self">���઺����</param>
        public static void RotateDirectionToMouse(Transform self)
        {
            Vector3 mouse = GetMouseWorldPosition();
            float angle = GetAnglePointMousePosition(mouse, self.position);
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        /// <summary>
        /// ���o���ਤ��
        /// </summary>
        /// <param name="targetPos">�ؼЪ�</param>
        /// <param name="playerPos">���઺����</param>
        /// <returns>����</returns>
        public static float GetAnglePointMousePosition(Vector3 targetPos, Vector3 jointPos)
        {
            Vector3 dir = (targetPos - jointPos).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return angle;
        }
        /// <summary>
        /// �ƹ���m�ഫ
        /// </summary>
        /// <returns>�ƹ���m</returns>
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            return vec;
        }
        #endregion


    }
}
