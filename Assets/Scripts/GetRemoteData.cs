using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEditor;
using Models;
using Proyecto26;
public class GetMyRestData : MonoBehaviour {

    private readonly string basePath = "https://unity.dev.compaero.ru";

    public string remotePath = "/";

    // UI панель с описанием элемента
    private GameObject _descriptionWindow;

    // Отвечает за текущее состояние Главного UI элемента
    private bool _toggleDescriptionWindow = false;

    // Поля в UI элементе
    private Text _pagetitle;
    private Text _longtitle;
    private Text _introtext;
    private Text _description;

    private House _data;
    private bool _request = false;

    // Use this for initialization
    void Start () {

        _descriptionWindow = GameObject.FindWithTag("UICanvas").transform.Find("DescriptionWindow").gameObject;

        if (_descriptionWindow != null)
        {
            _pagetitle   = _descriptionWindow.transform.Find("PagetitleText").GetComponent<Text>();
            _longtitle   = _descriptionWindow.transform.Find("LongtitleText").GetComponent<Text>();
            _introtext   = _descriptionWindow.transform.Find("IntrotextText").GetComponent<Text>();
            _description = _descriptionWindow.transform.Find("DescriptionText").GetComponent<Text>();
        }
        Get();
    }
	
	// Update is called once per frame
	void Update () {
		
	}

    // Клик по объекту
    private void OnMouseDown()
    {

//        EventSystem.current.currentSelectedGameObject.name;


        if (_request)
        {
            _toggleDescriptionWindow = true;
            _descriptionWindow.SetActive(_toggleDescriptionWindow);

            _pagetitle.text = _data.pagetitle;
            _longtitle.text = _data.longtitle;
            _introtext.text = _data.introtext;
            _description.text = _data.description;
        } else
        {
            Debug.Log("request: " + _request);
        }
    }
    

    private void Get()
    {

        // We can add default request headers for all requests
        RestClient.DefaultRequestHeaders["Authorization"] = "Bearer ...";

        RestClient.Get<House>(basePath + remotePath).Then(res => {
            _data = res;

            _request = true;

        }).Catch(err => Debug.Log("Error: "+ err.Message));
    }
}
