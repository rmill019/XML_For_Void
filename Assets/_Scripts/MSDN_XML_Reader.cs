using System.Collections;
using System.Collections.Generic;
using System.Xml;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;

public class MSDN_XML_Reader : MonoBehaviour {

	private Text xmlText;

	StringBuilder output = new StringBuilder();

	string xmlString = 
		@"<?xml version='1.0'?>
		<!-- This is a sample XML document -->
		<Items>
			<Item>test with a child element <more/> stuff</Item>
		</Items>";

	// Use this for initialization
	void Start () {
		
		// Grab Unity's Text UI Object
		xmlText = GameObject.Find ("xmlText").GetComponent<Text>();

//		// Create an XmlReader -- This reads xml in the form as a string like the one above --
//		XmlReader reader = XmlReader.Create (new StringReader(xmlString));

		// Create an XmlTextReader -- Reads from a file --
		//XmlTextReader reader = new XmlTextReader ("Assets\\Resources\\test.xml");
		XmlTextReader reader = new XmlTextReader ("Assets\\Resources\\employees.xml");
		XmlTextReader bookstoreReader = new XmlTextReader ("Assets\\Resources\\bookstore.xml");

		XmlWriterSettings ws = new XmlWriterSettings ();
		ws.Indent = true;
		XmlWriter writer = XmlWriter.Create (output, ws); // output argument is the stream to which you want to write, we declared a StringBuilder earlier

//		// Parse the file and display each of the nodes for reader
//		while (reader.Read ())
//		{
//			switch (reader.NodeType)
//			{
//			case XmlNodeType.Element:
//				writer.WriteStartElement (reader.Name);
//				break;
//			case XmlNodeType.Text:
//				writer.WriteString (reader.Value);
//				break;
//			case XmlNodeType.XmlDeclaration:
//			case XmlNodeType.ProcessingInstruction:
//				writer.WriteProcessingInstruction (reader.Name, reader.Value);
//				break;
//			case XmlNodeType.Comment:
//				writer.WriteComment (reader.Value);
//				break;
//			case XmlNodeType.EndElement:
//				writer.WriteFullEndElement ();
//				break;
//			}
//		}

		bookstoreReader.ReadToFollowing ("book");
		bookstoreReader.MoveToFirstAttribute ();
		string genre = bookstoreReader.Value;
		output.AppendLine ("The genre value: " + genre);

		bookstoreReader.ReadToFollowing ("title");
		string title = bookstoreReader.ReadElementContentAsString();
		output.AppendLine ("Content of the title element: " + title);

		bookstoreReader.ReadToFollowing ("price");
		float price = bookstoreReader.ReadElementContentAsFloat();
		output.AppendLine ("Price of " + title + " is $" + price); 
		xmlText.text = output.ToString ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
