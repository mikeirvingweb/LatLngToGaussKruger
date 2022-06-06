using LatLngToGaussKruger;

// Input Variables: WGS84 Latitude and Longitude
double lat = 53.551085;
double lng = 9.993682;

// Output Variables: GK Easting and Northing
double gkEasting;
double gkNorthing;

Functions.LLtoGaussKruger(lat, lng, out gkEasting, out gkNorthing);

Console.WriteLine("Lat: " + lat.ToString() + ", Lng: " + lng.ToString() + " = GK Grid: " + Convert.ToInt32(Math.Floor(gkEasting)).ToString() + " / " + Convert.ToInt32(Math.Floor(gkNorthing)).ToString() + Environment.NewLine);
Console.WriteLine("Gauss–Krüger coordinate system (Gauß-Krüger-Koordinatensystem)");