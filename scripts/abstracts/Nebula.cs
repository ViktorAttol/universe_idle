using Godot;
using System;

/// <Summary>
/// Abstract class containing the common features of all Nebulas.
/// </Summary>
public partial class Nebula : Node
{
	/// Emitted when composition ist updated.
	[Signal]
	public delegate void CompositionUpdatedEventHandler();
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
		set { _stardustConsumed = value; }
	}
	
	public Nebula(){}
	/// (nebulaData.Name, indexNebula, nebulaData.Stardust, nebulaData.StardustConsumed)
	public Nebula(DataNebula nebulaData, int dataIndex){
		_givenName = nebulaData.Name;
		_dataIndex = dataIndex;
		_stardust = nebulaData.Stardust;
		_stardustConsumed = nebulaData.StardustConsumed;
	}
	//public Nebula(String name, int dataIndex, int stardust, int stardustConsumed){
		//_givenName = name;
		//_dataIndex = dataIndex;
		//_stardust = stardust;
		//_stardustConsumed = stardustConsumed;
	//}
	
	/// Returns the data of the nebula as an DataNebula object.
	/// Todo refactor later to be a static helper class method.
	public DataNebula GetNebulaData(){
		return new DataNebula(_givenName, _stardust, _stardustConsumed);
	}
	
	/// Tries to consume stardust.
	public void OnConsumeStardust(){
		bool success = HandlerStardust.Instance.ConsumeStardust(_stardustConsumed);
		if(!success) return;
		
		_stardust += _stardustConsumed;
		Game.Instance.Data.Nebulas[_dataIndex].Stardust = _stardust;
		EmitSignal(SignalName.CompositionUpdated);
	}
}
