/************************************************************
************************************************************/
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/************************************************************
************************************************************/

/**************************************************
**************************************************/
public class StageGenerator : MonoBehaviour {
	/****************************************
	****************************************/
	const int StageTipSize = 30;
	int currentTipIndex = 0; // 生成済みTipのindex
	
	public Transform character; // target character
	public GameObject[] stageTips;
	public int startTipIndex; // 自動生成開始index:1
	public int preInstantiate; // 生成:先読み個数:5
	public List<GameObject> generatedStageList = new List<GameObject>(); // 生成済みStageTip保持List
	
	
	/****************************************
	****************************************/
	void Start () {
		currentTipIndex = startTipIndex - 1;
		UpdateStage(preInstantiate);
	}
	
	// Update is called once per frame
	void Update () {
		int charaPositionIndex = (int)(character.position.z/StageTipSize);
		
		if(currentTipIndex < charaPositionIndex + preInstantiate){
			UpdateStage(charaPositionIndex + preInstantiate);
		}
	}
	
	/******************************
	指定Indexまでのステージチップを生成、管理下に置く.
	******************************/
	void UpdateStage(int toTipIndex){
		if(toTipIndex <= currentTipIndex) return;
		
		for(int i = currentTipIndex + 1; i <= toTipIndex; i++){
			GameObject stageObject = GenerateStage(i);
			
			generatedStageList.Add(stageObject);
		}
		
		while(preInstantiate + 2 < generatedStageList.Count) DestroyOldestStage();
		
		currentTipIndex = toTipIndex;
	}
	
	GameObject GenerateStage(int tipIndex){
		int nextStageTip = Random.Range(0, stageTips.Length);
		
		GameObject stageObject = (GameObject)Instantiate(
			stageTips[nextStageTip],
			new Vector3(0, 0, tipIndex * StageTipSize),
			Quaternion.identity
		);
		
		return stageObject;
	}
	
	void DestroyOldestStage(){
		GameObject oldStage = generatedStageList[0];
		generatedStageList.RemoveAt(0);
		Destroy(oldStage);
	}
}
