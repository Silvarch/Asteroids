image_index = irandom(image_number);
image_speed = 0;
image_xscale = 2;
image_yscale = 2;

if (image_index < 33)
{
	var moonChance = irandom(10);
	if (moonChance < 4)
	{
		var angle = random(360);
		instance_create_layer(x + lengthdir_x(80, angle), y + lengthdir_y(80, angle), layer_get_id("Moons"), objMoon);
	}
}