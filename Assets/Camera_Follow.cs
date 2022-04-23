using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Follow : MonoBehaviour
{
    [SerializeField] GameObject player;
    private void Update()
    {
        transform.position = new Vector3(player.transform.position.x,player.transform.position.y,transform.position.z);
    }
}
