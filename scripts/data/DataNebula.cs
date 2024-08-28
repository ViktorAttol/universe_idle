using Godot;
using System;

/// <Summary>
/// Save design of a single nebula.
/// </Summary>
public partial class DataNebula : Resource
{
	/// Name of the given nebula
	[Export]
	private String _name;
	/// Amount of stardust composing the nebula.
	[Export]
	private int _stardust;
	/// Amount of stardust consumed per seconds.
	[Export]
	private int _stardustConsumed;
	
	public DataNebula(){}

	public DataNebula(String name, int stardust, int stardustConsumed){
		_name = name;
		_stardust = stardust;
		_stardustConsumed = stardustConsumed;
	}
	
	public String Name{
		get { return _name; }
	}

	public int Stardust{
		get { return _stardust; }
		set{ _stardust = value; }
	}

	public int StardustConsumed{
		get { return _stardustConsumed; }
		set{ _stardustConsumed = value; }
	}
}
