# Lat / Lng to Gauss–Krüger coordinate system conversion in C#
🇩🇪 C# Functionality for converting **Latitude and Longitude** *(WGS84)* values to the **Gauss–Krüger coordinate system** *(Gauß-Krüger-Koordinatensystem)*. \*

\* also sometimes referred to as *GK or the German Grid System*.

📱 This C# code has been derived from that used in my [Grid Ref GK](https://www.mike-irving.co.uk/portfolio/mobile-apps/grid-ref-gk/) mobile app.

## How to use

⬇️ Download the repository and open the *LatLngToGaussKruger.sln* file in [Visual Studio](https://visualstudio.microsoft.com/).

▶️ Then run it.

✏️ Modify *Program.cs* to set the WGS84 Latitude and Longitude input variables - *lat* and *lng*.

### Example

`Functions.LLtoGaussKruger(53.551085, 9.993682, out gkEasting, out gkNorthing);`

would return `gkEasting = 3565935`, `gkNorthing = 5935969`

### Files of interest

Whilst the entire repository can be compiled and used as a C# / .NET Console App, these are the main files.

💻 **Program.cs** - the controller of the console app, showing you how to use the *LLtoGaussKruger (double Lat, double Long, out double GKEasting, out double GKNorthing)* function.

🔢 **Functions.cs** - the mathematical functions that perform the grid coordinate conversion.

### Contributions

🍴 Feel free to Fork / Branch / Modify, raise any Pull Requests for changes.

#### Also available

Lat / Lng to: [Swiss Grid](https://github.com/mikeirvingweb/LatLngToSwissGrid).
