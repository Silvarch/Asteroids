camPosX = room_width/2;
camPosY = room_height/2;

camera = camera_create();
view_set_camera(view_current, camera);

camera_set_view_pos(camera, camPosX, camPosY);
camera_set_view_size(camera, 960, 540);

repeat (0)
{
	var X = -2000 + irandom(4000);
	var Y = -2000 + irandom(4000);
	instance_create_layer(X, Y, "Instances", objStar);
}

repeat (0)
{
	var X = -2000 + irandom(4000);
	var Y = -2000 + irandom(4000);
	instance_create_layer(X, Y, "Instances", objStar2);
}

repeat (0)
{
	var X = -2000 + irandom(4000);
	var Y = -2000 + irandom(4000);
	instance_create_layer(X, Y, "Instances", objComet);
}


var maxDistance = MAX_DISTANCE;
var planetMinFreeSpace = PLANET_MIN_FREE_SPACE;
var w = ceil(maxDistance / planetMinFreeSpace);
var h = w;
var gridX = ds_grid_create(w, h);
var gridY = ds_grid_create(w, h);


var planetW = 48;

var planets = 0;

for (var i=0; i < h; i++)
{
	for (var j=0; j < w; j++)
	{
		gridX[# i, j] = ds_list_create();
		gridY[# i, j] = ds_list_create();
	}
}

var queueX = ds_list_create();
var queueY = ds_list_create();

ds_list_add(queueX, maxDistance / 2);
ds_list_add(queueY, maxDistance / 2);

// BFS
while (!ds_list_empty(queueX) )//&& planets < 650)
{
	var currentX = queueX[|0];
	var currentY = queueY[|0];
	
	ds_list_delete(queueX, 0);
	ds_list_delete(queueY, 0);
	
	if (point_distance(currentX, currentY, maxDistance / 2, maxDistance / 2) > maxDistance / 2)
	{
		continue;
	}

	var branches = 4;//irandom_range(1, 3);
	
	for (var i=0; i < branches; i++)
	{
		var dist = random_range(planetMinFreeSpace, planetMinFreeSpace + 24);
		var angle = random(360);
		var newX = currentX + lengthdir_x(dist, angle);
		var newY = currentY + lengthdir_y(dist, angle);
		
		var canFit = true;
		
		var blocksXQueue = ds_list_create();
		var blocksYQueue = ds_list_create();
		
		var xIndex = floor(newX / planetMinFreeSpace);
		var yIndex = floor(newY / planetMinFreeSpace);
		
		if (xIndex < 0 || yIndex < 0 || xIndex > w-1 || yIndex > h-1)
		{
			continue;
		}
		
		ds_list_add(blocksXQueue, gridX[# yIndex, xIndex]);
		ds_list_add(blocksYQueue, gridY[# yIndex, xIndex]);
		
		if (xIndex > 0)
		{
			ds_list_add(blocksXQueue, gridX[# yIndex, xIndex - 1]);
			ds_list_add(blocksYQueue, gridY[# yIndex, xIndex - 1]);
			if (yIndex > 0)
			{
				ds_list_add(blocksXQueue, gridX[# yIndex - 1, xIndex - 1]);
				ds_list_add(blocksYQueue, gridY[# yIndex - 1, xIndex - 1]);
			}
			if (yIndex < h - 1)
			{
				ds_list_add(blocksXQueue, gridX[# yIndex + 1, xIndex - 1]);
				ds_list_add(blocksYQueue, gridY[# yIndex + 1, xIndex - 1]);
			}
		}
		if (xIndex < w - 1)
		{
			ds_list_add(blocksXQueue, gridX[# yIndex, xIndex + 1]);
			ds_list_add(blocksYQueue, gridY[# yIndex, xIndex + 1]);
			if (yIndex > 0)
			{
				ds_list_add(blocksXQueue, gridX[# yIndex - 1, xIndex + 1]);
				ds_list_add(blocksYQueue, gridY[# yIndex - 1, xIndex + 1]);
			}
			if (yIndex < h - 1)
			{
				ds_list_add(blocksXQueue, gridX[# yIndex + 1, xIndex + 1]);
				ds_list_add(blocksYQueue, gridY[# yIndex + 1, xIndex + 1]);
			}			
		}
		
		if (yIndex > 0)
		{
			ds_list_add(blocksXQueue, gridX[# yIndex - 1, xIndex]);
			ds_list_add(blocksYQueue, gridY[# yIndex - 1, xIndex]);
		}
		if (yIndex < h - 1)
		{
			ds_list_add(blocksXQueue, gridX[# yIndex + 1, xIndex]);
			ds_list_add(blocksYQueue, gridY[# yIndex + 1, xIndex]);
		}
		
		for (var k=0; k < ds_list_size(blocksXQueue) && canFit; k++)
		{
			var gridBlockX = blocksXQueue[| k];
			var gridBlockY = blocksYQueue[| k];
		
			for (var l=0; l < ds_list_size(gridBlockX); l++)
			{
				if (point_distance(newX, newY, gridBlockX[|l], gridBlockY[|l]) < planetMinFreeSpace)
				{
					canFit = false;
					break;
				}
			}
		}
		
		ds_list_destroy(blocksXQueue);
		ds_list_destroy(blocksYQueue);
		
		if (canFit)
		{
			instance_create_layer(newX, newY, "Instances", objPlanet);
				
			ds_list_add(gridX[# yIndex, xIndex], newX);
			ds_list_add(gridY[# yIndex, xIndex], newY);
			
			ds_list_add(queueX, newX);
			ds_list_add(queueY, newY);	
			planets++;
		}
	}
}