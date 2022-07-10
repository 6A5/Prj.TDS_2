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
            float angle = GetAnglePointTargetPosition(target, self.position);
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        /// <summary>
        /// ���੹�ƹ���V
        /// </summary>
        /// <param name="self">���઺����</param>
        public static void RotateDirectionToMouse(Transform self)
        {
            Vector3 mouse = GetMouseWorldPosition();
            float angle = GetAnglePointTargetPosition(mouse, self.position);
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        /// <summary>
        /// �̷ӳ��V�q�i�����
        /// </summary>
        /// <param name="vector">���V�q</param>
        /// <param name="self">���઺����</param>
        public static void RotateDirectionByUnitVector(Vector3 vector, Transform self)
        {
            float angle = Mathf.Atan2(vector.y, vector.x) * Mathf.Rad2Deg;
            self.eulerAngles = new Vector3(0, 0, angle);
        }
        
        /// <summary>
        /// ���o���ਤ��
        /// </summary>
        /// <param name="targetPos">�ؼЪ�</param>
        /// <param name="playerPos">���઺����</param>
        /// <returns>����</returns>
        public static float GetAnglePointTargetPosition(Vector3 targetPos, Vector3 jointPos)
        {
            Vector3 dir = (targetPos - jointPos).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return angle;
        }
        /// <summary>
        /// ���o�����ƹ�������
        /// </summary>
        /// <param name="jointPos">���ફ��</param>
        /// <returns></returns>
        public static float GetAnglePointMousePosition(Vector3 jointPos)
        {
            Vector3 mouse = GetMouseWorldPosition();
            Vector3 dir = (mouse - jointPos).normalized;
            float angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            return angle;
        }
        /// <summary>
        /// ���o���ફ��V�ܷƹ���쪺���V�q
        /// </summary>
        /// <param name="jointPos">���ફ��</param>
        /// <returns>��V�ƹ������V�q</returns>
        public static Vector3 GetJointPointMouseUnit(Vector3 jointPos)
        {
            Vector3 mouse = GetMouseWorldPosition();
            Vector3 dir = (mouse - jointPos).normalized;
            return dir;
        }

        /// <summary>
        /// ���o���ફ��V�ܥؼФ�쪺���V�q
        /// </summary>
        /// <param name="targetPos">�ؼ�</param>
        /// <param name="jointPos">���ફ</param>
        /// <returns></returns>
        public static Vector3 GetJointPointTargetUnit(Vector3 targetPos, Vector3 jointPos)
        {
            Vector3 dir = (targetPos - jointPos).normalized;
            return dir;
        }
        /// <summary>
        /// ���o�ƹ��b�@�ɮy�Ъ���m
        /// </summary>
        /// <returns>�ƹ���m</returns>
        public static Vector3 GetMouseWorldPosition()
        {
            Vector3 vec = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            vec.z = 0;
            return vec;
        }


        #endregion

        #region �ƾ�
        public static float RoundToDecimalPlaces(float origin, int decimalPlaces)
        {
            var a = (float)Mathf.Round(origin * Mathf.Pow(10, decimalPlaces)) / Mathf.Pow(10, decimalPlaces);
            return a;
        }
        #endregion
    }
}


