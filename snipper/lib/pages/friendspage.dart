import 'dart:ui';

import 'package:flutter/material.dart';
import 'package:snipper/main.dart';
import 'package:snipper/models/newsinfo.dart';
import 'package:snipper/pages/addpage.dart';
import 'package:snipper/pages/homepage.dart';
import 'package:snipper/services/api_manger.dart';

class Friendspage extends StatefulWidget {
  const Friendspage({ Key? key }) : super(key: key);

  @override
  _Friendspage createState() => _Friendspage();
}

class _Friendspage extends State<Friendspage> {
  //Future<NewsModal>? _newsModal ;
  int _selectedIndex = 0;
  @override
  void initState(){
    //_newsModal = API_Manager().getNews();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        backgroundColor: HexColor("121212"),
        body: Container(
          width: MediaQuery.of(context).size.width,
          padding: EdgeInsets.only(top: 5,bottom: 5,left: 10,right: 10),
          child: ListView(
            children: [
              Container(
                margin: EdgeInsets.only(bottom: 20, top: 20),
                child: TextField(
                  decoration: InputDecoration(
                    border: const OutlineInputBorder(),
                    hintText: 'Enter a search term',
                    focusColor: HexColor("990000"),
                    hoverColor: HexColor("990000"),
                  ),
                ),
              ),
              Container(
                decoration: BoxDecoration(
                  boxShadow: [
                    BoxShadow(
                      color: HexColor("000000"),
                      spreadRadius: 5,
                      blurRadius: 7,
                      offset: Offset(0, 3), // changes position of shadow
                    ),
                    
                  ]
                ), 
                child: Row(
                  children: [
                    Container(
                      decoration: BoxDecoration(
                        borderRadius: BorderRadius.circular(10),
                        
                      ),
                      width: 80,
                      height: 80,
                      margin: EdgeInsets.only(top: 10, bottom: 10, left: 10),
                      child: ClipRRect(
                        borderRadius: BorderRadius.circular(100.0),
                        child: Image.network(
                          "https://picsum.photos/seed/picsum/1920/1080",
                          height: 60,
                          width: 60,
                          fit: BoxFit.fill,
                        ),
                      )
                    ),
                    Container(
                      margin: EdgeInsets.only(left: 10),
                      child: Text(
                        "This user Name",
                        style: TextStyle(
                          fontSize: 20,
                          fontWeight: FontWeight.bold
                        ) 
                      ),
                    )
                  ],
                ),
              )
            ],
          ),
          // child: Row(
          //   children: [
          //     Container(
          //       margin: EdgeInsets.all(20),
          //       decoration: BoxDecoration(
          //         boxShadow: [
          //           BoxShadow(
          //             color: HexColor("000000"),
          //             spreadRadius: 5,
          //             blurRadius: 7,
          //             offset: Offset(0, 3), // changes position of shadow
          //           ),
          //         ]
          //       ),
          //       child: Column(
          //         children: [
          //           Container(
          //             height: 100,
          //             decoration: BoxDecoration(
          //               borderRadius: BorderRadius.circular(100),
                        
          //             ),
                      
          //             child: Image.network(
          //               "https://picsum.photos/seed/picsum/1920/1080",
          //             ),
          //           )
          //         ],
          //       ),
          //     )
          //   ],
          // ),
        ),
      ),
    );
  }
}