using Godot;
using System;

/// <Summary>
/// Abstract class containing the common features of all Nebulas.
/// </Summary>
public partial class Nebula : Node
{
	/// Name of nebula
	private String _givenName = "Unnamed Nebulas";
	/// Index of the nebula in data
	private int _dataIndex = -1;
	/// Amount of stardust inside the nebula
	private int _stardust = 0;
	/// Amount of stardust the nebula attracts every second.
	private int _stardustConsumed = 0;
	
	public String GivenName {
		get {	return _givenName;	}
		set { _givenName = value; }
	}
	
	public int DataIndex{
		get { return _dataIndex; }
		set { _dataIndex = value; }
	}
	
	public int Stardust{
		get { return _stardust; }
	}
	
	public int StardustConsumed{
		get { return _stardustConsumed; }
	}
	
	public Nebula(){}
	
	public Nebula(String name, int dataIndex, int stardust, int stardustConsumed){
		_givenName = name;
		_dataIndex = dataIndex;
		_stardust = stardust;
		_stardustConsumed = stardustConsumed;
	}
	
	public DataNebula GetNebulaData(){
		return new DataNebula(_givenName, _stardust, _stardustConsumed);
	}
	
	private void OnConsumeStardust(){
		
	}
}
