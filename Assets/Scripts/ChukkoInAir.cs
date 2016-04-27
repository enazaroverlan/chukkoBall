using UnityEngine;
using System.Collections;

public class ChukkoInAir : MonoBehaviour
{
    bool isCollided = false;
    float time = 0.0f;
    public Quaternion rotation;

    public void OnCollisionEnter(Collision col)
    {
        Debug.Log("OnCollisionEnter");
        isCollided = true;
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
