using UnityEngine;
using System.Collections;

public class DestroyOnTouch : MonoBehaviour {
    public GameObject explosion;
    public GameObject playerExplosion;
   
    private GameController gc;
    private int value;
	// Use this for initialization
	void Start () {
        GameObject go = GameObject.FindWithTag("GameController");
        if(go!=null)
        gc = go.GetComponent<GameController>();
        value = 10;
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}
    void OnTriggerEnter2D (Collider2D other)
    {
        if (other.tag == "Bullet")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            gc.UpdateScore(value);
            Instantiate(explosion, transform.position, transform.rotation);



        }
       
        
        if (other.tag == "Player")
        {
            Destroy(gameObject);
            Destroy(other.gameObject);
            Instantiate(explosion, other.transform.position, other.transform.rotation);
            gc.losing_life();
            gc.GameOver();
        }

        
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
