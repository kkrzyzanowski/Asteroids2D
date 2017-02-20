using UnityEngine;
using System.Collections;

public class AsteroidsRotation : MonoBehaviour {
   
    public float rotationSpeed;
    
    float rotationrange;
	// Use this for initialization
	void Start () {

        rotationrange = Random.Range(0.0f, 90.0f);
	}
	
	// Update is called once per frame
	void Update () {
        //  transform.Rotate(0.0f, 0.0f, rotationrange * roatationSpeed * Time.deltaTime, Space.Self);
        transform.Rotate(Random.insideUnitSphere * rotationrange*rotationSpeed*Time.deltaTime);
	}
}
