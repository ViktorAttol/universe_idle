using Godot;
using System;

/// <Summary>
/// Contains CCUpgrades data to save and load.
/// </Summary>
public partial class DataCCUpgrades : Resource
{
	[Export]
	private bool _u01StardustGeneration = false;
	[Export]
	private int _u02StardustBoostLevel = 0;
	[Export]
	private bool _u03UnlockNebulas = false;
	
	public bool U01StardustGeneration {
		get {
			return _u01StardustGeneration;
		}
		set{
			_u01StardustGeneration = value;
		}
	}
	
	public int U02StardustBoostLevel {
		get {
			return _u02StardustBoostLevel;
		}
		set{
			_u02StardustBoostLevel = value;
		}
	}
	
	public bool U03UnlockNebulas {
		get {
			return _u03UnlockNebulas;
		}
		set{
			_u03UnlockNebulas = value;
		}
	}
}
