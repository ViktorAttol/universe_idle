using Godot;
using System;

/// <Summary>
/// Contains CCUpgrades data to save and load.
/// </Summary>
public partial class DataCCUpgrades : Resource
{
	[Export]
	private bool _u01StardustGeneration = false;
	
	public bool U01StardustGeneration {
		get {
			return _u01StardustGeneration;
		}
		set{
			_u01StardustGeneration = value;
		}
	}
}
