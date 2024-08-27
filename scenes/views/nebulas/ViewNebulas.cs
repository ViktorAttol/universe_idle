using Godot;
using System;

public partial class ViewNebulas : View
{
	/// Reference to the nebulas handler;
	private HandlerNebulas handler;
	
	public override void _Ready()
	{
		base._Ready();
		handler = HandlerNebulas.Instance;
	}
	
	/// Asks the handler to create a new nebula.
	private void OnCreateNebulaBtnPressed()
	{
		handler.CreateNebula();
	}
}



