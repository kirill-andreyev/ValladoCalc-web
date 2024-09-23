namespace ValladoCalc.BusinessLogic.Calculators
{
    public static class Angle
    {
        public static decimal ConvertToDegrees(decimal radians)
        {
            return radians * 180m / (decimal)Math.PI;
        }

        public static decimal ConvertToRadians(decimal degrees)
        {
            return degrees * ((decimal)Math.PI / 180m);
        }
    }
}