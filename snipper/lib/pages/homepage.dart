import 'package:flutter/material.dart';
import 'package:snipper/models/newsinfo.dart';
import 'package:snipper/services/api_manger.dart';

class HomePage extends StatefulWidget {
  const HomePage({ Key? key }) : super(key: key);

  @override
  _HomePageState createState() => _HomePageState();
}

class _HomePageState extends State<HomePage> {
  Future<NewsModal>? _newsModal ;

  @override
  void initState(){
    _newsModal = API_Manager().getNews();
    super.initState();
  }

  @override
  Widget build(BuildContext context) {
    return Scaffold(
      appBar: AppBar(
        title: Text('News App'),
      ),
      body: Container(
        child: FutureBuilder<NewsModal>(
          future: _newsModal,
          builder: (context, snapshot) {
            if(snapshot.hasData){
              return ListView.builder(
                itemCount: snapshot.data!.articles.length,
                itemBuilder: (context,index) {
                var article = snapshot.data!.articles[index];
                return Container(
                  height: 400,
                  child: Flexible(
                    child: Column(
                      children: <Widget>[
                        Card(clipBehavior: Clip.antiAlias,
                          shape: RoundedRectangleBorder(
                          borderRadius: BorderRadius.circular(24),
                          ),
                          child: Image.network(
                            article.urlToImage,
                            fit: BoxFit.cover,
                          )
                        ),
                        Flexible(
                          child: (
                            Container(
                              child: ListView(
                                children: [
                                  ListTile(
                                    title: Text(article.title),
                                  ),
                                  ListBody(
                                    children: [
                                      Text(article.description)
                                    ],
                                  )
                                ],
                              ),
                            )
                          ),
                        ),
                      ],
                    ),
                  ),
                );
              });
            }
            else{
              return Center(child: CircularProgressIndicator());
            }
          },
        ),
      ),
    );
  }
}