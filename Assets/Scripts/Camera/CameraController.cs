using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    [SerializeField]
    private GameObject camera1;
    [SerializeField]
    private GameObject camera2;

    public int Click;
    public float resetTimer;

    private bool cameraActive;
    // Start is called before the first frame update
    void Start()
    {
        cameraActive = true;
        camera1.SetActive(true);
        camera2.SetActive(false); 
    }
    // Update is called once per frame
    void Update()
    {
        if (DoubleClick() == true && cameraActive == true)
        {
            Debug.Log("A");
            camera1.SetActive(false);
            camera2.SetActive(true);
            cameraActive = false;
        }
        else if (DoubleClick() == true && cameraActive == false)
        {
            camera1.SetActive(true);
            camera2.SetActive(false);
            cameraActive = true;

        }
        StartCoroutine(Wait());
    }
    IEnumerator ResetClickTimes()
    {
        yield return new WaitForSeconds(resetTimer);
        Click = 0;
    }
    public bool DoubleClick()
    {
        if (Input.GetMouseButtonUp(0))
        {
            StartCoroutine ("ResetClickTimes");
            Click++;
        }
        if (Click >= 2)
        {
            //doble click
            return true;
        }
        else
        {
            return false;
        }
    }
    IEnumerator Wait()
    {
        yield return new WaitForSeconds(2);
    }
}
