using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraDragAndDrop : MonoBehaviour {

    // Скорость зума
    public int speed = 50;

    // список кнопок мыши
    public enum State
    {
        leftButton, rightButton, middleButton
    }
    public State MouseButton;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {

        // dran and drop камеры
        // Проверяем нажат ли LCtrl и кнопка мыши
        if (Input.GetKey(KeyCode.LeftControl) && Input.GetMouseButton((int)MouseButton))
        {
            // координату z объекта * координаты курсора по X * на вонмя рендера предыдущего кадра * на скорость
            transform.position -= transform.forward * Input.GetAxis("Mouse X") * Time.deltaTime * speed;
            // координату x объекта * координаты курсора по Y * на вонмя рендера предыдущего кадра * на скорость
            transform.position += transform.right * Input.GetAxis("Mouse Y") * Time.deltaTime * speed;
        }

    }
}
