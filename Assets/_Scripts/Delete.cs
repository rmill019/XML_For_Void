using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Delete : MonoBehaviour {

	public List<int> myInts;

	// Use this for initialization
	void Start () {
		myInts = new List<int> ();
		myInts.Add (1);
		myInts.Add (2);

		int randomID = 2;
		// Cycle through ID's that have already been chosen so that we don't pick a contradicting crew member
		while (myInts.Contains (randomID))
		{
			randomID = Random.Range (1, 7);
		}
		myInts.Add (randomID);
		foreach (int id in myInts)
		{
			print ("ID's we have: " + id);
		}
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
