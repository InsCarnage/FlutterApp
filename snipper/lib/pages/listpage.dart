import 'package:flutter/material.dart';
import 'package:snipper/models/newsinfo.dart';
import 'package:snipper/pages/addpage.dart';
import 'package:snipper/pages/homepage.dart';
import 'package:snipper/services/api_manger.dart';

class Listpage extends StatefulWidget {
  const Listpage({ Key? key }) : super(key: key);

  @override
  _Listpage createState() => _Listpage();
}

class _Listpage extends State<Listpage> {
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
          child: Image.network(
            "https://source.unsplash.com/random/1920x1080/?img=1",
            fit: BoxFit.cover,
          ) ,
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
        floatingActionButton: FloatingActionButton(
          onPressed: () {
            Navigator.push(context, MaterialPageRoute(builder: (context) => AddItemspage()));
          },
          child: const Icon(Icons.add),
          backgroundColor: Colors.blue,
        ),
      ),
    );
  }
}