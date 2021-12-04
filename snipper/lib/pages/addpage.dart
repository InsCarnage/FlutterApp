import 'package:flutter/material.dart';
import 'package:snipper/main.dart';
import 'package:snipper/models/catagoryModal.dart';
import 'package:snipper/models/newsinfo.dart';
import 'package:snipper/pages/friendspage.dart';
import 'package:snipper/pages/homepage.dart';
import 'package:snipper/services/api_manger.dart';

class AddItemspage extends StatefulWidget {
  const AddItemspage({Key? key}) : super(key: key);

  @override
  _AddItemspage createState() => _AddItemspage();
}

class _AddItemspage extends State<AddItemspage> {
  //Future<NewsModal>? _newsModal ;

  final itemName = TextEditingController();
  final itemDescription = TextEditingController();

  @override
  void initState() {
    //_newsModal = API_Manager().getNews();
    super.initState();
  }

  List<DropdownMenuItem<String>> get dropdownItems {
    List<DropdownMenuItem<String>> menuItems = [
      DropdownMenuItem(child: Text("Birthday"), value: "1"),
      DropdownMenuItem(child: Text("Anniversary"), value: "2"),
      DropdownMenuItem(child: Text("Festive Season"), value: "3"),
      DropdownMenuItem(child: Text("Other"), value: "4"),
    ];
    return menuItems;
  }

  String selectedValue = "1";

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
          child: Column(children: [
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
                style: TextStyle(color: Colors.white),
                decoration: const InputDecoration(
                  border: OutlineInputBorder(),
                  labelText: 'Description',
                ),
              ),
            ),
            Container(
              padding: const EdgeInsets.symmetric(horizontal: 0, vertical: 5),
              child: Row(
                children: [
                  DropdownButton(
                    items: dropdownItems,
                    value: selectedValue,
                    style: const TextStyle(
                      color: Colors.white,
                      inherit: false,
                      decorationColor: Colors.white,
                    ),
                    onChanged: (String? newValue) {
                      setState(() {
                        selectedValue = newValue!;
                      });
                    },
                  ),
                ],
              ),
            ),
          ]),
        ),
      ),
    );
  }
}
