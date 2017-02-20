using UnityEngine;
using System.Collections;

public class BoundaryCollision : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void onTriggerExit2D (Collider2D other)
    {
        if(other.tag == "Asteroid")
        {
            Destroy(other.gameObject);
        }
    }
}
