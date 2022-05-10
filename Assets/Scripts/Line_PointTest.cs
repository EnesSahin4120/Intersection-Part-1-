using UnityEngine;

public class Line_PointTest : MonoBehaviour
{
    public Transform lineStart;
    public Transform lineEnd;
    public Transform point;

    public float distance;

    private void Update()
    {
        Coordinates lineStartCoord = new Coordinates(lineStart.position.x, lineStart.position.y, lineStart.position.z);
        Coordinates lineEndCoord = new Coordinates(lineEnd.position.x, lineEnd.position.y, lineEnd.position.z);
        Coordinates pointCoord = new Coordinates(point.position.x, point.position.y, point.position.z);

        Line currentLine = new Line(lineStartCoord, lineEndCoord, Line.LINETYPE.LINE);
        Coordinates closestPoint = Mathematics.ClosestPointOnLine(currentLine, pointCoord);

        Debug.DrawRay(lineStart.position, currentLine.v.ToVector() * 10, Color.red);
        Debug.DrawLine(point.position, closestPoint.ToVector(), Color.green);

        distance = Mathematics.DistanceBetweenLine_Point(currentLine, pointCoord);
    }
}
