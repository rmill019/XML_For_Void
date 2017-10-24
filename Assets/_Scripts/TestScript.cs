using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestScript : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
		print ("ID equals: " + XMLUtils.TitleToID(CrewTitle.Engineer));
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
