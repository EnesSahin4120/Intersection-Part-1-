using UnityEngine;

public class LineSegment_PointTest : MonoBehaviour
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

        Line currentLine = new Line(lineStartCoord, lineEndCoord, Line.LINETYPE.SEGMENT);
        Coordinates closestPoint = Mathematics.ClosestPointOnLineSegment(currentLine, pointCoord);

        Debug.DrawLine(lineStart.position, lineEnd.position, Color.red);
        Debug.DrawLine(point.position, closestPoint.ToVector(), Color.green);

        distance = Mathematics.DistanceBetweenLineSegment_Point(currentLine, pointCoord);
    }
}
