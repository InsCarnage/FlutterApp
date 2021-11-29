import 'dart:convert';

import 'package:http/http.dart' as http;
import 'package:snipper/constants/strings.dart';
import 'package:snipper/models/newsinfo.dart';

class API_Manager {
  Future<NewsModal> getNews() async{
    var client = http.Client();
    var newsModel;
    try {
      var response = await client.get(Uri.parse(Strings.news_url));
      if(response.statusCode == 200){
        var jsonString = response.body;
        var jsonMap = json.decode(jsonString);
        newsModel =  NewsModal.fromJson(jsonMap);
      }
    } 
    catch (Exception) {
      return newsModel;
    }
    return newsModel;
  }
}