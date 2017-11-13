using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.IO;
using System.Text;
using LitJson;


public class Void_JSON_Reader : MonoBehaviour {
	
	// Textboxes for displaying information
	public Text					murdererInfo;
	public Text					murderVictimInfo;
	public Text 				unconsciousVictimInfo;
	public Text					selectedClues;

	public TextAsset 			JSONAsset;
	public TextAsset 			JSONClueAsset;
	public int 					idToSearchFor;
	public string 				nameToFind;
	public string 				JSONFileToRead;
	public List<string> 		murdererClues;

	private StringBuilder 		output = new StringBuilder ();

	// Needs to be made static in this scenario because all VOID_JSON_Reader objects should know what numbers are off limits.
	private static List<int> 	_idAlreadyChosen;
	private static int 			_murdererID;


	// Use this for initialization
	void Start () {

		// Initialize all Lists
		_idAlreadyChosen = new List<int> ();
	}
	
	// Update is called once per frame
	void Update () {
		
	}


	// Function that is in charge of picking the culprit and grabbing their corresponding clues
	public void AssignCulpritAndClues()
	{
		// Find corresponding Text to fill
		Text murdererTextBox = GameObject.Find ("MurdererInfo").GetComponent <Text>();
		Text clueTextBox = GameObject.Find ("Clues").GetComponent <Text>();
		Culprit mainCulp = new Culprit ();

		JsonData data = JsonMapper.ToObject (JSONAsset.text);
		// Pick random id to determine the murderer
		int randomID = Random.Range (1, 3);
		_idAlreadyChosen.Add (randomID);
		_murdererID = randomID;
		print (randomID);
		// Indexing starts at 0 so we put id - 1
		// Start filling out the culprits information
		// Parse the string returned from data to an int.
		mainCulp.id = System.Int32.Parse(data["crew"][randomID - 1]["id"].ToString());
		mainCulp.title = data["crew"][randomID - 1]["title"].ToString();
		mainCulp.name = data ["crew"] [randomID - 1] ["name"].ToString ();
		mainCulp.description = data ["crew"] [randomID - 1] ["description"].ToString();

		// Fill out corresponding TextBox with Information
		murdererTextBox.text = "ID: " + mainCulp.id + "\n"
		+ "Title: " + mainCulp.title + "\n"
		+ "Name: " + mainCulp.name + "\n"
		+ "Description: " + mainCulp.description;

		// Fill out the corresponding TextBox for clues with the information and
		// Start adding the clues to the list murderClues
		for (int i = 1; i < 6; i++)
		{
			string clueNumber = "clue" + i.ToString ();
			murdererClues.Add(data["crew"][randomID - 1][clueNumber].ToString());
			clueTextBox.text += "Clue " + i + ": " + murdererClues [i - 1] + "\n";
		}
	}


	public void ChooseVictim(Text textboxToPopulate)
	{
		JsonData data = JsonMapper.ToObject (JSONAsset.text);
		// Pick random number to see what id we will be using to grab that crews information from the JSON file
		int randomID = Random.Range (1, 7);
		// Pick a new random number until we get one that has not already been used to pick a new member.
		while (_idAlreadyChosen.Contains (randomID))
		{
			randomID = Random.Range (1, 7);
		}
		// Add the randomID chosen to the _idAlreadyChosen List so that we can keep track of Crew Members we have already utilized
		_idAlreadyChosen.Add (randomID);

		CrewMember currentCrew = new CrewMember ();
		currentCrew.id = System.Int32.Parse (data ["crew"] [randomID - 1] ["id"].ToString());
		currentCrew.title = data ["crew"] [randomID - 1] ["title"].ToString ();
		currentCrew.name = data ["crew"] [randomID - 1] ["name"].ToString ();
		currentCrew.description = data ["crew"] [randomID - 1] ["description"].ToString ();

		textboxToPopulate.text = "ID: " + currentCrew.id + "\n"
		+ "Title: " + currentCrew.title + "\n"
		+ "Name: " + currentCrew.name + "\n"
		+ "Description: " + currentCrew.description;
	}


	public void ResetTextBoxes ()
	{
		GameObject[] allTextBoxes = GameObject.FindGameObjectsWithTag ("InformationTag");

		foreach (GameObject tbox in allTextBoxes)
		{
			tbox.GetComponent<Text>().text = "";
		}

		// Reset the list of id's already selected and _murdererID
		_idAlreadyChosen.Clear();
		_murdererID = 0;
	}
}
