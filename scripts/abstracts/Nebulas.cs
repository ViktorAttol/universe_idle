using Godot;
using System;

/// <Summary>
/// Abstract class containing the common features of all Nebulas.
/// </Summary>
public partial class Nebulas : Node
{
	/// Name of nebula
	private String _givenName = "Unnamed Nebulas";
	/// Amount of stardust inside the nebula
	private int _stardust = 0;
	/// Amount of stardust the nebula attracts every second.
	private int _stardustConsumed = 0;
	
	public String GivenName {
		get {	return _givenName;	}
	}
	
	public int Stardust{
		get { return _stardust; }
	}
	
	public int StardustConsumed{
		get { return _stardustConsumed; }
	}
}
