using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToggleButton : MonoBehaviour {

	public GameObject[] xmlSO;

	// Use this for initialization
	void Start () {
		xmlSO = GameObject.FindGameObjectsWithTag ("xmlSO");
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	 
	public void PopulateTextBoxes ()
	{
		foreach (var xSO in xmlSO)
		{
			xSO.GetComponent<Void_XML_Reader> ().xmlText.text = "";
			Culprit culpToWrite = xSO.GetComponent<Void_XML_Reader>().ReturnCulpritInfo(xSO.GetComponent<Void_XML_Reader>().idToSearchFor);
			xSO.GetComponent<Void_XML_Reader> ().xmlText.text += "ID: " + culpToWrite.id + "\n"
				+ "Name: " + culpToWrite.name + "\n"
				+ "Title: " + culpToWrite.title + "\n"
				+ "Age: " + culpToWrite.age + "\n"
				+ "Description: " + culpToWrite.description;

		}
		
	}
}
