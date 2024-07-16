using Godot;
using System;

/// <Summary>
/// Base class for the user interface. Emits navigation request signals.
/// </Summary>
public partial class UserInterface : Control
{
	/// List of possible views
	public enum Views{
		PROTOTYPE_GENERATOR, PROTOTYPE_CLICKER, PROTOTYPE_UPGRADES, CONSCIOUSNESS_CORE,
	}
	/// Signal cb für navigation requests 
	[Signal]
	public delegate void navigation_requestedEventHandler(int view);
	
	private void _on_prototype_generator_link_pressed()
	{
		EmitSignal(SignalName.navigation_requested, (int)Views.PROTOTYPE_GENERATOR);
	}

	private void _on_prototype_clicker_link_pressed()
	{
		EmitSignal(SignalName.navigation_requested, (int)Views.PROTOTYPE_CLICKER);	
	}
	
	private void _on_prototype_upgrades_pressed()
	{
		EmitSignal(SignalName.navigation_requested, (int)Views.PROTOTYPE_UPGRADES);	
	}
	
	private void OnConsciousnessCoreBtnPressed()
	{
		EmitSignal(SignalName.navigation_requested, (int)Views.CONSCIOUSNESS_CORE);	
	}
}









