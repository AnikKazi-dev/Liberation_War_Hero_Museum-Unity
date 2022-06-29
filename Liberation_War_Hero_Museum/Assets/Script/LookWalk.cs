using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LookWalk : MonoBehaviour
{
    public Transform vrCamera;
    public float toggleAngle= 30.0f;
    public float speed = 3.0f;
    public bool moveForword;
    private CharacterController cc;

    // Start is called before the first frame update
    void Start()
    {
        cc = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        if(vrCamera.eulerAngles.x >= toggleAngle && vrCamera.eulerAngles.x < 90.0f)
        {
            moveForword = true;
        }
        else
        {
            moveForword = false;
        }

        if(moveForword)
        {

            Vector3 forword = vrCamera.TransformDirection(Vector3.forward);
            cc.SimpleMove(forword * speed);

        }
        if(Input.GetKey("escape"))
        {
            Application.Quit();
        }

    }
}
