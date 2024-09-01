using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FollowScript : MonoBehaviour

{

    public GameObject Player;
    public float ZoomSpeed;
    public float panSpeed;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButton(1))
        {
            Debug.Log(Input.mousePosition.x);
            if(Input.mousePosition.x > 950)
            {
                transform.Rotate(0, 0.1f * panSpeed, 0);
            } else
            {
                transform.Rotate(0, -0.1f * panSpeed, 0);
            }
        }
        Vector3 pos = Player.transform.position;
        transform.position = pos;
    }
}
