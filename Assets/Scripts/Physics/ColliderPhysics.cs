using UnityEngine;
using System.Collections;

public class ColliderPhysics : MonoBehaviour
{
    public Rigidbody rig;



    public void Start()
    {
        rig = GetComponent<Rigidbody>();
    }


    public void OnCollisionEnter(Collision col)
    {
        rig.AddRelativeForce(Vector3.back, ForceMode.Impulse);
    }
}
