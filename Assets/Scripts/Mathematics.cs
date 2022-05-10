using UnityEngine;

public class Mathematics : MonoBehaviour
{
    static public float Square(float grade)
    {
        return grade * grade;
    }

    static public float Distance(Coordinates coord1, Coordinates coord2)
    {
        float diffSquared = Square(coord1.x - coord2.x) +
            Square(coord1.y - coord2.y) +
            Square(coord1.z - coord2.z);
        float squareRoot = Mathf.Sqrt(diffSquared);
        return squareRoot;
    }

    static public float VectorLength(Coordinates vector)
    {
        float length = Distance(new Coordinates(0, 0, 0), vector);
        return length;
    }

    static public float Dot(Coordinates vector1, Coordinates vector2)
    {
        return (vector1.x * vector2.x + vector1.y * vector2.y + vector1.z * vector2.z);
    }

    static public Coordinates Projection(Coordinates vector1, Coordinates vector2)
    {
        float numeratorPart = Dot(vector1, vector2);
        float vector2Length = VectorLength(vector2);
        float denominatorPart = Square(vector2Length);
        Coordinates resultCoordinate = new Coordinates(vector2.x * (numeratorPart / denominatorPart), vector2.y * (numeratorPart / denominatorPart), vector2.z * (numeratorPart / denominatorPart));

        return resultCoordinate;
    }

    static public Coordinates ClosestPointOnLine(Line line, Coordinates point)
    {
        Coordinates w = point - line.A;
        Coordinates proj = Projection(w, line.v);

        Coordinates result = line.A + proj;
        return result;    
    }

    static public float DistanceBetweenLine_Point(Line line,Coordinates point)
    {
        Coordinates w = point - line.A;
        float distance = Dot(w, w) - Mathf.Pow(Dot(w, line.v), 2) / (float)Dot(line.v, line.v);
        return distance;
    }

    static public Coordinates ClosestPointOnLineSegment(Line line,Coordinates point)
    {
        Coordinates w = point - line.A;
        float t = Dot(w, line.v) / (float)Dot(line.v, line.v);

        Coordinates result = line.Lerp(t);
        return result;
    }

    static public float DistanceBetweenLineSegment_Point(Line line, Coordinates point)
    {
        float distance;

        Coordinates w = point - line.A;
        float proj = Dot(w, line.v);
        if (proj <= 0)
        {
            distance = Dot(w, w);
        }
        else
        {
            float vsq = Dot(line.v, line.v);
            if (proj >= vsq)
                distance = Dot(w, w) - 2 * proj + vsq;
            else
                distance = Dot(w, w) - proj * proj / vsq;
        }

        return distance;
    }

    static public Coordinates[] ClosestPointsOnLines(Line line1, Line line2)
    {
        Coordinates[] resultCoordinates = new Coordinates[2];

        Coordinates w0 = line1.A - line2.A;

        float a = Dot(line1.v, line1.v);
        float b = Dot(line1.v, line2.v);
        float c = Dot(line2.v, line2.v);
        float d = Dot(line1.v, w0);
        float e = Dot(line2.v, w0);

        float denom = a * c - b * b;
        if (denom == 0)
        {
            float result2_X = line2.A.x + (float)(e / c) * line2.v.x;
            float result2_Y = line2.A.y + (float)(e / c) * line2.v.y;
            float result2_Z = line2.A.z + (float)(e / c) * line2.v.z;

            resultCoordinates[0] = line1.A;
            resultCoordinates[1] = new Coordinates(result2_X, result2_Y, result2_Z);
        }
        else
        {
            float result1_X = line1.A.x + (float)((b * e - c * d) / denom) * line1.v.x;
            float result1_Y = line1.A.y + (float)((b * e - c * d) / denom) * line1.v.y;
            float result1_Z = line1.A.z + (float)((b * e - c * d) / denom) * line1.v.z;
            resultCoordinates[0] = new Coordinates(result1_X, result1_Y, result1_Z);


            float result2_X = line2.A.x + (float)((a * e - b * d) / denom) * line2.v.x;
            float result2_Y = line2.A.y + (float)((a * e - b * d) / denom) * line2.v.y;
            float result2_Z = line2.A.z + (float)((a * e - b * d) / denom) * line2.v.z;
            resultCoordinates[1] = new Coordinates(result2_X, result2_Y, result2_Z);
        }
        return resultCoordinates;
    }

    static public float DistanceBetweenOnLines(Line line1,Line line2)
    {
        float wc_X;
        float wc_Y;
        float wc_Z;
        float result;
        Coordinates wc;

        Coordinates w0 = line1.A - line2.A;

        float a = Dot(line1.v, line1.v);
        float b = Dot(line1.v, line2.v);
        float c = Dot(line2.v, line2.v);
        float d = Dot(line1.v, w0);
        float e = Dot(line2.v, w0);

        float denom = a * c - b * b;
        if (denom == 0)
        {
            wc_X = w0.x - (float)(e / c) * line2.v.x;
            wc_Y = w0.y - (float)(e / c) * line2.v.y;
            wc_Z = w0.z - (float)(e / c) * line2.v.z;
        }
        else
        {
            wc_X = w0.x + (float)((b * e - c * d) / denom) * line1.v.x - (float)((a * e - b * d) / denom) * line2.v.x;
            wc_Y = w0.y + (float)((b * e - c * d) / denom) * line1.v.y - (float)((a * e - b * d) / denom) * line2.v.y;
            wc_Z = w0.z + (float)((b * e - c * d) / denom) * line1.v.z - (float)((a * e - b * d) / denom) * line2.v.z;
        }
        wc = new Coordinates(wc_X, wc_Y, wc_Z);
        result = Dot(wc, wc);
        return result;
    }
}
