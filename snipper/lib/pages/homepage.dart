import 'package:flutter/material.dart';
import 'package:snipper/main.dart';
import 'package:snipper/models/newsinfo.dart';
import 'package:snipper/pages/addpage.dart';
import 'package:snipper/pages/friendspage.dart';
import 'package:snipper/pages/landingpage.dart';
import 'package:snipper/pages/listpage.dart';
import 'package:snipper/services/api_manger.dart';

class HomePage extends StatefulWidget {
  const HomePage({Key? key}) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  //Future<NewsModal>? _newsModal ;
  int _widgetIndex = 0;
  @override
  void initState() {
    //_newsModal = API_Manager().getNews();
    super.initState();
  }

  void _onItemTapped(int index) {
    setState(() {
      _widgetIndex = index;
    });
  }

  @override
  Widget build(BuildContext context) {
    return SafeArea(
      child: Scaffold(
        body: IndexedStack(
          index: _widgetIndex,
          children: const [
            LandingPage(),
            Listpage(),
            Friendspage(),
          ],
        ),

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

        bottomNavigationBar: BottomNavigationBar(
          type: BottomNavigationBarType.fixed,
          backgroundColor: HexColor("121212"),
          items: const <BottomNavigationBarItem>[
            BottomNavigationBarItem(
              icon: Icon(Icons.home),
              label: 'Feed',
            ),
            BottomNavigationBarItem(
              icon: Icon(Icons.list),
              label: 'My List',
            ),
            BottomNavigationBarItem(
              icon: Icon(Icons.people),
              label: 'Friends',
            ),
          ],
          currentIndex: _widgetIndex,
          onTap: _onItemTapped,
        ),
      ),
    );
  }
}
