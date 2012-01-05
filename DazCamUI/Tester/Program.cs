using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DazCamUI.Controller;

namespace Tester
{
    class Program
    {
        static void Main(string[] args)
        {
            var toolOffset = new Offset(0, 0, 2);
            var surfaceOffset = new Offset(0, 0, .25);
            var invertedZOffset = new Offset() { InvertZ = true };

            var combinedOffset = invertedZOffset + toolOffset + surfaceOffset;

            var workingCoordinate = new Coordinate(0, 0, -.5);

            Coordinate testCoordinate = new Coordinate(workingCoordinate.X, workingCoordinate.Y, workingCoordinate.Z);
            testCoordinate = invertedZOffset.ConvertToMachineCoordinate(testCoordinate);
            testCoordinate = toolOffset.ConvertToMachineCoordinate(testCoordinate);
            testCoordinate = surfaceOffset.ConvertToMachineCoordinate(testCoordinate);

            var worldCoordinate = combinedOffset.ConvertToMachineCoordinate(workingCoordinate);

            Console.WriteLine(worldCoordinate.Z);
            Console.WriteLine(testCoordinate.Z);

            Console.WriteLine(combinedOffset.ConvertCoordinateToWorking(worldCoordinate).Z);
            Console.ReadLine();
        }
    }
}
