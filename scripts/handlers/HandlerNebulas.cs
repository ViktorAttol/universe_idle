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
	
	[Export]
	private Timer timer;
	
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
			ConstructNebula(indexNebula, nebulaData);
			//Nebula newNebula = new Nebula(nebulaData, indexNebula);
			//timer.Timeout += newNebula.OnConsumeStardust;
			//nebulas.Add(newNebula);
			indexNebula++;
		}
	}
	
	/// Returns the full list of nebulas.
	private List<Nebula> GetAllNebulas(){
		return nebulas;
	}
	
	/// Create a new Nebula and add it to the list.
	public void CreateNebula(){
		ConstructNebula(nebulas.Count);
		//Nebula newNebula = new Nebula();
		//newNebula.DataIndex = nebulas.Count;
		//timer.Timeout += newNebula.OnConsumeStardust;
		//nebulas.Add(newNebula);
		//Game.Instance.Data.AddNebula(newNebula.GetNebulaData());
	}
	
	private void ConstructNebula(int index, DataNebula nebulaData = null){
		Nebula newNebula;
		if(nebulaData == null) {
			newNebula = new Nebula();
			newNebula.DataIndex = index;
		}
		else newNebula = new Nebula(nebulaData, index);
		
		timer.Timeout += newNebula.OnConsumeStardust;
		nebulas.Add(newNebula);
		
		if(nebulaData == null) {
			Game.Instance.Data.AddNebula(newNebula.GetNebulaData());
			OnNebulaCreated();
		}
	}
	
	/// Changes the stardust consumption value of the single nebula.
	public void UpdateNebulaStardustConsumptionValue(int index, int value){
		nebulas[index].StardustConsumed = value;
		Game.Instance.Data.Nebulas[index].StardustConsumed = value;
	}
	
	public void OnNebulaCreated(){
		EmitSignal(SignalName.NebulaCreated);
	}
}
