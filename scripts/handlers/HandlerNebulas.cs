using Godot;
using System;
using System.Collections.Generic;
/// <Summary>
/// Manages nebulas.
/// </Summary>
public partial class HandlerNebulas : Node
{
	private static HandlerNebulas _instance;
	
	/// Emitted when composition ist updated.
	[Signal]
	public delegate void NebulaCreatedEventHandler();
	
	/// Reference to the stardust consumption counter.
	[Export]
	private Timer timer;
	
	/// Maximum amount of nebulas the player can create.
	private int _maxNebulaCount = 1;
	
	public int MaxNebulaCount {
		get { return _maxNebulaCount; }
		set { _maxNebulaCount = value; }
	}
	
	/// List of nebulas.
	private List<Nebula> nebulas = new List<Nebula>();
	
	public List<Nebula> Nebulas {
		get{ return nebulas; }
	}
	
	
	/// When the szene is created, an instance of this class will be created with the normal constructor
	/// because the Nebulas Node under Handlers has this as a script attached.
	/// So to implement the Singleton pattern in c# the only way is to use the constructor to set _instance. 
	public static HandlerNebulas Instance{
		get{
			return _instance;
		}
	}
	
	public override void _Ready(){
		LoadNebulas();
	}
	
	private HandlerNebulas(){
		_instance = this;
	}
	
	/// Load nebulas from data.
	private void LoadNebulas(){
		if(Game.Instance.Data.Nebulas.Length == 0) return;
		
		nebulas.Clear();
		int indexNebula = 0;
		foreach(DataNebula nebulaData in Game.Instance.Data.Nebulas){
			bool successfull = ConstructNebula(indexNebula, nebulaData);
			if( successfull) indexNebula++;
		}
	}
	
	/// Returns the full list of nebulas.
	private List<Nebula> GetAllNebulas(){
		return nebulas;
	}
	
	/// Create a new Nebula and add it to the list.
	public void CreateNebula(){
		ConstructNebula(nebulas.Count);
	}
	
	private bool ConstructNebula(int index, DataNebula nebulaData = null){
		if(nebulas.Count >= _maxNebulaCount) return false;
		Nebula newNebula;
		if(nebulaData == null) {
			newNebula = new Nebula();
			newNebula.DataIndex = index;
		}
		else newNebula = new Nebula(nebulaData, index);
		
		timer.Timeout += newNebula.OnNebulaTimerTimeout;
		nebulas.Add(newNebula);
		
		if(nebulaData == null) {
			Game.Instance.Data.AddNebula(newNebula.GetNebulaData());
			OnNebulaCreated();
		}
		return true;
	}
	
	/// Changes the stardust consumption value of the single nebula.
	public void UpdateNebulaStardustAttractionValue(int index, int value){
		nebulas[index].AttractionValue = value;
		Game.Instance.Data.Nebulas[index].AttractionValue = value;
	}
	
	/// Emits signal to subrscribers.
	public void OnNebulaCreated(){
		EmitSignal(SignalName.NebulaCreated);
	}
	
		/// Changes theionized stardust release value of the single nebula.
	public void UpdateNebulaReleaseValue(int index, int value){
		nebulas[index].ReleaseValue = value;
		Game.Instance.Data.Nebulas[index].ReleaseValue = value;
	}
}
