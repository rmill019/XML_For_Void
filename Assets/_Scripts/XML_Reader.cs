using System.Collections;
using System.Collections.Generic;
//using System.Linq;
using System.Text;
using System.Xml;
using System.Xml.Linq;
using UnityEngine;
using UnityEngine.UI;

public class XML_Reader : MonoBehaviour {

	private Text xmlOutput;

	// Use this for initialization
	void Start () {
		// Find and assign the Text object we will be displaying the text on
		xmlOutput = GameObject.Find ("xmlText").GetComponent<Text>();
		xmlOutput.text = "";

		// USING XElement CLASS
		// Loading the xml file. These are used for all of the following examples
		XElement xelement = XElement.Load("Assets\\Resources\\employees.xml");
		IEnumerable<XElement> employees = xelement.Elements ();
		// Read and print the entire XML
		foreach (var employee in employees)
		{
			xmlOutput.text += employee;
		}

//		// USING XDocument CLASS
//		// Loading the xml file.
//		XDocument xDocument = XDocument.Load("Assets\\Resources\\employees.xml");
//		IEnumerable<XElement> employees = xDocument.Elements ();
//		// Read and print the entire XML file
//		foreach (var employee in employees)
//		{
//			xmlOutput.text += employee;
//		}

		//===========================================
		// Specific Examples Below
		//===========================================

//		//Access and print multiple Elements using LINQ to XML
//		xmlOutput.text += "List of all Employee names and their ID Numbers :";
//
//		foreach (var employee in employees)
//		{
//			xmlOutput.text += "\n" + employee.Element ("Name").Value + ": " + employee.Element("EmpId").Value;
//		}

//		// Access and print a single Element using LINQ to XML
//		xmlOutput.text += "List of all Employee Names :";
//		foreach (var employee in employees)
//		{
//			xmlOutput.text += "\n" + employee.Element("Name").Value;
//		}

//		// Access all Elements having a Specific Attribute using LINQ to XML
//		// This uses querying in C# the specifics of this can be found online
//		// Note the casting in the where clause is necessary to make the query work
//		var name = from nm in xelement.Elements ("Employee")
//				where (string)nm.Element ("Sex") == "Female" &&  (int)nm.Element("EmpId") == 2
//		           select nm;
//		xmlOutput.text += "Details of Female Employees: " + "\n";
//		foreach (XElement xEle in name)
//		{
//			xmlOutput.text += xEle + "\n";
//		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
