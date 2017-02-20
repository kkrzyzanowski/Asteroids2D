using UnityEngine;
using System.Collections;
[System.Serializable]

public class ShipControl : MonoBehaviour {
  
    public float speed;
    float translationHorizontal;
    float translationVertical;
    public float speedRotation;
    public GameObject bullet;
    public float delayShotTime;
    private float nextShotTime;
    public Transform shotSpawn;
    public float xMin, xMax, yMin, yMax;

	// Use this for initialization
	void Start () {
        speed = 5f;
        speedRotation = 90f;
        bullet.GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update () {
        
        if (Input.GetKey("f"))
        {
            Fire();
        }
    }
    void FixedUpdate()
    {
        //translationHorizontal = Input.GetAxis("Horizontal") * speed * Time.deltaTime;
        translationVertical = Input.GetAxis("Vertical") * speed * Time.deltaTime;
         transform.Translate(0.0f, translationVertical, 0f);
        Vector3 trans = transform.position;

        trans.x = Mathf.Clamp(transform.position.x, xMin, xMax);
        trans.y = Mathf.Clamp(transform.position.y, yMin, yMax);
        transform.position = trans;
        if (Input.GetKey(KeyCode.A)|| Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f, 0f, speedRotation * Time.deltaTime);

        }
        if (Input.GetKey(KeyCode.D)|| Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0f, 0f, -speedRotation * Time.deltaTime);
        }
      
    }
    void Fire()
    {
        if (Time.time > nextShotTime)
        {
           
            Instantiate(bullet, shotSpawn.position, shotSpawn.rotation);
            nextShotTime = Time.time + delayShotTime;
        }
    }
}
