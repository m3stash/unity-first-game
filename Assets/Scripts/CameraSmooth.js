 
/***********************************************************************
 * Notes
 ***********************************************************************/
 
/*
 * This is a simple 2D camera script. Attach it to a camera, specify
 * a target and the camera will follow its X and Y position (taking into
 * account the vertical offset).
 */
 
/***********************************************************************
 * Variables
 ***********************************************************************/
 
var target : Transform; // The target for the camera to follow
var settings : Camera;
 
/***********************************************************************
 * Classes
 ***********************************************************************/
 
class Camera {
    /*******************************
     * Public (Inspector) variables
     *******************************/
 
    var enabled : boolean = true; // Is the script enabled?
    var verticalOffset : float = 2; // Offset from the target's Y position
}
 
/***********************************************************************
 * Unity Functions
 ***********************************************************************/
 
// Per the docs:
// "[...] a follow camera should always be implemented in LateUpdate 
// because it tracks objects that might have moved inside Update."
function LateUpdate() {
    if (target) MoveCamera();
}
 
/***********************************************************************
 * Custom Functions
 ***********************************************************************/
 
function MoveCamera() {
    transform.position.x = target.position.x;
    transform.position.y = target.position.y + settings.verticalOffset;
}