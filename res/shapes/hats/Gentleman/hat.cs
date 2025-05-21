datablock ItemData(HatGentlemanItem)
{
	category = "Hat";
	classname = "Hat";
	shapeFile = "./Gentleman.dts";
	image = HatGentlemanImage;
	mass = 1;
	drag = 0.3;
	density = 0.2;
	elasticity = 0;
	friction = 1;
	doColorShift = false;
	uiName = "Hat Gentleman";
	canDrop = true;
	iconName = $Despair::Path @ "res/shapes/hats/icon_hat";

	disguise = true;
	hidehair = false;
	replaceHairMale = "hair_messy";
	replaceHairFemale = "hair_ponytail";
	disguiseName = "Gentleman";
};
datablock ShapeBaseImageData(HatGentlemanImage)
{
	item = HatGentlemanItem;
	shapeFile = "./Gentleman.dts";
	doColorShift = false;
	mountPoint = $headSlot;
	eyeOffset = "0 0 -50";
};
