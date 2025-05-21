datablock ItemData(HatOutlawItem)
{
	category = "Hat";
	classname = "Hat";
	shapeFile = "./Outlaw.dts";
	image = HatOutlawImage;
	mass = 1;
	drag = 0.3;
	density = 0.2;
	elasticity = 0;
	friction = 1;
	doColorShift = false;
	uiName = "Hat Outlaw";
	canDrop = true;
	iconName = $Despair::Path @ "res/shapes/hats/icon_hat";

	disguise = true;
	hidehair = true;
	disguiseName = "Outlaw";
};
datablock ShapeBaseImageData(HatOutlawImage)
{
	item = HatOutlawItem;
	shapeFile = "./Outlaw.dts";
	doColorShift = false;
	mountPoint = $headSlot;
	eyeOffset = "0 0 -50";
};
