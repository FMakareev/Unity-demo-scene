using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraClickMove : MonoBehaviour {

    // Параметр прибавляется к целевой точки для того чтобы движение в эту точку было на той же высоте что и объект который к ней направляется
    public Vector3 offset = new Vector3(0, 1.5f, 0);

    // радиус от целевой точки, неоходим для того чтобы не перепрыгнуть точку
    public float radius = 2;

    // Скорость движения
    public float speed = 1.5f;

    // Луч идущий из наала координат
    private Ray ray;
    // Получение информации о rayCast
    private RaycastHit hit;

    // переменная отвечает за состояние идем мы или нет
    public bool moveComplete = true;

    public bool lookAt = true;

    // Use this for initialization
    void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonDown("Fire1"))
        {
            MouseClick();
        }
	}


    // Стреляем лучем из курсора в точку на карте
    private void MouseClick()
    {
        // Создаем луч стреляющий из курсора 
        ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        // проверка попал лучь кудалибо?
        if (Physics.Raycast(ray, out hit))
        {
            // проверяем попал ли луч в землю
            if (hit.transform.tag == "Ground")
            {
                // Идем в точку, передаем координаты куда идти
                Move(hit.point);
            }


        }

    }

    private void Move(Vector3 _point)
    {

        Debug.Log("_point: " + _point);
        // Если мы не идем то
        if (!moveComplete)
        {
            // останавливаем процесс
            StopCoroutine("MoveProcess");
        }
        // запускаем процесс и передаем координаты куда идти

        StartCoroutine(MoveProcess(_point));
    }

    private IEnumerator MoveProcess(Vector3 _point)
    {
        moveComplete = false;


        if (lookAt)
        {
            transform.LookAt(_point + offset);
        }

        while (!moveComplete)
        {
            transform.position = transform.position + transform.forward * speed;

            // проверяем если наша текущая позиция меньше радиуа то движение заканчиваем
            if (Vector3.Distance(transform.position, _point + offset) < radius)
            {
                moveComplete = true;
            }

            // один круг цикла должен проходить в один кадр, эта фишка отвечает за это
            yield return null;

        }
        yield break;

    }

}
