datablock ItemData(HatPropellerItem)
{
	category = "Hat";
	classname = "Hat";
	shapeFile = "./Copter.dts";
	image = HatPropellerImage;
	mass = 1;
	drag = 0.3;
	density = 0.2;
	elasticity = 0;
	friction = 1;
	doColorShift = false;
	uiName = "Hat Silly";
	canDrop = true;
	iconName = $Despair::Path @ "res/shapes/hats/icon_hat";

	disguise = false;
	hidehair = false;
	replaceHairMale = "hair_messy";
	replaceHairFemale = "hair_ponytail";
};
datablock ShapeBaseImageData(HatPropellerImage)
{
	item = HatPropellerItem;
	shapeFile = "./Copter.dts";
	doColorShift = false;
	mountPoint = $headSlot;
	eyeOffset = "0 0 -50";
};
