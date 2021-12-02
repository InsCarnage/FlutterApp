import 'package:flutter/material.dart';
import 'package:snipper/main.dart';
import 'package:snipper/models/catagoryModal.dart';
import 'package:snipper/models/newsinfo.dart';
import 'package:snipper/pages/friendspage.dart';
import 'package:snipper/pages/homepage.dart';
import 'package:snipper/services/api_manger.dart';

class AddItemspage extends StatefulWidget {
  const AddItemspage({ Key? key }) : super(key: key);

  @override
  _AddItemspage createState() => _AddItemspage();
}

class _AddItemspage extends State<AddItemspage> {
  //Future<NewsModal>? _newsModal ;

  final itemName = TextEditingController();
  final itemDescription = TextEditingController();


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
        appBar: AppBar(
          backgroundColor: HexColor("121212"),
          title: const Text('Add Item'),
        ),
        body: Container(
          padding: const EdgeInsets.symmetric(horizontal: 12, vertical: 5),
          child: Column(
            children: [
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 0, vertical: 5),
                child: TextFormField(
                  controller: itemName,
                  decoration: const InputDecoration(
                    border: UnderlineInputBorder(),
                    labelText: 'Item name',
                  ),
                ),
              ),
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 0, vertical: 5),
                child: TextFormField(
                  controller: itemDescription,
                  keyboardType: TextInputType.multiline,
                  minLines: 1,
                  maxLines: null,
                  decoration: const InputDecoration(
                    border: OutlineInputBorder(),
                    labelText: 'Description',
                  ),
                ),
              ),
              Container(
                padding: const EdgeInsets.symmetric(horizontal: 0, vertical: 5),
                child: DropdownButton(
                  items: <CatagoryModal>[],
                ),
              ),
            ]
          ),
        ),
      ),
    );
  }
}