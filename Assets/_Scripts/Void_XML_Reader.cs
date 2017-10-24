using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class Void_XML_Reader : MonoBehaviour {
	
	public Text xmlText;
	public TextAsset xmlAsset;
	public int idToSearchFor;
	public string nameToFind;
	public string xmlFileToRead;

	private StringBuilder output = new StringBuilder ();
	// Needs to be made static in this scenario because all VOID_XML_Reader objects should know what numbers are off limits.
	private static List<int> _idAlreadyChosen;

	// Use this for initialization
	void Start () {
		_idAlreadyChosen = new List<int> ();
		_idAlreadyChosen.Add (0);
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
		// close xmlReader and xmlWriter (Do we need to flush them?)
		culpritReader.Close ();
		writer.Close ();
		return culpritToReturn;
	}


	// Is more memory being used if we keep pressing Pick over and over
	public void PickRandomCrewMember ()
	{
		Text murdererTextBox = xmlText;
		murdererTextBox.text = "";
		int randomID = Random.Range (1, 7);
		// Pick a new random number until we get one that has not already been used to pick a new member.
		while (_idAlreadyChosen.Contains (randomID))
		{
			randomID = Random.Range (1, 7);
		}
		// Add the randomID chosen to the _idAlreadyChosen List so that we can keep track of Crew Members we have already utilized
		_idAlreadyChosen.Add (randomID);

		//print ("RandomID: " + randomID);

		// Set up XMLReader
		Culprit culpritToReturn = new Culprit ();
		//XmlReader culpritReader = XmlReader.Create ("Assets\\Resources\\" + xmlFileToRead);
		XmlReader culpritReader = XmlReader.Create(new StringReader(xmlAsset.text));
		XmlWriterSettings ws = new XmlWriterSettings ();
		XmlWriter writer = XmlWriter.Create (output, ws);

		culpritReader.MoveToContent ();
		// Read the xml file while there are still elements to read
		while (culpritReader.Read ())
		{
			culpritReader.ReadToDescendant ("crewMember");
			culpritReader.ReadToFollowing ("id");
			int intToCompare = culpritReader.ReadElementContentAsInt ();
			if (intToCompare == randomID)
			{
				culpritToReturn.id = intToCompare;
				culpritReader.ReadToNextSibling ("title");
				culpritToReturn.title = culpritReader.ReadElementContentAsString ();
				culpritReader.ReadToNextSibling ("name");
				culpritToReturn.name = culpritReader.ReadElementContentAsString ();
				culpritReader.ReadToNextSibling ("description");
				culpritToReturn.description = culpritReader.ReadElementContentAsString ();
				break;
			}
			else
			{
				culpritReader.Skip ();
			}
		}

		// close xmlReader and xmlWriter
		culpritReader.Close ();
		writer.Close ();
		// Return culprit information to the appropriate textBox
		murdererTextBox.text += "ID: " + culpritToReturn.id + "\n"
		+ "Title: " + culpritToReturn.title + "\n"
		+ "Name: " + culpritToReturn.name + "\n"
		+ "Description: " + culpritToReturn.description;
		
	}
}
