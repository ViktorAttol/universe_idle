using Godot;
using System;

/// <Summary>
/// A generator prototype creating stardust
/// </Summary>
public partial class PrototypeGenerator : View
{	
	/// Button which starts generation of stardust
	[Export]
	private Button _button;
	
	/// Timer for stardust generation
	[Export]
	private Timer _timer;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		base._Ready();
		Visible = true;
	}
	
	/// Creates stardust
	private void CreateStardust(){
		HandlerStardust.Instance.CreateStardust(1);
	}
	
	/// Beginnst stardust generation
	private void BeginnGeneratingStardust(){
		_timer.Start();
		_button.Disabled = true;
	}
	
	/// Start generation cb
	private void _on_button_pressed()
	{
		BeginnGeneratingStardust();
	}
	
	/// Timer cb
	private void _on_timer_timeout()
	{
		CreateStardust();
	}
}






