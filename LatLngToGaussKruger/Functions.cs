namespace LatLngToGaussKruger
{
    internal class Functions
    {
        public static void LLtoGaussKruger(double Lat, double Long, out double GKEasting, out double GKNorthing)
        {
            double c;

            double lw = Long;
            double bw = Lat;

            double a = 6378137.000;
            double fq = 3.35281066e-3;

            double f = fq - 1.003748e-5;

            double dx = -587;
            double dy = -16;
            double dz = -393;

            double e2q = (2 * fq - fq * fq);
            double e2 = (2 * f - f * f);


            double b1 = bw * (Math.PI / 180);
            double l1 = lw * (Math.PI / 180);

            double nd = a / Math.Sqrt(1 - e2q * Math.Sin(b1) * Math.Sin(b1));

            double xw = nd * Math.Cos(b1) * Math.Cos(l1);
            double yw = nd * Math.Cos(b1) * Math.Sin(l1);
            double zw = (1 - e2q) * nd * Math.Sin(b1);

            double x = xw + dx;
            double y = yw + dy;
            double z = zw + dz;

            double rb = Math.Sqrt(x * x + y * y);
            double b2 = (180 / Math.PI) * Math.Atan((z / rb) / (1 - e2));

            double l2;

            if (x > 0)
                l2 = (180 / Math.PI) * Math.Atan(y / x);
            else if (x < 0 && y > 0)
                l2 = (180 / Math.PI) * Math.Atan(y / x) + 180;
            else
                l2 = (180 / Math.PI) * Math.Atan(y / x) - 180;

            if (b2 < 46 || b2 > 56 || l2 < 5 || l2 > 16)
            {
                GKNorthing = 0;
                GKEasting = 0;
                return;
            }

            a = 6377397.15508;
            f = 3.34277321e-3;
            c = a / (1 - f);

            double ex2 = (2 * f - f * f) / ((1 - f) * (1 - f));
            double ex4 = ex2 * ex2;
            double ex6 = ex4 * ex2;
            double ex8 = ex4 * ex4;

            double e0 = c * (Math.PI / 180) * (1 - 3 * ex2 / 4 + 45 * ex4 / 64 - 175 * ex6 / 256 + 11025 * ex8 / 16384);
            e2 = c * (-3 * ex2 / 8 + 15 * ex4 / 32 - 525 * ex6 / 1024 + 2205 * ex8 / 4096);
            double e4 = c * (15 * ex4 / 256 - 105 * ex6 / 1024 + 2205 * ex8 / 16384);
            double e6 = c * (-35 * ex6 / 3072 + 315 * ex8 / 12288);

            double br = b2 * Math.PI / 180;

            double tan1 = Math.Tan(br);
            double tan2 = tan1 * tan1;
            double tan4 = tan2 * tan2;

            double cos1 = Math.Cos(br);
            double cos2 = cos1 * cos1;
            double cos4 = cos2 * cos2;
            double cos3 = cos2 * cos1;
            double cos5 = cos4 * cos1;

            double etasq = ex2 * cos2;

            nd = c / Math.Sqrt(1 + etasq);

            double g = e0 * b2 + e2 * Math.Sin(2 * br) + e4 * Math.Sin(4 * br) + e6 * Math.Sin(6 * br);

            double kz = Math.Floor((l2 + 1.5) / 3);
            double lh = kz * 3;
            double dl = (l2 - lh) * Math.PI / 180;
            double dl2 = dl * dl;
            double dl4 = dl2 * dl2;
            double dl3 = dl2 * dl;
            double dl5 = dl4 * dl;

            double hw = (g + nd * cos2 * tan1 * dl2 / 2 + nd * cos4 * tan1 * (5 - tan2 + 9 * etasq) * dl4 / 24);
            double rw = (nd * cos1 * dl + nd * cos3 * (1 - tan2 + etasq) * dl3 / 6 +
                              nd * cos5 * (5 - 18 * tan2 + tan4) * dl5 / 120 + kz * 1e6 + 500000);
            GKNorthing = hw;
            GKEasting = rw;
        }
    }
}
