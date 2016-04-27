using UnityEngine;
using System.Collections;
using System;

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


    public void Update()
    {
        if (Input.GetMouseButton(0))
        {
            transform.position = new Vector3(transform.position.x + (Input.GetAxis("Mouse X") * Time.deltaTime), transform.position.y, transform.position.z + (Input.GetAxis("Mouse Y") * Time.deltaTime));
            transform.Rotate(Vector3.up, Input.GetAxis("Mouse X"));
        }

        if (mouseDown)
        {
            pressTime += Time.deltaTime;
        }
        else if (!mouseDown)
        {
            /*if (startPosition != Vector3.zero)
            {
                transform.position = Vector3.Slerp(transform.position, startPosition, 3.5f * Time.deltaTime);
                if (transform.position == startPosition)
                {
                    ChukkoReadyToLounch = true;
                }
            }*/
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
        transform.GetComponent<Rigidbody>().mass = 0.5f;
        transform.GetComponent<Rigidbody>().AddForceAtPosition((Vector3.forward * ((distance / pressTime) * 40)), transform.position);
        Camera.main.gameObject.GetComponent<SmoothFollow>().target = transform;
        Camera.main.gameObject.GetComponent<SmoothFollow>().enabled = true;
        transform.gameObject.AddComponent<ChukkoInAir>();
        transform.GetComponent<ChukkoInAir>().rotation = Camera.main.transform.rotation;
        Destroy(this);
    }
}
