using System;
using System.IO;

namespace StreetView.OpenGL.StreetElements
{
    public static class GenerateCity
    {
        static int _polygonsCount;
        static string _fileContent;

        public enum BuilingTypes
        {
            Type1Yellow = 1,
            Type2Red = 2,
            Type3White = 3,
            Type4Garage = 4,
            Type5Magazine = 5,
            Type6Red2 = 6,
            Type7GreenWhite = 7,
            Type8Red3 = 8,
            Type9White2 = 9,
            Type10Yellow2 = 10
        }

        public static void Generate()
        {
            _polygonsCount = 0;
            GenerateGround();


            ////12
            //GenerateTree(20.3, -7);
            //GenerateTree(20.3, -6);
            //GenerateTree(20.3, -5);
            //GenerateTree(20.3, -4);

            GenerateBuilding(22, -15, 9, BuilingTypes.Type1Yellow, 0);
            GenerateBuilding(22, -10, 9, BuilingTypes.Type1Yellow, 0);

            //GenerateBuilding(22, -15, 3, BuilingTypes.Type1Yellow, 90);
            //GenerateBuilding(27, -15, 3, BuilingTypes.Type1Yellow, 90);

            //18/11
            GenerateTree(21, -26);

            GenerateTree(20.3, -35);
            GenerateTree(20.3, -36);
            GenerateTree(20.3, -37);
            GenerateTree(20.3, -38);

            GenerateBuilding(22, -35, 2, BuilingTypes.Type1Yellow, 0);
            GenerateBuilding(22, -30, 2, BuilingTypes.Type1Yellow, 0);

            GenerateBuilding(22, -30, 2, BuilingTypes.Type1Yellow, 90);
            GenerateBuilding(27, -30, 2, BuilingTypes.Type1Yellow, 90);

            //13
            GenerateTree(14, -35);
            GenerateTree(14, -34);
            GenerateTree(14, -33);
            GenerateTree(14, -32);
            GenerateTree(14, -31);
            GenerateTree(14, -30);
            GenerateTree(14, -29);
            GenerateTree(14, -28);
            GenerateTree(14, -27);
            GenerateTree(14, -26);

            GenerateBuilding(7, -35, 2, BuilingTypes.Type2Red, 0);
            GenerateBuilding(7, -30, 2, BuilingTypes.Type2Red, 0);

            GenerateBuilding(2, -30, 2, BuilingTypes.Type2Red, 90);
            GenerateBuilding(2, -30, 2, BuilingTypes.Type2Red, 90);

            //14/19
            GenerateBuilding(7, -15, 2, BuilingTypes.Type2Red, 0);
            GenerateBuilding(7, -10, 2, BuilingTypes.Type2Red, 0);

            GenerateBuilding(2, -15, 2, BuilingTypes.Type2Red, 90);
            GenerateBuilding(2, -15, 2, BuilingTypes.Type2Red, 90);

            //10
            GenerateTree(36, -15);
            GenerateTree(32.5, -15);

            GenerateBuilding(37, -15, 2, BuilingTypes.Type7GreenWhite, 90);
            GenerateBuilding(42, -15, 2, BuilingTypes.Type7GreenWhite, 90);

            GenerateBuilding(47, -14, 2, BuilingTypes.Type7GreenWhite, 90);
            GenerateBuilding(52, -14, 2, BuilingTypes.Type7GreenWhite, 90);

            GenerateBuilding(57, -15, 2, BuilingTypes.Type7GreenWhite, 90);
            GenerateBuilding(62, -15, 2, BuilingTypes.Type7GreenWhite, 90);

            //9
            GenerateTree(36, -26);

            GenerateBuilding(37, -30, 2, BuilingTypes.Type9White2, 90);
            GenerateBuilding(42, -30, 2, BuilingTypes.Type9White2, 90);

            GenerateBuilding(47, -31, 2, BuilingTypes.Type9White2, 90);
            GenerateBuilding(52, -31, 2, BuilingTypes.Type9White2, 90);

            GenerateBuilding(57, -30, 2, BuilingTypes.Type9White2, 90);
            GenerateBuilding(62, -30, 2, BuilingTypes.Type9White2, 90);

            //дороги

            //Oskalenko
            GenerateRoad(-500.0, -17.0, 500.0, -16.0, 1);
            GenerateRoad(-500.0, -22.0, 500.0, -18.0, 1);
            GenerateRoad(-500.0, -24.0, 500.0, -23.0, 1);
            //Dibunovskaya
            GenerateRoad(19.0, -500, 15.0, 500, 2);

            //sideroad
            GenerateRoad(33.0, 0, 36.0, -23, 2);

            //тротуары
            //GenerateRoad(24.0, -500, 23.0, 500, 2);
            //GenerateRoad(14.0, -500, 13.0, 500, 2);

            //GenerateRoad(-500.0, -22.0, 500.0, -21.0, 1);
            //GenerateRoad(-500.0, -16.0, 500.0, -15.0, 1);


            string resultFileContent = "NUMPOLLIES " + _polygonsCount + " \r\n\r\n";
            resultFileContent += _fileContent;
            File.WriteAllText(@"Data\World.txt", resultFileContent);
        }

        public static void GenerateGround()
        {
            GenerateRectangle(-1000.0f, -0.05f, -1000.0f, 1000.0f, -0.05f, 1000.0f, "grass");
        }

        public static void GenerateRoad(double x1, double z1, double x2, double z2, double layer)
        {
            GenerateRectangle(x1, 0.01 * layer, z1, x2, 0.01 * layer, z2, "road");
        }

        public static void GenerateTree(double x, double z)
        {
            GenerateParallelogram(x, 0.2, (0 * 2), 1.5, z, 0.2, "wood");
            GenerateParallelogram(x - 0.175, 0.5, (1 * 1.5), 2, z - 0.175, 0.5, "tree");
        }
        public static void GenerateBuilding(double x, double z, int high, BuilingTypes buildingType, int angle)
        {
            for (int stageNumber = 0; stageNumber < high; stageNumber++)
            {
                int windowsPerStage = 3;

                switch (buildingType)
                {
                    case BuilingTypes.Type1Yellow:
                        GenerateStage(x, stageNumber, z, windowsPerStage, true, true, false, angle, "yellow");
                        break;
                    case BuilingTypes.Type2Red:
                        GenerateStage(x, stageNumber, z, windowsPerStage, true, true, false, angle, "red");
                        break;
                    case BuilingTypes.Type3White:
                        GenerateStage(x, stageNumber, z, windowsPerStage, true, true, false, angle, "white");
                        break;
                    case BuilingTypes.Type6Red2:
                        GenerateStage(x, stageNumber, z, windowsPerStage, true, true, true, angle, "red");
                        break;
                    case BuilingTypes.Type8Red3:
                        GenerateStage(x, stageNumber, z, windowsPerStage, false, true, false, angle, "red");
                        break;
                    case BuilingTypes.Type5Magazine:
                        GenerateStage(x, stageNumber, z, windowsPerStage, false, false, false, angle, "red");
                        break;
                    case BuilingTypes.Type7GreenWhite:
                        GenerateStage(x, stageNumber, z, windowsPerStage, true, true, false, angle, "green");
                        break;
                    case BuilingTypes.Type9White2:
                        GenerateStage(x, stageNumber, z, windowsPerStage, true, true, false, angle, "white");
                        break;
                    case BuilingTypes.Type4Garage:
                        GenerateStage(x, stageNumber, z, windowsPerStage, false, false, false, angle, "road");
                        break;
                    case BuilingTypes.Type10Yellow2:
                        GenerateStage(x, stageNumber, z, windowsPerStage, false, true, true, angle, "yellow");
                        break;
                }

            }
        }

        public static void GenerateStage(double x, int numberOfStage, double z, int windowsCount, bool frontWindows, bool sideWindows, bool frontWideWindows, int angle, string textureName)
        {

            double stageXSize = 5.0;
            double stageYSize = 2.0;
            double stageZSize = 5.0;

            GenerateParallelogram(x, stageXSize, (numberOfStage * stageYSize), stageYSize, z, stageZSize, textureName);

            for (int i = 0; i < windowsCount; i++)
            {
                double sizeBeetweenCornerAndWindow = 0.3;
                double yBeetweenFloorAndWindow = 0.5;
                double windowsWidth = 0.4;
                // if (angle == 0)
                {
                    if (sideWindows)
                    {
                        if (angle == 90 && frontWideWindows && numberOfStage > 3)
                        {
                            windowsWidth = 1.5;

                            if (i <= 1)
                            {
                                //правая сторона
                                GenerateWindow(x + i * stageXSize / windowsCount + sizeBeetweenCornerAndWindow * 2, (numberOfStage * stageYSize) + yBeetweenFloorAndWindow, z - 0.01, 0.6, windowsWidth, 0);
                                //левая сторона
                                GenerateWindow(x + i * stageXSize / windowsCount + sizeBeetweenCornerAndWindow * 2, (numberOfStage * stageYSize) + yBeetweenFloorAndWindow, z + 0.01 + stageZSize, 0.6, windowsWidth, 0);
                            }
                        }
                        else
                        {
                            //правая сторона
                            GenerateWindow(x + i * stageXSize / windowsCount + sizeBeetweenCornerAndWindow, (numberOfStage * stageYSize) + yBeetweenFloorAndWindow, z - 0.01, windowsWidth * 1.5, windowsWidth, 0);
                            //левая сторона
                            GenerateWindow(x + i * stageXSize / windowsCount + sizeBeetweenCornerAndWindow, (numberOfStage * stageYSize) + yBeetweenFloorAndWindow, z + 0.01 + stageZSize, windowsWidth * 1.5, windowsWidth, 0);
                        }
                    }
                    if (frontWindows)
                    {

                        if (angle == 0 && frontWideWindows && numberOfStage > 3)
                        {
                            windowsWidth = 1.5;

                            if (i <= 1)
                            {
                                //фасад
                                GenerateWindow(x - 0.01, (numberOfStage * stageYSize) + yBeetweenFloorAndWindow, z + i * stageZSize / windowsCount + sizeBeetweenCornerAndWindow * 3, 0.6, windowsWidth, 90);
                                //зад
                                GenerateWindow(x + 0.01 + stageZSize, (numberOfStage * stageYSize) + yBeetweenFloorAndWindow, z + i * stageZSize / windowsCount + sizeBeetweenCornerAndWindow * 3, 0.6, windowsWidth, 90);
                            }
                        }

                        else
                        {
                            //фасад
                            GenerateWindow(x - 0.01, (numberOfStage * stageYSize) + yBeetweenFloorAndWindow, z + i * stageZSize / windowsCount + sizeBeetweenCornerAndWindow, 0.6, windowsWidth, 90);
                            //зад
                            GenerateWindow(x + 0.01 + stageZSize, (numberOfStage * stageYSize) + yBeetweenFloorAndWindow, z + i * stageZSize / windowsCount + sizeBeetweenCornerAndWindow, 0.6, windowsWidth, 90);
                        }
                    }
                }
            }
        }

        public static void GenerateWindow(double x, double y, double z, double height, double width, int angle)
        {
            if (angle == 90)
            {
                double x2 = x;
                double y2 = y + height;
                double z2 = z + width;
                GenerateRectangle(x, y, z, x2, y2, z2, "glass");
            }

            if (angle == 0)
            {
                double x2 = x + width;
                double y2 = y + height;
                double z2 = z;
                GenerateRectangle(x, y, z, x2, y2, z2, "glass");
            }

        }

        public static void GenerateParallelogram(double x, double xsize, double y, double ysize, double z, double zsize, string textureName)
        {
            double x2 = x + xsize;
            double y2 = y + ysize;
            double z2 = z + zsize;

            //перед
            GenerateRectangle(x, y, z, x2, y2, z, textureName);

            //зад
            GenerateRectangle(x, y, z2, x2, y2, z2, textureName);

            //правый бок
            GenerateRectangle(x2, y, z, x2, y2, z2, textureName);

            //левый бок
            GenerateRectangle(x, y, z, x, y2, z2, textureName);


            //верх
            GenerateRectangle(x, y2, z, x2, y2, z2, textureName);

            //низ
            GenerateRectangle(x, y, z, x2, y, z2, textureName);
        }

        public static void GenerateRectangle(double x1, double y1, double z1, double x2, double y2, double z2, string textureName)
        {
            //double diaganal = (double)(int)Math.Sqrt((x2 - x1) * (x2 - x1) + (y2 - y1) * (y2 - y1) + (z2 - z1) * (z2 - z1));

            if (Math.Abs(y1 - y2) > 1e-15)
            {
                GenerateTriangle(x1, y1, z1, x2, y2, z2, x1, y2, z1, textureName, 0);
                GenerateTriangle(x2, y2, z2, x1, y1, z1, x2, y1, z2, textureName, 1);
            }
            else
            {
                GenerateTriangle(x1, y1, z1, x2, y2, z2, x1, y2, z2, textureName, 0);
                GenerateTriangle(x2, y2, z2, x1, y1, z1, x2, y1, z1, textureName, 1);
            }
        }

        public static void GenerateTriangle(double x1, double y1, double z1, double x2, double y2, double z2, double x3, double y3, double z3, string textureName, int textureOrder)
        {

            double textureSize = 1;
            if (Math.Abs(y1 - y2) < 1e-15 && Math.Abs(y1 - y3) < 1e-15) textureSize = 1000.0;
            if (textureOrder == 0)
            {
                _fileContent += String.Format("{0:0.##} {1:0.##} {2:0.##} {3:0.##} {4:0.##} {5:0.##} \r\n", x1, y1, z1, 0, 0, textureName);
                _fileContent += String.Format("{0:0.##} {1:0.##} {2:0.##} {3:0.##} {4:0.##} {5:0.##} \r\n", x2, y2, z2, textureSize, textureSize, textureName);
                _fileContent += String.Format("{0:0.##} {1:0.##} {2:0.##} {3:0.##} {4:0.##} {5:0.##} \r\n", x3, y3, z3, textureSize, 0, textureName);

            }
            else
            {

                _fileContent += String.Format("{0:0.##} {1:0.##} {2:0.##} {3:0.##} {4:0.##} {5:0.##} \r\n", x1, y1, z1, textureSize, textureSize, textureName);
                _fileContent += String.Format("{0:0.##} {1:0.##} {2:0.##} {3:0.##} {4:0.##} {5:0.##} \r\n", x2, y2, z2, 0, 0, textureName);
                _fileContent += String.Format("{0:0.##} {1:0.##} {2:0.##} {3:0.##} {4:0.##} {5:0.##} \r\n", x3, y3, z3, 0, textureSize, textureName);
            }

            _polygonsCount++;

            _fileContent += "\r\n";
        }
        /*  public static void GenerateVertex(double x1, double y1, double z1, string textureName)
          {
              fileContent += String.Format("{0},0 {1},0 {2},0 {3},0 {4},0 {5} \r\n", x1, y1, z1, 0, 0, textureName);
        
          }*/
    }
}
