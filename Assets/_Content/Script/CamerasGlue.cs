using Cinemachine;
using UnityEngine;
//[RequireComponent(typeof(CinemachineFreeLook))]
public class CamerasGlue : MonoBehaviour
{
	public GameObject Freelook;
	public GameObject Aim;
    public bool aiming;

    private CinemachineFreeLook freeLookCam;
    private CinemachineFreeLook aimCam;


	void Awake ()
    {
	freeLookCam = Freelook.GetComponent<CinemachineFreeLook>();
	aimCam = Aim.GetComponent<CinemachineFreeLook>();
	}

    void Update()
    {
        if (Input.GetButton("Fire2")) {
            aiming = true;
        }
        else {
            aiming = false;
        }


        if (aiming == true) {
            freeLookCam.m_XAxis.Value = aimCam.m_XAxis.Value;
            freeLookCam.m_YAxis.Value = aimCam.m_YAxis.Value;
        }
        else {
            aimCam.m_XAxis.Value = freeLookCam.m_XAxis.Value;
            aimCam.m_YAxis.Value = freeLookCam.m_YAxis.Value;
        }
        
    }
}
