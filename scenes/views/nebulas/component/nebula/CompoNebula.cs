using Godot;
using System;

/// <Summary>
/// Displays the information of a nebula.
/// </Summary>
public partial class CompoNebula : VBoxContainer
{
	/// Reference to the label displaying the name.
	[Export]
	private Label labelName;
	
	/// Reference to the label displaying the composition. 
	[Export]
	private RichTextLabel labelComposition;
	
	/// References the slider managing the attraction.
	[Export]
	private HSlider attractionSlider;
	/// References the slider managing the release.
	[Export]
	private HSlider releaseSlider;
	/// Reference to the nebula which should be displayed;
	private Nebula _nebula; 
	
	/// Min value of the attraction slider.
	private int attractionSliderMinValue = 1;
	/// Max value of the attraction slider.
	private int attractionSliderMaxValue = 5;
	/// Min value of the release slider.
	private int releaseSliderMinValue = 1;
	/// Max value of the release slider.
	private int releaseSliderMaxValue = 5;
	
	public Nebula Nebula{
		get{ return _nebula; }
		set{ _nebula = value; }
	}
	
	public override void _Ready(){
		UpdateComponent();
		_nebula.CompositionUpdated += UpdateLabelComposition;
	}
	
	/// Updates all the nodes of the component.
	private void UpdateComponent(){
		UpdateLabelName();
		UpdateLabelComposition();
		UpdateAttractionSlider();
	}
	
	/// Updates the label name.	
	private void UpdateLabelName(){
		labelName.Text = _nebula.GivenName;
	}
	
	/// Updates the label composition.
	private void UpdateLabelComposition(){
		String text = "Stardust " + _nebula.Stardust;
		if(_nebula.IonizedStardust > 0){
			text += "\nIonized Stardust: " + _nebula.IonizedStardust;
		}
		labelComposition.Text = text;
	}
	
	/// Updates the attraction slider.
	private void UpdateAttractionSlider(){
		attractionSlider.MinValue = attractionSliderMinValue;
		attractionSlider.MaxValue = attractionSliderMaxValue;
		attractionSlider.Value = _nebula.AttractionValue;
	}
	
	/// Informs the subscribers on a changed attraction value.
	private void OnAttractionSliderChanged(double value)
	{
		HandlerNebulas.Instance.UpdateNebulaStardustAttractionValue(_nebula.DataIndex, (int)value);
	}
	
	/// Updates the release slider.
	private void UpdateReleaseSlider(){
		releaseSlider.MinValue = releaseSliderMinValue;		
		releaseSlider.MaxValue = releaseSliderMaxValue;
		releaseSlider.Value = _nebula.ReleaseValue;
	}
}







