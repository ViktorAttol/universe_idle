using Godot;
using System;



public partial class UserInterface : Control
{
	/// List of possible views
	public enum Views{
		PROTOTYPE_GENERATOR, PROTOTYPE_CLICKER,
	}
	/// Signal cb für navigation requests 
	[Signal]
	public delegate void navigation_requestedEventHandler(int view);
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	
	private void _on_prototype_generator_link_pressed()
	{
		EmitSignal(SignalName.navigation_requested, (int)Views.PROTOTYPE_GENERATOR);
	}


	private void _on_prototype_clicker_link_pressed()
	{
		EmitSignal(SignalName.navigation_requested, (int)Views.PROTOTYPE_CLICKER);	
	}
}



