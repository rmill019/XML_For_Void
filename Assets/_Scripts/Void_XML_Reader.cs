using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Void_XML_Reader : MonoBehaviour {
	
	private Text xmlText;
	public string nameToFind;

	private StringBuilder output = new StringBuilder ();

	// Use this for initialization
	void Start () {
		// Grabbing the Text UI object in Unity
		xmlText = GameObject.Find ("xmlText").GetComponent<Text> ();
		xmlText.text = " ";


		FindByName (nameToFind);
	}

	// Keep as void or return a string?
	void FindByName (string cName)
	{
		string nameToPrint = "Not found";

		XmlTextReader culpritReader = new XmlTextReader ("Assets\\Resources\\culprits.xml");
		XmlWriterSettings ws = new XmlWriterSettings ();
		XmlWriter writer = XmlWriter.Create (output, ws);

		culpritReader.MoveToContent ();

		while (culpritReader.Read ())
		{
			culpritReader.ReadToDescendant ("culprit");
			culpritReader.ReadToFollowing ("name");
			nameToPrint = culpritReader.ReadElementContentAsString ();
			if (nameToPrint == cName)
			{
				xmlText.text += nameToPrint;
				break;
			} 
			else
			{
				culpritReader.Skip ();
			}
		}
	}
	

}
