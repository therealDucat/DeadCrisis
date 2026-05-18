using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAiming : MonoBehaviour
{
    public Transform CameraLookAt;
    public Transform Player;
    public Animator animator;

    public Cinemachine.AxisState xAxis;
    public Cinemachine.AxisState yAxis;
    public float AimAxis = 0f;
    public bool isAiming = false;

    public float MaxSpeedX;
    public float MaxSpeedY;


    int isAimingParam = Animator.StringToHash("isAiming");
    
    void Start()
    {
        //MaxSpeedX = xAxis.m_MaxSpeed;
        //MaxSpeedY = yAxis.m_MaxSpeed;
    }

    void FixedUpdate()
    {
        AimAxis = Input.GetAxis("Fire2");

        if (Input.GetButton("Fire2") || AimAxis > 0.01f) { //If Aim button pressed - make sensetivity X0.5
            xAxis.m_MaxSpeed = MaxSpeedX/2;
            yAxis.m_MaxSpeed = MaxSpeedY/2;
            isAiming = true;
            }
        else {
            xAxis.m_MaxSpeed = MaxSpeedX; //If Aim button not pressed - make sensetivity X1
            yAxis.m_MaxSpeed = MaxSpeedY;
            isAiming = false;
        }
        
        //bool isAiming = Input.GetButton("Fire2"); 
        animator.SetBool(isAimingParam, isAiming);//Translate isAiming bool to camera animator

        yAxis.Value = Mathf.Clamp(yAxis.Value, -70.0f, 70.0f); //Clamp Camera Y

        xAxis.Update(Time.deltaTime); //Update axis values
        yAxis.Update(Time.deltaTime);

        CameraLookAt.eulerAngles = new Vector3(yAxis.Value, xAxis.Value, 0); //Rotate CameraLookAt gameObject with mouse imput
        CameraLookAt.transform.position = Player.transform.position; //Set CameraLookAt position as Player Position
    }

    public void InvertY()
    {
        yAxis.m_InvertInput = !yAxis.m_InvertInput;
    }
}
