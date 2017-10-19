using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Void_XML_Reader : MonoBehaviour {
	
	public Text xmlText;
	public int idToSearchFor;
	public string nameToFind;
	public string xmlFileToRead;

	private StringBuilder output = new StringBuilder ();

	// Use this for initialization
	void Start () {
		// Grabbing the Text UI object in Unity
		//xmlText = GameObject.Find ("xmlText").GetComponent<Text> ();
		xmlText.text = " ";

		//FindByName (idToSearchFor);
		Culprit targetCulprit = ReturnCulpritInfo (idToSearchFor);
		xmlText.text += "ID: " + targetCulprit.id + "\n" +
						"Name: " + targetCulprit.name + "\n" +
						"Title: " + targetCulprit.title + "\n" +
						"Age: " + targetCulprit.age + "\n" +
						"Description: " + targetCulprit.description + "\n";
	}



	// Keep as void or return a string?
	void FindByName (int cID)
	{
		int idToPrint = 0;
		//string nameToPrint = "Not found";


		XmlTextReader culpritReader = new XmlTextReader ("Assets\\Resources\\" + xmlFileToRead);
		XmlWriterSettings ws = new XmlWriterSettings ();
		XmlWriter writer = XmlWriter.Create (output, ws);

		culpritReader.MoveToContent ();

		while (culpritReader.Read ())
		{
			culpritReader.ReadToDescendant ("culprit");
			culpritReader.ReadToFollowing ("id");
			idToPrint = culpritReader.ReadElementContentAsInt ();
			if (idToPrint == cID)
			{
				int myId = culpritReader.ReadElementContentAsInt ();
				//xmlText.text += idToPrint.ToString();
				break;
			} 
			else
			{
				culpritReader.Skip ();
			}
		}

		culpritReader.Close ();
	}



	Culprit ReturnCulpritInfo (int idNumber)
	{
		int intToCompare = 0;
		//Declare new culprit that will be returned once filled out with relevant data
		Culprit culpritToReturn = new Culprit ();

		XmlReader culpritReader = XmlReader.Create ("Assets\\Resources\\" + xmlFileToRead);
		XmlWriterSettings ws = new XmlWriterSettings ();
		XmlWriter writer = XmlWriter.Create (output, ws);

		culpritReader.MoveToContent();

		while (culpritReader.Read ())
		{
			culpritReader.ReadToDescendant ("culprit");
			culpritReader.ReadToFollowing ("id");
			// If the id in the xml matches the given parameter argument then gather information to 
			// stated culprit to return.
			intToCompare = culpritReader.ReadElementContentAsInt();
			if (intToCompare == idNumber)
			{
				// Messed up by trying to call culpritReader.ReadElementContentAsInt() again and it didn't work. Why not?
				culpritToReturn.id = intToCompare;
				culpritReader.ReadToNextSibling ("name");
				culpritToReturn.name = culpritReader.ReadElementContentAsString ();
				culpritReader.ReadToNextSibling ("title");
				culpritToReturn.title = culpritReader.ReadElementContentAsString ();
				culpritReader.ReadToNextSibling ("age");
				culpritToReturn.age = culpritReader.ReadElementContentAsInt ();
				culpritReader.ReadToNextSibling ("description");
				culpritToReturn.description = culpritReader.ReadElementContentAsString ();
				break;
			}
			else
			{
				culpritReader.Skip ();
			}
			
		}
		culpritReader.Close ();
		return culpritToReturn;
	}
}
