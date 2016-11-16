using UnityEngine;
using System.Collections;

public class satelliteRotation : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        GetComponent<Rigidbody>().angularVelocity = new Vector3(0, 1.0f, 0);
    }

}
