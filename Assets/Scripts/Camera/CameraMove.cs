using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMove : MonoBehaviour {


    // Скорость камеры
    public int speed = 10;

    // Координаты границ карты
    public float TopRestriction = 32;
    public float RightRestriction = 60;
    public float BottomRestriction = 113;
    public float leftRestriction = 30;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        // Left Move
        if ( transform.position.z >= leftRestriction && (int)Input.mousePosition.x < 50)
        {
            Debug.Log("Left");
            transform.position -= transform.forward * Time.deltaTime * speed;
        }

        // Right Move
        if (transform.position.z <= RightRestriction && (int)Input.mousePosition.x > Screen.width - 50)
        {
            Debug.Log("Right");
            transform.position += transform.forward * Time.deltaTime * speed;
        }

        // Bottom
        if (transform.position.x <= BottomRestriction && (int)Input.mousePosition.y < 50)
        {
            Debug.Log("Bottom");
            transform.position += transform.right * Time.deltaTime * speed;
        }
        
        // Top
        if ((transform.position.x >= TopRestriction) && (int)Input.mousePosition.y > Screen.height - 50)
        {
            Debug.Log("Top");
            transform.position -= transform.right * Time.deltaTime * speed;
        }
    }
}
