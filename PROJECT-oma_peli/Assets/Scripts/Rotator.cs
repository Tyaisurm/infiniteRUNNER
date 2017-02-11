using UnityEngine;
using System.Collections;

public class Rotator : MonoBehaviour
{
    //public float tumble;

    void Update()
    {

        //GetComponent<Rigidbody>().angularVelocity = Random.insideUnitSphere*tumble;
        transform.Rotate(new Vector3(15, 30, 45) * Time.deltaTime);
    }
}
