using UnityEngine;
using System.Collections;

public enum CrewTitle {
	Engineer = 1,
	Medic,
	Captain,
	Pilot,
	Cook,
	Security
}

public enum CrewName {
	Suzume = 1,
	Cerys,
	AttleBrox,
	Saira,
	Jorji,
	AnaMarie
}

public static class XMLUtils
{
	// String comparison takes too long. Need a better solution
	public static int TitleToID (CrewTitle title)
	{
		switch (title)
		{
		case CrewTitle.Engineer:
			return (1);
		case CrewTitle.Medic:
			return (2);
		case CrewTitle.Captain:
			return (3);
		case CrewTitle.Pilot:
			return (4);
		case CrewTitle.Cook:
			return (5);
		case CrewTitle.Security:
			return (6);
		default:
			return (-1);

		}
	}


	public static int NameToID (CrewName name)
	{
		switch (name)
		{
		case CrewName.Suzume:
			return (1);
		case CrewName.Cerys:
			return (2);
		case CrewName.AttleBrox:
			return (3);
		case CrewName.Saira:
			return (4);
		case CrewName.Jorji:
			return (5);
		case CrewName.AnaMarie:
			return (6);
		default:
			return (-1);

		}
	}
}

