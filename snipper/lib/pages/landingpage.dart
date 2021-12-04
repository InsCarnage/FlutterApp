import 'package:flutter/material.dart';
import 'package:snipper/main.dart';
import 'package:snipper/models/newsinfo.dart';
import 'package:snipper/pages/homepage.dart';
import 'package:snipper/services/api_manger.dart';

class LandingPage extends StatefulWidget {
  const LandingPage({Key? key}) : super(key: key);

  @override
  _LandingPage createState() => _LandingPage();
}

class _LandingPage extends State<LandingPage> {
  //Future<NewsModal>? _newsModal ;
  int _selectedIndex = 0;
  @override
  void initState() {
    //_newsModal = API_Manager().getNews();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: HexColor("121212"),
        body: Container(
            padding: EdgeInsets.all(10),
            child: Container(
              margin: EdgeInsets.all(20),
              decoration: BoxDecoration(boxShadow: [
                BoxShadow(
                  color: HexColor("000000"),
                  spreadRadius: 5,
                  blurRadius: 7,
                  offset: Offset(0, 3), // changes position of shadow
                ),
              ]),
              child: Image.network(
                "https://picsum.photos/seed/picsum/1920/1080",
              ),
            )),
      ),
    );
  }
}
