using UnityEngine;

public static class MotorHelper 
{
	public static Vector2 DirectionToCursor(Vector2 origin, Camera camera)
	{
		Vector2 cursorPosition = Input.mousePosition;
		cursorPosition = camera.ScreenToWorldPoint(cursorPosition);
		Vector2 difference = cursorPosition - origin;

		return difference;
	}
}
