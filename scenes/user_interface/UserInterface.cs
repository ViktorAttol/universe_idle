using Godot;
using System;

/// <Summary>
/// Base class for the user interface. Emits navigation request signals.
/// </Summary>
public partial class UserInterface : Control
{
	/// List of possible views
	public enum Views{
		UNIVERSE, 
		CONSCIOUSNESS_CORE,
		NEBULAS,
	}
	/// Signal cb für navigation requests 
	[Signal]
	public delegate void navigation_requestedEventHandler(int view);
	
	public override void _Ready(){
		EmitSignal(SignalName.navigation_requested, (int)Views.UNIVERSE);
	}
		
	private void OnConsciousnessCoreBtnPressed()
	{
		EmitSignal(SignalName.navigation_requested, (int)Views.CONSCIOUSNESS_CORE);	
	}
		
	private void OnUniverseLinkPressed()
	{
		EmitSignal(SignalName.navigation_requested, (int)Views.UNIVERSE);	
	}
	
	private void OnNebulasLinkPressed()
	{
		EmitSignal(SignalName.navigation_requested, (int)Views.NEBULAS);	
	}
}















