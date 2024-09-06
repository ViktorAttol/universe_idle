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
	/// Amount of ionized stardust inside the nebula.
	private int _ionizedStardust = 0;
	
	/// Amount of stardust the nebula attracts every second.
	private int _attractionValue = 1;
	/// Amount of ionized stardust being released.
	private int _releaseValue = 1;
	
	/// Values for stardust refinement.
	private int stardustThresholdNeededForRefinement = 25;
	private int refiningStardustCost = 3;
	private int refiningIonizedStardustGain = 2;
	
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
	
	public int IonizedStardust{
		get { return _ionizedStardust; }
		set { _ionizedStardust = value; }
	}
	
	public int AttractionValue{
		get { return _attractionValue; }
		set { _attractionValue = value; }
	}
	public int ReleaseValue{
		get { return _releaseValue; }
		set { _releaseValue = value; }
	}
	
	public Nebula(){}
	public Nebula(DataNebula nebulaData, int dataIndex){
		_givenName = nebulaData.Name;
		_dataIndex = dataIndex;
		_stardust = nebulaData.Stardust;
		_ionizedStardust = nebulaData.IonizedStardust;
		_attractionValue = nebulaData.AttractionValue;
		_releaseValue = nebulaData.ReleaseValue;
	}
	
	
	/// Returns the data of the nebula as an DataNebula object.
	/// Todo refactor later to be a static helper class method.
	public DataNebula GetNebulaData(){
		return new DataNebula(_givenName, _stardust, _ionizedStardust, _attractionValue, _releaseValue);
	}
	
	/// Tries to consume stardust.
	public void AttractStardust(){
		bool success = HandlerStardust.Instance.ConsumeStardust(_attractionValue);
		if(!success) return;
		
		_stardust += _attractionValue;
		Game.Instance.Data.Nebulas[_dataIndex].Stardust = _stardust;
		EmitSignal(SignalName.CompositionUpdated);
	}
	
	/// Transforms stardust into ionized stardust.
	public void RefineStardust(){
		if(_stardust >= stardustThresholdNeededForRefinement){
			if(!ConsumeStardust(refiningStardustCost)) return;
			_ionizedStardust += refiningIonizedStardustGain;
			Game.Instance.Data.Nebulas[_dataIndex].IonizedStardust = _ionizedStardust;
			EmitSignal(SignalName.CompositionUpdated);
		}
	}
	
	
	/// Tries to consume a certain amount of stardust.
	private bool ConsumeStardust(int amount){
		if(_stardust >= amount) {
			_stardust -= amount;
			Game.Instance.Data.Nebulas[_dataIndex].Stardust = _stardust;
			return true;
		}
		return false;
	}
	
		/// Tries to consume a certain amount of ionized stardust.
	private bool ConsumeIonizedStardust(int amount){
		if(_ionizedStardust >= amount) {
			_ionizedStardust -= amount;
			Game.Instance.Data.Nebulas[_dataIndex].IonizedStardust = _ionizedStardust;
			return true;
		}
		return false;
	}
	
	/// Triggered when the nebula timer times out.	
	public void OnNebulaTimerTimeout(){
		AttractStardust();
		RefineStardust();
	}
}
