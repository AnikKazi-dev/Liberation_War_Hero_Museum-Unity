using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class GazeInterection : MonoBehaviour
{
    public float gazeTime = 2.0f;
    private float timer;
    private bool gazeAt;
    public GameObject people;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if(gazeAt)
        {
            timer += Time.deltaTime;
            if(timer >= gazeTime)
            {
                ExecuteEvents.Execute(gameObject,new PointerEventData(EventSystem.current), ExecuteEvents.pointerDownHandler);
                timer = 0.0f;
            }
        }

    }

    public void PointerEnter()
    {
        gazeAt = true;
    }
    public void PointerExit()
    {
        gazeAt = false;
        timer = 0.0f;
    }
    public void PointerDown()
    {
        gazeAt = false;
        people.SetActive(true);
    }

    public void QuitApp()
    {
        Application.Quit();
    }
}
