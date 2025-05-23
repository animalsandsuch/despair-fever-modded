datablock ItemData(HatBigHeadItem)
{
	category = "Hat";
	classname = "Hat";
	shapeFile = "./BigHead.dts";
	image = HatBigHeadImage;
	mass = 1;
	drag = 0.3;
	density = 0.2;
	elasticity = 0;
	friction = 1;
	doColorShift = false;
	uiName = "Hat BigHead";
	canDrop = true;
	iconName = $Despair::Path @ "res/shapes/hats/icon_hat";

	disguise = true;
	disguiseName = "Suspiciously Large Headed Individual";
	hidehair = true;
};
datablock ShapeBaseImageData(HatBigHeadImage)
{
	item = HatBigHeadItem;
	shapeFile = "./BigHead.dts";
	doColorShift = false;
	mountPoint = $headSlot;
	eyeOffset = "0 0 -50";
};
