import 'dart:convert';

CatagoryModal catagoryModalFromJson(String str) =>
    CatagoryModal.fromJson(json.decode(str));

String catagoryModalToJson(CatagoryModal data) => json.encode(data.toJson());

class CatagoryModal {
  CatagoryModal({
    required this.id,
    required this.Name,
  });

  int id;
  String Name;

  factory CatagoryModal.fromJson(Map<String, dynamic> json) => CatagoryModal(
        id: json["id"],
        Name: json["Name"],
      );

  Map<String, dynamic> toJson() => {
        "id": id,
        "Name": Name,
      };
}
