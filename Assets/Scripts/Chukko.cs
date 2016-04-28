using UnityEngine;
using System.Collections;
using UnityEngine.iOS;

public class Chukko : MonoBehaviour
{
    [HideInInspector]
    public Vector3 startPosition;
    [HideInInspector]
    public Vector3 endPosition;
    public float distance;
    public float pressTime;

    private bool mouseDown = false;
    private bool ChukkoReadyToLounch;

    Touch fingTouch;

    public void Update()
    {

        if (!Application.isEditor)
        {
            if (fingTouch.tapCount > 0)
            {
                if (fingTouch.phase == TouchPhase.Began)
                {

                    Debug.Log("TouchPhase = Began; \n touch position = (" + fingTouch.position.x + ", " + fingTouch.position.y + ") ");

                    SetStartSettings();
                    mouseDown = true;
                }
                else if (fingTouch.phase == TouchPhase.Moved)
                {
                    Debug.Log("TouchPhase = Moved");
                    transform.position = new Vector3(transform.position.x + (fingTouch.position.x * Time.deltaTime), transform.position.y, transform.position.z + (fingTouch.position.x * Time.deltaTime));
                    transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));

                }
                else if (fingTouch.phase == TouchPhase.Ended)
                {
                    Debug.Log("TouchPhase = Ended");
                    SetEndSettings();
                    mouseDown = false;
                }
            }
        }
        else
        {
            if (Input.GetMouseButton(0))
            {
                transform.position = new Vector3(transform.position.x + (Input.GetAxis("Mouse X") * Time.deltaTime), transform.position.y, transform.position.z + (Input.GetAxis("Mouse Y") * Time.deltaTime));
                transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
            }
        }

        if (mouseDown)
        {
            pressTime += Time.deltaTime;
        }
        else if (!mouseDown)
        {
            
        }
    }

    

    
    public void OnMouseDown()
    {
        SetStartSettings();
        Debug.Log("OnMouseDown");
    }

    public void OnMouseUp()
    {
        Debug.Log("OnMouseUp");
        SetEndSettings();
    }
    
    public void SetStartSettings()
    {
        startPosition = transform.position;
        distance = 0.0f;
        mouseDown = true;
        pressTime = 0.0f;
    }

    public void SetEndSettings()
    {
        endPosition = transform.position;
        distance = Vector3.Distance(startPosition, endPosition);
        mouseDown = false;
        transform.SetParent(null);
        transform.gameObject.AddComponent<Rigidbody>();
        Vector3 RandomizedDirection = transform.TransformDirection(Vector3.forward);
        transform.GetComponent<Rigidbody>().mass = 0.1f;
        transform.GetComponent<Rigidbody>().AddForceAtPosition((Vector3.forward * ((distance / pressTime) * 5)), transform.position);
        Camera.main.transform.GetComponent<SmoothFollow>().target = transform;
        Camera.main.transform.GetComponent<SmoothFollow>().enabled = true;
        transform.gameObject.AddComponent<ChukkoInAir>();
        transform.gameObject.GetComponent<ChukkoInAir>().RotateCase = Random.Range(0, 17);
        transform.GetComponent<ChukkoInAir>().rotation = Camera.main.transform.rotation;
        Destroy(this);
    }
}
