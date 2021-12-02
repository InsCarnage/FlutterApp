import 'package:flutter/material.dart';
import 'package:snipper/pages/homepage.dart';

var url = Uri.parse('https://www.carnagehosting.com/api/');
void main() {
  runApp( MyApp());
}
class HexColor extends Color {
  static int _getColorFromHex(String hexColor) {
    hexColor = hexColor.toUpperCase().replaceAll("#", "");
    if (hexColor.length == 6) {
      hexColor = "FF" + hexColor;
    }
    return int.parse(hexColor, radix: 16);
  }

  HexColor(final String hexColor) : super(_getColorFromHex(hexColor));
}
class MyApp extends StatelessWidget {
   MyApp({Key? key}) : super(key: key);

  ThemeData _darkTheme = ThemeData(
    accentColor: HexColor("990000"),
    brightness: Brightness.dark,
    primaryColor: HexColor("990000"),
    backgroundColor: HexColor("121212")
  );
            
  ThemeData _lightTheme = ThemeData(
    accentColor: Colors.pink,
    brightness: Brightness.light,
    primaryColor: Colors.blue
  );
  @override
  Widget build(BuildContext context) {
    return MaterialApp(
      title: 'Flutter Demo',
      theme: _darkTheme,
      home: const HomePage(),
    );
  }
}
