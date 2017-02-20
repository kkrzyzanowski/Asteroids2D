using UnityEngine;
using System.Collections;

public class AsteroidsMove : MonoBehaviour {

    public  float speed;
    float moveDirection;
    public Vector2 spawnPositions;
     private EnumDirections enumobj;
     private bool move = false;
    EnumDirections dir;
	// Use this for initialization
	void Start () {
        dir = new EnumDirections();
        moveDirection = Random.Range(-2.0f, 2.0f);
       

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        MovingAsteroids();
       }
  
    void MovingAsteroids()
    {


        if (transform.position.y == - spawnPositions.y || (move && dir.getDirection()==EnumDirections.direction.UP))
        {
            transform.Translate(moveDirection * speed * Time.deltaTime, speed * Time.deltaTime, 0.0f);
            dir.setDirection(EnumDirections.direction.UP);
            
        }

        else if (transform.position.y == spawnPositions.y || (move && dir.getDirection() == EnumDirections.direction.DOWN))
        {
            transform.Translate(moveDirection * speed * Time.deltaTime, -speed * Time.deltaTime, 0.0f);
            dir.setDirection(EnumDirections.direction.DOWN);
        }
        else if (transform.position.x == spawnPositions.x || (move && dir.getDirection() == EnumDirections.direction.LEFT))
           {
              transform.Translate (-speed * Time.deltaTime,moveDirection * speed * Time.deltaTime, 0.0f);
            dir.setDirection(EnumDirections.direction.LEFT);
        }
               
         else if(transform.position.x == -spawnPositions.x || (move && dir.getDirection() == EnumDirections.direction.RIGHT))
          {
             transform.Translate(speed * Time.deltaTime, moveDirection * speed * Time.deltaTime, 0.0f);
            dir.setDirection(EnumDirections.direction.RIGHT);
        }
        move = true;
             
      }
    
}
