using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

public class refreshingImages : MonoBehaviour {
    private Image[] lifeImage;
    int playerMaxLifes = 3;
    // Use this for initialization
    void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        removeImage();
	}
    void drawImages()
    {
        lifeImage = GetComponentsInChildren<Image>();
        for (int i = 0; i < playerMaxLifes; i++)
        {

            BoxCollider2D bc2d = lifeImage[i].GetComponent<BoxCollider2D>();

            Vector3 pos = bc2d.transform.position;
            pos.x = bc2d.transform.position.x * (i + 1);
            Instantiate(lifeImage[i], pos, bc2d.transform.rotation);
            lifeImage[i].gameObject.SetActive(Player.enabledImages[i]);
        }
        removeImage();
    }
    void removeImage()
    {
        for (int i = Player.lifes; i < playerMaxLifes; i++)
        {
            lifeImage[i].gameObject.SetActive(false);
            Player.enabledImages[i] = lifeImage[i].IsActive();
        }
    }
}
