datablock ItemData(HatStrangerItem)
{
	category = "Hat";
	classname = "Hat";
	shapeFile = "./Stranger.dts";
	image = HatStrangerImage;
	mass = 1;
	drag = 0.3;
	density = 0.2;
	elasticity = 0;
	friction = 1;
	doColorShift = false;
	uiName = "Hat Stranger";
	canDrop = true;
	iconName = $Despair::Path @ "res/shapes/hats/icon_hat";

	disguise = true;
	hidehair = true;
	disguiseName = "Stranger";
};
datablock ShapeBaseImageData(HatStrangerImage)
{
	item = HatStrangerItem;
	shapeFile = "./Stranger.dts";
	doColorShift = false;
	mountPoint = $headSlot;
	eyeOffset = "0 0 -50";
};
