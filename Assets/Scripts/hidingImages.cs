using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class hidingImages : MonoBehaviour {

    public Image[] lifeImage;
	// Use this for initialization
	void Start () {
        lifeImage = GetComponentsInChildren<Image>();
	}
	
	// Update is called once per frame
	void Update () {
       // removeimage();
	}
  
    void removeimage()
    {
        for (int i = 0; i < Player.maxLifes; i--)
        {
            if (i == Player.lifes)
            {
                Player.enabledImages[i] = false;
                lifeImage[i].enabled = false;
            }
        }
    }
}
