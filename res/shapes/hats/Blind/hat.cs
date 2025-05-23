datablock ItemData(HatBlindItem)
{
	category = "Hat";
	classname = "Hat";
	shapeFile = "./Blind.dts";
	image = HatBlindImage;
	mass = 1;
	drag = 0.3;
	density = 0.2;
	elasticity = 0;
	friction = 1;
	doColorShift = false;
	uiName = "Hat Eyepatch";
	canDrop = true;
	iconName = $Despair::Path @ "res/shapes/hats/icon_hat";

	disguise = false;
	hidehair = false;
};
datablock ShapeBaseImageData(HatBlindImage)
{
	item = HatBlindItem;
	shapeFile = "./Blind.dts";
	doColorShift = false;
	mountPoint = $headSlot;
	eyeOffset = "0 0 -50";
	eyeOffset = "0 0 -50";
};
