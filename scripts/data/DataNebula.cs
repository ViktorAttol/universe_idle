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
	/// Amount of ionized stardust composing the nebula.
	[Export]
	private int _ionizedStardust;
	/// Amount of stardust consumed per seconds.
	[Export]
	private int _attractionValue;
	/// Amount of ionized stardust released per seconds.
	[Export]
	private int _releaseValue;
	
	public String Name{
		get { return _name; }
	}

	public int IonizedStardust{
		get { return _ionizedStardust; }
		set{ _ionizedStardust = value; }
	}

	public int Stardust{
		get { return _stardust; }
		set{ _stardust = value; }
	}
	
	public int AttractionValue{
		get { return _attractionValue; }
		set{ _attractionValue = value; }
	}
	
	public int ReleaseValue{
		get { return _releaseValue; }
		set{ _releaseValue = value; }
	}	
	
	public DataNebula(){}

	public DataNebula(String name, int stardust, int ionizedStardust, int attractionValue, int releaseValue){
		_name = name;
		_stardust = stardust;
		_ionizedStardust = ionizedStardust;
		_attractionValue = attractionValue;
		_releaseValue = releaseValue;
	}
}
