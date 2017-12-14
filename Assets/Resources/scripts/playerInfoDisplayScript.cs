using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerInfoDisplayScript : MonoBehaviour {

    private Vector3 displayOffset;

    public Texture maxHealthBarTexture;
    public Texture maxManaBarTexture;
    public Texture curHealthBarTexture;
    public Texture curManaBarTexture;

    private playerResourceManagerScript pr;

	// Use this for initialization
	void Start () {
        displayOffset = new Vector3(0, 1, 0);
        pr = GetComponent<playerResourceManagerScript>();
	}
	
	// Update is called once per frame
	void Update () {

	}

    void OnGUI()
    {
        //calculate position of info display
        Vector3 screenPosition = Camera.main.WorldToScreenPoint(transform.position + displayOffset);

        //draw maxhealth bar
        Rect rect = new Rect(screenPosition.x - 50, Screen.height - screenPosition.y - 5, 100, 10);
        GUI.DrawTexture(rect, maxHealthBarTexture);

        //draw currenthealth bar
        rect.width -= 100 - pr.getResource(1);
        GUI.DrawTexture(rect, curHealthBarTexture);

        //draw maxmana bar
        rect = new Rect(screenPosition.x - 50, Screen.height - screenPosition.y + 5, 100, 10);
        GUI.DrawTexture(rect, maxManaBarTexture);

        //draw currentmana bar
        rect.width -= 100 - pr.getResource(2);
        GUI.DrawTexture(rect, curManaBarTexture);


    }
}
