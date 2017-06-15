using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour {
	public NejikoController nejiko;
	public Text scoreLabel;
	public LifePanel lifePanel;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		int score = CalcScore();
		scoreLabel.text = "Score : " + score + "m";
		
		lifePanel.UpdateLife(nejiko.Life());
		
		if(nejiko.Life() <= 0){
			enabled = false;
			
			Invoke("ReturnToTitle", 2.0f);
		}
	}
	
	int CalcScore(){
		return (int)nejiko.transform.position.z;
	}
	
	void ReturnToTitle(){
		Application.LoadLevel("Title");
	}
}
