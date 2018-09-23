// ----------------------------------------------------------------------------
// Unity Workshop - HAW Hamburg
// 
// Author: Nenad Slavujevic
// Date:   10/09/18
// ----------------------------------------------------------------------------

// Instead of "hardwriting" every Tag into our Scripts, we use our Tags Manager class.
// If we change Tags we don't have to go through every single script and change them accordingly but only have to change them here.
// The Variables are static so that we can reference them from anywhere.
public class Tags
{
	public static string PLAYER_TAG = "Player";
	public static string PLAYER_SHOT_TAG = "PlayerShot";
	public static string ENEMY_TAG = "Enemy";
	public static string ENEMY_SHOT_TAG = "EnemyShot";
	public static string POWER_UP_TAG = "PowerUp";
	public static string OBSTACLE_TAG = "Obstacle";
	public static string OBSTACLE_STRONG_TAG = "Obstacle_Strong";
	public static string ROAD_END_POINT_TAG = "RoadEndPoint";
    public static string MAIN_CANNON = "MainCannon";
    // Player Animation Tags
    public static string ANIMATION_DRIVE = "CarRig|Drive";
	public static string ANIMATION_BACKWARDS = "CarRig|Backwards";
	public static string ANIMATION_LEFT = "CarRig|Steer_Left";
	public static string ANIMATION_RIGHT = "CarRig|Steer_Right";
	public static string ANIMATION_PLAYER_SHOOT = "CarRig|Shoot";
}
