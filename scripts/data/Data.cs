using Godot;
using System;
using System.Collections.Generic;

/// <Summary>
/// Contains data to save and load.
/// </Summary>
public partial class Data : Resource
{
	/// Values have to be Export to save and load properly with Resource system.
	[Export]
	private int _stardust = 0;
	[Export]
	private int _consciousnessCore = 1;
	[Export]
	private DataCCUpgrades _ccUpgrades = new DataCCUpgrades();
	/// Contains Universe data to dave and load.
	[Export]
	private DataUniverse _dataUniverse = new DataUniverse();
	/// List of nebulas
	[Export]
	private DataNebula[] _nebulas = new DataNebula[]{};
	
	public int Stardust {
		get {	return _stardust;	}
	}
	
	public int ConsciousnessCore {
		get {	return _consciousnessCore;	}
		set{	_consciousnessCore = value;	}
	}

	public DataCCUpgrades CCUpgrades {
		get {	return _ccUpgrades;		}
		set{	_ccUpgrades = value;	}
	}
	
	public DataUniverse Universe {
		get {	return _dataUniverse;		}
	}
	
	public DataNebula[] Nebulas {
		get {	return _nebulas;		}
	}
	
	public void AddStardust(int amount){
		_stardust += amount;
	}
	
	public void SubtractStardust(int amount){
		_stardust -= amount;
	}
	
	public void AddConsciousnessCores(int amount){
		_consciousnessCore += amount;
	}
	
	public void SubtractConsciousnessCores(int amount){
		_consciousnessCore -= amount;
	}
	
	public void AddNebula(DataNebula newNebulaData){
		List<DataNebula> nebulaList = new List<DataNebula>(_nebulas);
		nebulaList.Add(newNebulaData);
		_nebulas = nebulaList.ToArray();
	}
}
