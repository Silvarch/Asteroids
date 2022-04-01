camera_set_view_pos(camera, camPosX, camPosY);


var lr = layer_get_id("Background");
layer_x(lr, camPosX/10);
layer_y(lr, camPosY/10);

var lr1 = layer_get_id("Background_1");
layer_x(lr1, camPosX/20);
layer_y(lr1, camPosY/20);