using Godot;
using System;

public partial class ViewNebulas : View
{
	/// Reference to the nebulas handler;
	private HandlerNebulas handler;
	/// Area to add nebula components to.
	[Export]
	private VBoxContainer mainList;
	/// Reference to the scene of the nebula component.
	[Export]
	private PackedScene sceneNebula;
	
	
	public override void _Ready()
	{
		base._Ready();
		handler = HandlerNebulas.Instance;
		GenerateNebulas();
		handler.NebulaCreated += GenerateNewestNebula;
	}
	
	/// Asks the handler to create a new nebula.
	private void OnCreateNebulaBtnPressed()
	{
		handler.CreateNebula();
	}
	
	/// Generates all nebulas from the handler.
	private void GenerateNebulas(){
		if(handler.Nebulas.Count == 0) return;
		
		foreach(Nebula nebula in handler.Nebulas){
			GenerateNebula(nebula);
		}
	}
	
	/// Generates the newest node.
	private void GenerateNewestNebula(){
		GenerateNebula(handler.Nebulas[handler.Nebulas.Count -1]);
	}
	
	/// Generates a nebula node.
	private void GenerateNebula(Nebula nebula){
		CompoNebula newNode = CreateCompoNebulaNode();
		newNode.Nebula = nebula;
		mainList.AddChild(newNode);
	}
	
	/// Instantiates a new nebula in the scene object.
	private CompoNebula CreateCompoNebulaNode(){
		return (CompoNebula) sceneNebula.Instantiate();
	}
}



