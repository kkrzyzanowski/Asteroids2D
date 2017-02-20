using UnityEngine;
using System.Collections;

public class Shotting : MonoBehaviour {
    public float speed;
 
	
	void Update()
    {
        //rb2d.AddForce(transform.forward * speed * Time.deltaTime);
      transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
}
