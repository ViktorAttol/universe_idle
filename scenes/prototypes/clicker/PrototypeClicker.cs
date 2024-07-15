using Godot;
using System;

/// <Summary>
/// A cklicker prototype creating stardust
/// </Summary>
public partial class PrototypeClicker : View
{	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		Visible = false;
	}
	
	/// Callback function for creating stardust
	private void _on_btn_pressed_create_stardust()
	{
		CreateStardust();
	}
	
	/// Creates stardust
	private void CreateStardust(){
		HandlerStardust.Instance.TriggerClicker();
	}
}





