using UnityEngine;

public class Line_LineTest : MonoBehaviour
{
    public Transform line1Start;
    public Transform line1End;
    public Transform line2Start;
    public Transform line2End;

    public float distance;

    private void Update() 
    {
        Coordinates line1StartCoord = new Coordinates(line1Start.position.x, line1Start.position.y, line1Start.position.z);
        Coordinates line1EndCoord = new Coordinates(line1End.position.x, line1End.position.y, line1End.position.z);
        Line line1 = new Line(line1StartCoord, line1EndCoord, Line.LINETYPE.LINE);

        Coordinates line2StartCoord = new Coordinates(line2Start.position.x, line2Start.position.y, line2Start.position.z);
        Coordinates line2EndCoord = new Coordinates(line2End.position.x, line2End.position.y, line2End.position.z);
        Line line2 = new Line(line2StartCoord, line2EndCoord, Line.LINETYPE.LINE);

        Debug.DrawRay(line1Start.position, line1.v.ToVector() * 15, Color.red);
        Debug.DrawRay(line2Start.position, line2.v.ToVector() * 15, Color.red);
        Debug.DrawLine(Mathematics.ClosestPointsOnLines(line1, line2)[0].ToVector(), Mathematics.ClosestPointsOnLines(line1, line2)[1].ToVector(), Color.green);

        distance = Mathematics.DistanceBetweenOnLines(line1, line2);
    }
}
