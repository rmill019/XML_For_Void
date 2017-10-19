using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Culprit{

	public int id;
	public string name;
	public string title;
	public int age;
	public string description;

	// Default constructor
	public Culprit ()
	{
		id = 0;
		name = "No name";
		title = "Basic Job";
		age = 33;
		description = "No given Description";
	}

	// Constructor that specifies all fields
	public Culprit (int cID, string cName, string cTitle, int cAge, string cDesc)
	{
		id = cID;
		name = cName;
		title = cTitle;
		age = cAge;
		description = cDesc;
	}
}
