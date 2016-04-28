using UnityEngine;
using System.Collections;

public class ChukkoInAir : MonoBehaviour
{
    bool isCollided = false;
    float time = 0.0f;
    public Quaternion rotation;

    public int RotateCase
    {
        get; set;
    }

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("OnCollisionEnter");
        isCollided = true;
        Vector3 dir = transform.TransformDirection(Vector3.forward);
        if (col.transform.GetComponent<Rigidbody>())
            col.transform.GetComponent<Rigidbody>().AddRelativeForce(dir * 2, ForceMode.Impulse);

        GetComponent<Rigidbody>().AddRelativeForce(Vector3.up / 2, ForceMode.Impulse);
    }

    public void Start()
    {
        time = 0.0f;
    }

    public void Update()
    {
        /*if (isCollided)
        {
            time += Time.deltaTime;
        }*/
        time += Time.deltaTime;

        switch (RotateCase)
        {
            case 0:
                transform.Rotate(Vector3.up, 15);
                break;
            case 1:
                transform.Rotate(Vector3.forward, 15);
                break;
            case 2:
                transform.Rotate(Vector3.down, 15);
                break;
            case 3:
                transform.Rotate(Vector3.back, 15);
                break;
            case 4:
                transform.Rotate(Vector3.left, 15);
                break;
            case 5:
                transform.Rotate(Vector3.right, 15);
                break;
            case 6:
                transform.Rotate(Vector3.up, 15);
                transform.Rotate(Vector3.forward, 15);
                break;
            case 7:
                transform.Rotate(Vector3.forward, 15);
                transform.Rotate(Vector3.up, 15);
                break;
            case 8:
                transform.Rotate(Vector3.down, 15);
                transform.Rotate(Vector3.forward, 15);
                break;
            case 9:
                transform.Rotate(Vector3.back, 15);
                transform.Rotate(Vector3.forward, 15);
                break;
            case 10:
                transform.Rotate(Vector3.left, 15);
                transform.Rotate(Vector3.forward, 15);
                break;
            case 11:
                transform.Rotate(Vector3.right, 15);
                transform.Rotate(Vector3.forward, 15);
                break;
            case 12:
                transform.Rotate(Vector3.up, 15);
                transform.Rotate(Vector3.back, 15);
                break;
            case 13:
                transform.Rotate(Vector3.back, 15);
                transform.Rotate(Vector3.up, 15);
                break;
            case 14:
                transform.Rotate(Vector3.down, 15);
                transform.Rotate(Vector3.back, 15);
                break;
            case 15:
                transform.Rotate(Vector3.back, 15);
                transform.Rotate(Vector3.back, 15);
                break;
            case 16:
                transform.Rotate(Vector3.left, 15);
                transform.Rotate(Vector3.back, 15);
                break;
            case 17:
                transform.Rotate(Vector3.right, 15);
                transform.Rotate(Vector3.back, 15);
                break;
        }

        if (time >= 1.0f)
        {
            Camera.main.gameObject.GetComponent<SmoothFollow>().enabled = false;
            Camera.main.gameObject.GetComponent<SmoothFollow>().target = null;
            Camera.main.transform.localPosition = Vector3.zero;
            Camera.main.transform.rotation = rotation;
            Destroy(this);
        }
    }
}
