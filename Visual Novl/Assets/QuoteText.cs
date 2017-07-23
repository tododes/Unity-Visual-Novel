using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class QuoteText : MonoBehaviour {

    private float radiant;
    private Text text;
    private Color color;
    private bool isFading;
	// Use this for initialization
	void Start () {
        radiant = 0f;
        color = new Color(0, 0, 0, 1);
        text = GetComponent<Text>();
	}
	
	// Update is called once per frame
	void Update () {
        //if (Input.GetKeyDown(KeyCode.Space) && !isFading){
            
        //}
        color.a = Mathf.Cos(radiant);
        if (color.a < 0f)
            color.a = 0f;
        text.color = color;
	}

    public void startColorFade(){
        if(!isFading)
            StartCoroutine(colorFade());
    }

    IEnumerator colorFade()
    {
        isFading = true;
        while(radiant < 3.14f){
            radiant += 31.4f * Time.deltaTime;
            yield return new WaitForSeconds(Time.deltaTime);
        }
        radiant = 0f;
        isFading = false;
    }
}
