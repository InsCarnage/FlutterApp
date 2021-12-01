import 'package:flutter/material.dart';
import 'package:snipper/models/newsinfo.dart';
import 'package:snipper/pages/homepage.dart';
import 'package:snipper/services/api_manger.dart';

class LandingPage extends StatefulWidget {
  const LandingPage({ Key? key }) : super(key: key);

  @override
  _LandingPage createState() => _LandingPage();
}

class _LandingPage extends State<LandingPage> {
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
        body: Container(
          padding: EdgeInsets.all(10),
          child:  Container(
            margin: EdgeInsets.all(20),
            decoration: BoxDecoration(
            boxShadow: [
              BoxShadow(
                color: Colors.grey.withOpacity(0.5),
                spreadRadius: 5,
                blurRadius: 7,
                offset: Offset(0, 3), // changes position of shadow
              ),
            ]
          ),
            child: Image.network(
              "https://picsum.photos/seed/picsum/1920/1080",
            ),
          )
          // child: FutureBuilder<NewsModal>(
          //   future: _newsModal,
          //   builder: (context, snapshot) {
          //     if(snapshot.hasData){
          //       return ListView.builder(
          //         itemCount: snapshot.data!.articles.length,
          //         itemBuilder: (context,index) {
          //         var article = snapshot.data!.articles[index];
          //         return Container(
          //           height: 300,
          //           child: Flexible(
          //             child: Column(
          //               children: <Widget>[
          //                 Card(clipBehavior: Clip.antiAlias,
          //                   shape: RoundedRectangleBorder(
          //                   borderRadius: BorderRadius.circular(24),
          //                   ),
          //                   child: Image.network(
          //                     article.urlToImage,
          //                     fit: BoxFit.cover,
          //                   )
          //                 ),
          //                 Flexible(
          //                   child: (
          //                     Column(
          //                       children:[
          //                         Expanded(
          //                           flex: 1,
          //                           child: Container(
          //                             child: Center(child: Text(article.title),),
          //                           ),
          //                         ),
          //                         Expanded(
          //                           flex: 2,
          //                           child: Container(
          //                             child:Center(child: Text(article.description),),
          //                           ),
          //                         )
          //                       ],
          //                     )
          //                   ),
          //                 ),
          //               ],
          //             ),
          //           ),
          //         );
          //       });
          //     }
          //     else{
          //       return Center(child: CircularProgressIndicator());
          //     }
          //   },
          // ),
        ),
      ),
    );
  }
}